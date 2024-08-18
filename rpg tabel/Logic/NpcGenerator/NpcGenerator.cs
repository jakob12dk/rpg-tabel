using System;
using System.Collections.Generic;
using System.Linq;
using rpg_tabel.Logic.namegenerator;
using rpg_tabel.Logic.NpcGenerator.Races;

namespace rpg_tabel.Logic.NpcGenerator.npcs
{
    public class NpcGenerator
    {
        private readonly NameGenerator _nameGenerator;
        private readonly Dictionary<FantasyRace, Func<IRace>> _raceFactory;

        public NpcGenerator(NameGenerator nameGenerator)
        {
            _nameGenerator = nameGenerator ?? throw new ArgumentNullException(nameof(nameGenerator));

            _raceFactory = new Dictionary<FantasyRace, Func<IRace>>
        {
            { FantasyRace.Human, () => new Human() },
            { FantasyRace.Towns, () => new HalfElf() },
            { FantasyRace.Elf, () => new Elf() },
            { FantasyRace.Dwarf, () => new Dwarf() },
            { FantasyRace.Orc, () => new Orc() },
            { FantasyRace.Goblin, () => new Goblin() },
            { FantasyRace.Troll, () => new Troll() },
            { FantasyRace.Halfling, () => new Halfling() },
            { FantasyRace.Dragonborn, () => new Dragonborn() },
            { FantasyRace.Tiefling, () => new Tiefling() },
            { FantasyRace.Gnome, () => new Gnome() },
            { FantasyRace.HalfElf, () => new HalfElf() },
            { FantasyRace.HalfOrc, () => new HalfOrc() }
        };
        }

        public NPC GenerateNpc(FantasyRace? raceType = null, string name = null)
        {
            // Choose race if not provided
            IRace race = null;
            if (raceType == null)
            {
                var randomRaceEnum = ChooseEnumOption<FantasyRace>();
                raceType = randomRaceEnum;
            }

            // Retrieve the race object from the factory
            if (_raceFactory.TryGetValue(raceType.Value, out var createRace))
            {
                race = createRace();
            }
            else
            {
                throw new ArgumentException($"Race type {raceType} not supported.");
            }

            // Create the NPC with the selected race
            var npc = new NPC
            {
                Name = name ?? _nameGenerator.GenerateName(raceType.Value),
                Race = raceType.Value,
                Class = ChooseEnumOption<NPCClass>(),
                Background = ChooseEnumOption<Background>(),
                Alignment = ChooseEnumOption<Alignment>(),
            };

            // Generate the NPC's ability scores
            npc.AbilityScores = GenerateAbilityScores();

            // Apply racial bonuses
            race.ApplyRacialBonuses(npc.AbilityScores);

            // Apply other race-specific attributes
            npc.Speed = race.CalculateSpeed();
            // Assuming `GetLanguages()` is part of `IRace` interface
            // You need to ensure the NPC class has a way to store languages if needed.

            // Generate other NPC attributes
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

            // Shuffle the standardArray to randomize score assignment
            var shuffledScores = standardArray.OrderBy(x => random.Next()).ToArray();

            // Get all ability values from the Ability enum
            var abilities = Enum.GetValues(typeof(Ability)).Cast<Ability>().ToList();

            // Ensure we have the correct number of abilities to match the scores
            if (abilities.Count != shuffledScores.Length)
            {
                throw new InvalidOperationException("The number of abilities and scores must match.");
            }

            // Assign each shuffled score to a different ability
            for (int i = 0; i < abilities.Count; i++)
            {
                abilityScores[abilities[i]] = shuffledScores[i];
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
