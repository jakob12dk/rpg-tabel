using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class Dwarf : IRace
    {
        public FantasyRace RaceType => FantasyRace.Dwarf;
        public string Name => "Dwarf";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Constitution
            if (abilityScores.ContainsKey(Ability.Constitution))
            {
                abilityScores[Ability.Constitution] += 2;
            }
        }

        public int CalculateSpeed() => 25;

        public List<string> GetLanguages() => new List<string> { "Common", "Dwarvish" };
    }
}
