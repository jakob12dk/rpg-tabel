using System;
using System.Collections.Generic;
using System.Linq;
using rpg_tabel.Logic.namegenerator;
using rpg_tabel.Logic.namegenerator.names;

namespace rpg_tabel.Logic.namegenerator
{
    public class NameGenerator
    {
        private readonly Dictionary<FantasyRace, INameProvider> _nameProviders;

        public NameGenerator()
        {
            _nameProviders = new Dictionary<FantasyRace, INameProvider>
            {
                { FantasyRace.Human, new HumanNameProvider() },
                { FantasyRace.Elf, new ElfNameProvider() },
                { FantasyRace.Dwarf, new DwarfNameProvider() },
                { FantasyRace.Orc, new OrcNameProvider() },
                { FantasyRace.Goblin, new GoblinNameProvider() },
                { FantasyRace.Troll, new TrollNameProvider() },
                { FantasyRace.Halfling, new HalflingNameProvider() },
                { FantasyRace.Dragonborn, new DragonbornNameProvider() },
                { FantasyRace.Tiefling, new TieflingNameProvider() },
                { FantasyRace.Gnome, new GnomeNameProvider() },
                { FantasyRace.HalfElf, new HalfElfNameProvider() },
                { FantasyRace.HalfOrc, new HalfOrcNameProvider() },
                { FantasyRace.Towns, new FantasyTownNameProvider() }
            };
        }

        public string GenerateName(FantasyRace race)
        {
            if (_nameProviders.TryGetValue(race, out var nameProvider))
            {
                var firstNames = nameProvider.GetFirstNames();
                var lastNames = nameProvider.GetLastNames();

                if (firstNames.Any() && lastNames.Any())
                {
                    var random = new Random();
                    var randomFirstName = firstNames[random.Next(firstNames.Count)];
                    var randomLastName = lastNames[random.Next(lastNames.Count)];

                    return $"{randomFirstName} {randomLastName}";
                }
                else
                {
                    return "No names available.";
                }
            }
            else
            {
                return "Name provider not found.";
            }
        }
    }
}
