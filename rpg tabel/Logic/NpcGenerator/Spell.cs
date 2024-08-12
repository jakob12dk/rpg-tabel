using rpg_tabel.Logic.NpcGenerator.NpcGenerator;

namespace rpg_tabel.Logic.namegenerator.npcs
{
    public class Spell : ISpell
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string School { get; set; }
        public string Description { get; set; }

        public Spell(string name, int level, string school, string description)
        {
            Name = name;
            Level = level;
            School = school;
            Description = description;
        }
    }
}
