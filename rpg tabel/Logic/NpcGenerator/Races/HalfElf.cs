using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class HalfElf : IRace
    {
        public FantasyRace RaceType => FantasyRace.HalfElf;
        public string Name => "Half-Elf";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Charisma, +1 to two other abilities
            if (abilityScores.ContainsKey(Ability.Charisma))
            {
                abilityScores[Ability.Charisma] += 2;
            }
            // Example: +1 Dexterity, +1 Constitution
            if (abilityScores.ContainsKey(Ability.Dexterity))
            {
                abilityScores[Ability.Dexterity] += 1;
            }
            if (abilityScores.ContainsKey(Ability.Constitution))
            {
                abilityScores[Ability.Constitution] += 1;
            }
        }

        public int CalculateSpeed() => 30;

        public List<string> GetLanguages() => new List<string> { "Common", "Elvish", "One other language" };
    }

}
