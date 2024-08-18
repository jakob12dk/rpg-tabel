using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class Gnome : IRace
    {
        public FantasyRace RaceType => FantasyRace.Gnome;
        public string Name => "Gnome";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Intelligence
            if (abilityScores.ContainsKey(Ability.Intelligence))
            {
                abilityScores[Ability.Intelligence] += 2;
            }
        }

        public int CalculateSpeed() => 25;

        public List<string> GetLanguages() => new List<string> { "Common", "Gnomish" };
    }

}
