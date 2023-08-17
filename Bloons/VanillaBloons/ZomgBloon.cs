namespace BTD6Rogue;

public class ZomgBloon : RogueBloon {
    public override string BaseBloonId => "Zomg";
    public override int MinRound => 80;
    public override int MaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 100;
    public override int FortifiedMaxRound => -1;
}
