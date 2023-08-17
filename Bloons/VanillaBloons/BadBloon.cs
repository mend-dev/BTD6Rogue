namespace BTD6Rogue;

public class BadBloon : RogueBloon {
    public override string BaseBloonId => "Bad";
    public override int MinRound => 100;
    public override int MaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 120;
    public override int FortifiedMaxRound => -1;
}
