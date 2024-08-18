using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class HalfOrc : IRace
    {
        public FantasyRace RaceType => FantasyRace.HalfOrc;
        public string Name => "Half-Orc";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Strength, +1 Constitution
            if (abilityScores.ContainsKey(Ability.Strength))
            {
                abilityScores[Ability.Strength] += 2;
            }
            if (abilityScores.ContainsKey(Ability.Constitution))
            {
                abilityScores[Ability.Constitution] += 1;
            }
        }

        public int CalculateSpeed() => 30;

        public List<string> GetLanguages() => new List<string> { "Common", "Orc" };
    }
}
