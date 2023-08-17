namespace BTD6Rogue;

public class MoabBloon : RogueBloon {
    public override string BaseBloonId => "Moab";
    public override int MinRound => 40;
    public override int MaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 60;
    public override int FortifiedMaxRound => -1;
}
