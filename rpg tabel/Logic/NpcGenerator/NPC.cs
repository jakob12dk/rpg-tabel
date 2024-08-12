using System.Collections.Generic;
using rpg_tabel.Logic.namegenerator;

namespace rpg_tabel.Logic.NpcGenerator.npcs
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
        public int ProficiencyBonus { get; set; }

        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public int Speed { get; set; }

        public Dictionary<Weapon, int> WeaponProficiencies { get; set; }
        public Dictionary<Armor, int> ArmorProficiencies { get; set; }
        public List<ISpell> Spells { get; set; }

        public string Personality { get; set; }
        public string Backstory { get; set; }
        public string Appearance { get; set; }

        public NPC()
        {
            AbilityScores = new Dictionary<Ability, int>();
            Skills = new Dictionary<Skill, int>();
            WeaponProficiencies = new Dictionary<Weapon, int>();
            ArmorProficiencies = new Dictionary<Armor, int>();
            Spells = new List<ISpell>();
        }
    }
}
