namespace BTD6Rogue;

public class DdtBloon : RogueBloon {
    public override string BaseBloonId => "Ddt";
    public override int MinRound => 90;
    public override int MaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 110;
    public override int FortifiedMaxRound => -1;
}
