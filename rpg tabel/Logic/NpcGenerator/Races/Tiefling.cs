﻿using rpg_tabel.Logic.namegenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_tabel.Logic.NpcGenerator.Races
{
    public class Tiefling : IRace
    {
        public FantasyRace RaceType => FantasyRace.Tiefling;
        public string Name => "Tiefling";

        public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores)
        {
            // Example bonuses: +2 Charisma, +1 Intelligence
            if (abilityScores.ContainsKey(Ability.Charisma))
            {
                abilityScores[Ability.Charisma] += 2;
            }
            if (abilityScores.ContainsKey(Ability.Intelligence))
            {
                abilityScores[Ability.Intelligence] += 1;
            }
        }

        public int CalculateSpeed() => 30;

        public List<string> GetLanguages() => new List<string> { "Common", "Infernal" };
    }

}
