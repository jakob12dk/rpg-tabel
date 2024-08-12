using rpg_tabel.Logic.namegenerator.names;
using System;

namespace rpg_tabel.Logic.namegenerator
{
    public class NameGenerator
    {
        private readonly INameProvider _nameProvider;

        public NameGenerator(FantasyRace race)
        {
            switch (race)
            {
                case FantasyRace.Human:
                    _nameProvider = new HumanNameProvider();
                    break;
                case FantasyRace.Elf:
                    _nameProvider = new ElfNameProvider();
                    break;
                // Add cases for other races
                default:
                    throw new ArgumentException("Unsupported race");
            }
        }

        public string GenerateName()
        {
            var firstNames = _nameProvider.GetFirstNames();
            var lastNames = _nameProvider.GetLastNames();

            Random random = new Random();
            string firstName = firstNames[random.Next(firstNames.Count)];
            string lastName = lastNames[random.Next(lastNames.Count)];

            return $"{firstName} {lastName}";
        }
    }
}
