using System;
using System.Collections.Generic;
using System.Linq;
using rpg_tabel.Logic.namegenerator;

namespace rpg_tabel.Logic.NpcGenerator.npcs
{
    public class NpcGenerator
    {
        private readonly NameGenerator _nameGenerator;

        public NpcGenerator(NameGenerator nameGenerator)
        {
            _nameGenerator = nameGenerator ?? throw new ArgumentNullException(nameof(nameGenerator));
        }

        public NPC GenerateNpc(string name = null)
        {
            // Choose the NPC's race
            var race = ChooseEnumOption<FantasyRace>();

            // Create the NPC
            var npc = new NPC
            {
                Name =  _nameGenerator.GenerateName(race),
                Race = race,
                Class = ChooseEnumOption<NPCClass>(),
                Background = ChooseEnumOption<Background>(),
                Alignment = ChooseEnumOption<Alignment>(),
            };

            // Generate the NPC's ability scores and other attributes
            npc.AbilityScores = GenerateAbilityScores();
            npc.ProficiencyBonus = CalculateProficiencyBonus(1); // Example for a level 1 NPC
            npc.ArmorClass = CalculateArmorClass(GetModifier(npc.AbilityScores[Ability.Dexterity]), Armor.MediumArmor);
            npc.HitPoints = CalculateHitPoints(1, GetModifier(npc.AbilityScores[Ability.Constitution]), 10); // Assuming hit die is 10

            return npc;
        }

        private static T ChooseEnumOption<T>() where T : Enum
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            var random = new Random();
            return enumValues[random.Next(enumValues.Count)];
        }

        // Method to generate ability scores
        public Dictionary<Ability, int> GenerateAbilityScores()
        {
            var abilityScores = new Dictionary<Ability, int>();
            int[] standardArray = { 15, 14, 13, 12, 10, 8 };
            var random = new Random();

            foreach (Ability ability in Enum.GetValues(typeof(Ability)))
            {
                int score = standardArray[random.Next(standardArray.Length)];
                abilityScores.Add(ability, score);
            }

            return abilityScores;
        }

        // Static method to calculate the ability modifier
        public static int GetModifier(int score)
        {
            return (score - 10) / 2;
        }

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
    }
}
