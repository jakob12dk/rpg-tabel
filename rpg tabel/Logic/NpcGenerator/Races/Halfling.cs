using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class Halfling : IRace
    {
        public FantasyRace RaceType => FantasyRace.Halfling;
        public string Name => "Halfling";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Dexterity, +1 Charisma
            if (abilityScores.ContainsKey(Ability.Dexterity))
            {
                abilityScores[Ability.Dexterity] += 2;
            }
            if (abilityScores.ContainsKey(Ability.Charisma))
            {
                abilityScores[Ability.Charisma] += 1;
            }
        }

        public int CalculateSpeed() => 25;

        public List<string> GetLanguages() => new List<string> { "Common", "Halfling" };
    }
}
