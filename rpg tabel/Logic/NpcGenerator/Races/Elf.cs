using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class Elf : IRace
    {
        public FantasyRace RaceType => FantasyRace.Elf;
        public string Name => "Elf";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Dexterity
            if (abilityScores.ContainsKey(Ability.Dexterity))
            {
                abilityScores[Ability.Dexterity] += 2;
            }
        }

        public int CalculateSpeed() => 30;

        public List<string> GetLanguages() => new List<string> { "Common", "Elvish" };
    }
}
