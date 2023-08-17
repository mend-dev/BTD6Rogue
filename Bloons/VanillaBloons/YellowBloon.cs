namespace BTD6Rogue;

public class YellowBloon : RogueBloon {
    public override string BaseBloonId => "Yellow";
    public override int MinRound => 9;
    public override int MaxRound => 23;
    public override bool Camo => true;
    public override int CamoMinRound => 24;
    public override int CamoMaxRound => 30;
    public override bool Regrow => true;
    public override int RegrowMinRound => 14;
    public override int RegrowMaxRound => 20;
}
