using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rpg_tabel.Logic.namegenerator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace rpg_tabel.Logic.NpcGenerator
{
    public class NPC
    {
        public string Name { get; set; }
        public FantasyRace Race { get; set; }
        public NPCClass Class { get; set; }
        public Background Background { get; set; }
        public Alignment Alignment { get; set; }
        public Dictionary<Ability, int> AbilityScores { get; set; }
        public Dictionary<Skill, int> Skills { get; set; }
        public Dictionary<Weapon, int> Weapons { get; set; }
        public Dictionary<Armor, int> Armor { get; set; }
        public List<Spell> Spells { get; set; }
        public string Personality { get; set; }
        public string Backstory { get; set; }
        // Other relevant attributes

        public Dictionary<Ability, int> GenerateAbilityScores()
        {
            var scores = new Dictionary<Ability, int>();
            // Generate scores (e.g., point buy, standard array, rolling)
            return scores;
        }

        public int CalculateArmorClass()
        {
            // Calculate armor class based on class, armor, and dexterity modifier
        }

        public int CalculateHitPoints()
        {
            // Calculate hit points based on class hit die and constitution modifier
        }

        public void PopulateNPCAttributes(NPC npc)
        {
            // Set attributes based on selected race, class, and background
        }

    }
}
