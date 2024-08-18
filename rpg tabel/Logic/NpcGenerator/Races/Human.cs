using rpg_tabel.Logic.namegenerator;
using rpg_tabel.Logic.NpcGenerator;

public class Human : IRace
{
    public FantasyRace RaceType => FantasyRace.Human;
    public string Name => "Human";
    public void ApplyRacialBonuses(Dictionary<Ability, int> abilityScores) { /* Implementation */ }
    public int CalculateSpeed() { return 30; }
    public List<string> GetLanguages() { return new List<string> { "Common" }; }
}
