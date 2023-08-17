namespace BTD6Rogue;

public class BfbBloon : RogueBloon {
    public override string BaseBloonId => "Bfb";
    public override int MinRound => 60;
    public override int MaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 80;
    public override int FortifiedMaxRound => -1;
}
