namespace BTD6Rogue;

public class RedBloon : RogueBloon {
    public override string BaseBloonId => "Red";
    public override int MinRound => -999;
    public override int MaxRound => 12;
    public override bool Camo => true;
    public override int CamoMinRound => 18;
    public override int CamoMaxRound => 24;
    public override bool Regrow => true;
    public override int RegrowMinRound => 8;
    public override int RegrowMaxRound => 14;
}
