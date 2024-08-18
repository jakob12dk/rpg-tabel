using rpg_tabel.Logic.NpcGenerator;

public interface IRace
{
    string Name { get; }
    void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores);
    int CalculateSpeed();
    List<string> GetLanguages();
}
