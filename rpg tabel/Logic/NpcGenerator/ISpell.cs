namespace rpg_tabel.Logic.NpcGenerator
{
    public interface ISpell
    {
        string Name { get; set; }
        int Level { get; set; }
        string School { get; set; }
        string Description { get; set; }
    }
}
