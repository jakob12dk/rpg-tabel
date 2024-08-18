using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class Goblin : IRace
    {
        public FantasyRace RaceType => FantasyRace.Goblin;
        public string Name => "Goblin";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Dexterity, -1 Strength
            if (abilityScores.ContainsKey(Ability.Dexterity))
            {
                abilityScores[Ability.Dexterity] += 2;
            }
            if (abilityScores.ContainsKey(Ability.Strength))
            {
                abilityScores[Ability.Strength] -= 1;
            }
        }

        public int CalculateSpeed() => 30;

        public List<string> GetLanguages() => new List<string> { "Common", "Goblin" };
    }
}
