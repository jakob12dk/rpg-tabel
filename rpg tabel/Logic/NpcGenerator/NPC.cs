using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace rpg_tabel.Logic.NpcGenerator.NpcGenerator
{
    public class NPC
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public Class Class { get; set; }
        public Background Background { get; set; }
        public Alignment Alignment { get; set; }

        public Dictionary<Ability, int> AbilityScores { get; set; }
        public Dictionary<Skill, int> Skills { get; set; }
        public int ProficiencyBonus { get; set; }

        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public int Speed { get; set; }

        public Dictionary<Weapon, int> WeaponProficiencies { get; set; }
        public Dictionary<Armor, int> ArmorProficiencies { get; set; }
        public List<ISpell> Spells { get; set; }

        public string Personality { get; set; }
        public string Backstory { get; set; }
        public string Appearance { get; set; }

        public NPC()
        {
            AbilityScores = new Dictionary<Ability, int>();
            Skills = new Dictionary<Skill, int>();
            WeaponProficiencies = new Dictionary<Weapon, int>();
            ArmorProficiencies = new Dictionary<Armor, int>();
            Spells = new List<ISpell>();
        }

        // Enum selection methods
        public static T ChooseEnumOption<T>() where T : Enum
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            Console.WriteLine($"Choose a {typeof(T).Name}:");
            for (int i = 0; i < enumValues.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {enumValues[i]}");
            }

            int choice = int.Parse(Console.ReadLine());

            return enumValues[choice - 1];
        }

        public static int GetModifier(int score)
        {
            return (score - 10) / 2;
        }

        public void AddSpell(ISpell spell)
        {
            Spells.Add(spell);
        }

        // Existing methods
        public int CalculateProficiencyBonus(int level)
        {
            return (level - 1) / 4 + 2; // Example calculation, adjust as needed
        }

        public int CalculateArmorClass(int dexterityModifier, Armor equippedArmor)
        {
            switch (equippedArmor)
            {
                case Armor.LightArmor:
                    return 11 + dexterityModifier;
                case Armor.MediumArmor:
                    return 13 + Math.Min(dexterityModifier, 2);
                case Armor.HeavyArmor:
                    return 16;
                case Armor.Shield:
                    return 2;
                default:
                    return 10 + dexterityModifier;
            }
        }

        public int CalculateHitPoints(int level, int constitutionModifier, int hitDie)
        {
            return hitDie + (constitutionModifier * level) + (level - 1) * (hitDie / 2 + 1);
        }

        public void GenerateAbilityScores()
        {
            int[] standardArray = { 15, 14, 13, 12, 10, 8 };
            var random = new Random();

            foreach (Ability ability in Enum.GetValues(typeof(Ability)))
            {
                int score = standardArray[random.Next(standardArray.Length)];
                AbilityScores.Add(ability, score);
            }
        }

        public void AssignSkills(List<Skill> classSkills, List<Skill> backgroundSkills)
        {
            var random = new Random();

            foreach (var skill in classSkills)
            {
                Skills[skill] = ProficiencyBonus;
            }

            foreach (var skill in backgroundSkills)
            {
                if (!Skills.ContainsKey(skill))
                {
                    Skills[skill] = ProficiencyBonus;
                }
            }
        }

        public void PrintNPCDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Race: {Race}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Background: {Background}");
            Console.WriteLine($"Alignment: {Alignment}");
            Console.WriteLine("Ability Scores:");
            foreach (var score in AbilityScores)
            {
                Console.WriteLine($"  {score.Key}: {score.Value} (Modifier: {GetModifier(score.Value)})");
            }
            Console.WriteLine($"Armor Class: {ArmorClass}");
            Console.WriteLine($"Hit Points: {HitPoints}");
            Console.WriteLine("Skills:");
            foreach (var skill in Skills)
            {
                Console.WriteLine($"  {skill.Key}: +{skill.Value}");
            }
            Console.WriteLine("Spells:");
            foreach (var spell in Spells)
            {
                Console.WriteLine($"  {spell.Name} (Level {spell.Level}, {spell.School}): {spell.Description}");
            }
            Console.WriteLine($"Personality: {Personality}");
            Console.WriteLine($"Backstory: {Backstory}");
            Console.WriteLine($"Appearance: {Appearance}");
        }
    }
}
