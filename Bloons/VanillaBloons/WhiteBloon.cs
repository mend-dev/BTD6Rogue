namespace BTD6Rogue;

public class WhiteBloon : RogueBloon {
    public override string BaseBloonId => "White";
    public override int MinRound => 18;
    public override int MaxRound => 39;
    public override bool Camo => true;
    public override int CamoMinRound => 28;
    public override int CamoMaxRound => 34;
    public override bool Regrow => true;
    public override int RegrowMinRound => 18;
    public override int RegrowMaxRound => 24;
}
