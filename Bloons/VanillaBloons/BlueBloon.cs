namespace BTD6Rogue;

public class BlueBloon : RogueBloon {
    public override string BaseBloonId => "Blue";
    public override int MinRound => 3;
    public override int MaxRound => 14;
    public override bool Camo => true;
    public override int CamoMinRound => 20;
    public override int CamoMaxRound => 26;
    public override bool Regrow => true;
    public override int RegrowMinRound => 10;
    public override int RegrowMaxRound => 16;
}
