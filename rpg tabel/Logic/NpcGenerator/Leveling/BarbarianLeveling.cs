using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using rpg_tabel.Logic.namegenerator.npcs;
using rpg_tabel.Logic.NpcGenerator.npcs;

namespace rpg_tabel.Logic.NpcGenerator.Leveling
{
    internal class BarbarianLeveling : ILevelable
    {
        private const string FileName = "BarbarianLeveling.xml";
        private readonly string _filePath;

        public BarbarianLeveling()
        {
            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RPG_Table", "Tabels", "Levels", FileName);
            EnsureFileExists();
        }

        public void ApplyLeveling(NPC npc)
        {
            if (npc == null) throw new ArgumentNullException(nameof(npc));
            if (npc.Level < 1 || npc.Level > 20) throw new ArgumentOutOfRangeException(nameof(npc.Level));

            var barbarianFeatures = LoadLevelingFeatures();

            // Update NPC attributes based on level
            if (npc.Level <= 20)
            {
                npc.HitPoints = LevelingUtils.CalculateHitPoints(npc.Level, LevelingUtils.GetModifier(npc.AbilityScores[Ability.Constitution]), barbarianFeatures.HitDie);
                npc.ProficiencyBonus = LevelingUtils.CalculateProficiencyBonus(npc.Level);

                // Apply specific Barbarian features
                // Example: Apply Rage, Extra Attack, Brutal Critical, etc.
            }
        }

        private BarbarianFeatures LoadLevelingFeatures()
        {
            var serializer = new XmlSerializer(typeof(BarbarianFeatures));
            using (var reader = new StreamReader(_filePath))
            {
                return (BarbarianFeatures)serializer.Deserialize(reader);
            }
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                GenerateDefaultXml();
            }
        }

        private void GenerateDefaultXml()
        {
            var defaultFeatures = new BarbarianFeatures
            {
                HitDie = 12,
                WeaponProficiencies = new List<WeaponProficiency>
                {
                    new WeaponProficiency { Weapon = Weapon.Greataxe, Proficiency = 1 },
                    new WeaponProficiency { Weapon = Weapon.Handaxe, Proficiency = 1 }
                },
                ArmorProficiencies = new List<ArmorProficiency>
                {
                    new ArmorProficiency { Armor = Armor.LightArmor, Proficiency = 1 },
                    new ArmorProficiency { Armor = Armor.MediumArmor, Proficiency = 1 },
                    new ArmorProficiency { Armor = Armor.Shield, Proficiency = 1 }
                },
                Spells = new List<Spell>() // Assuming Barbarian doesn't use spells
            };

            var serializer = new XmlSerializer(typeof(BarbarianFeatures));
            using (var writer = new StreamWriter(_filePath))
            {
                serializer.Serialize(writer, defaultFeatures);
            }
        }
    }
}
