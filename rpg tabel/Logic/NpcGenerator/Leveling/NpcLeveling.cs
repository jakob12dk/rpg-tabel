using rpg_tabel.Logic.NpcGenerator;
using rpg_tabel.Logic.NpcGenerator.npcs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RPG_Table
{
    public class NpcLeveling
    {
        private static string levelingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Leveling");

        public static void ApplyLeveling(NPC npc)
        {
            // Ensure the leveling directory and files exist
            EnsureLevelingFilesExist();

            string filePath = Path.Combine(levelingDirectory, $"{npc.Class}.xml");

            var doc = XDocument.Load(filePath);
            var levelElement = doc.Root.Elements("Level")
                                    .FirstOrDefault(e => (int)e.Attribute("number") == npc.Level);

            if (levelElement == null)
            {
                throw new InvalidOperationException($"Level {npc.Level} is not defined for class {npc.Class}.");
            }

            // Apply hit points
            var hitPointsElement = levelElement.Element("HitPoints");
            if (hitPointsElement != null)
            {
                npc.HitPoints += int.Parse(hitPointsElement.Value) + GetModifier(npc.AbilityScores[Ability.Constitution]);
            }

            // Apply features
            var features = levelElement.Element("Features");
            if (features != null)
            {
                foreach (var feature in features.Elements("Feature"))
                {
                    npc.Features.Add(feature.Value);
                }
            }
        }

        private static int GetModifier(int score)
        {
            return (score - 10) / 2;
        }

        public static void EnsureLevelingFilesExist()
        {
            if (!Directory.Exists(levelingDirectory))
            {
                Directory.CreateDirectory(levelingDirectory);
            }

            var classes = new List<string>
            {
                "Barbarian", "Bard", "Cleric", "Druid", "Fighter",
                "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer",
                "Warlock", "Wizard"
            };

            foreach (var className in classes)
            {
                string filePath = Path.Combine(levelingDirectory, $"{className}.xml");
                if (!File.Exists(filePath))
                {
                    CreateDefaultLevelingFile(className, filePath);
                }
            }
        }

        private static void CreateDefaultLevelingFile(string className, string filePath)
        {
            var doc = new XDocument(new XElement("Leveling"));

            for (int level = 1; level <= 20; level++)
            {
                var levelElement = new XElement("Level",
                    new XAttribute("number", level),
                    new XElement("HitPoints", GetDefaultHitPoints(className, level)),
                    new XElement("Features", new XElement("Feature", GetDefaultFeature(className, level)))
                );

                doc.Root.Add(levelElement);
            }

            doc.Save(filePath);
        }

        private static int GetDefaultHitPoints(string className, int level)
        {
            // Default hit die per class
            var hitDie = className switch
            {
                "Barbarian" => 12,
                "Bard" => 8,
                "Cleric" => 8,
                "Druid" => 8,
                "Fighter" => 10,
                "Monk" => 8,
                "Paladin" => 10,
                "Ranger" => 10,
                "Rogue" => 8,
                "Sorcerer" => 6,
                "Warlock" => 8,
                "Wizard" => 6,
                _ => 8,
            };

            return hitDie + ((level - 1) * (hitDie / 2 + 1));
        }

        private static string GetDefaultFeature(string className, int level)
        {
            // Placeholder feature text; customize this per class and level as needed
            return level == 1 ? $"{className} Feature at Level {level}" : $"Improved {className} Feature at Level {level}";
        }
    }
}
