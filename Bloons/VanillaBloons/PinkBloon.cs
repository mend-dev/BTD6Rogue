namespace BTD6Rogue;

public class PinkBloon : RogueBloon {
    public override string BaseBloonId => "Pink";
    public override int MinRound => 14;
    public override int MaxRound => 30;
    public override bool Camo => true;
    public override int CamoMinRound => 26;
    public override int CamoMaxRound => 32;
    public override bool Regrow => true;
    public override int RegrowMinRound => 16;
    public override int RegrowMaxRound => 22;
}
