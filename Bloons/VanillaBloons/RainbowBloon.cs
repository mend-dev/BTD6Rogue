namespace BTD6Rogue;

public class RainbowBloon : RogueBloon {
    public override string BaseBloonId => "Rainbow";
    public override int MinRound => 36;
    public override int MaxRound => -1;
    public override bool Camo => true;
    public override int CamoMinRound => 55;
    public override int CamoMaxRound => -1;
    public override bool Regrow => true;
    public override int RegrowMinRound => 48;
    public override int RegrowMaxRound => -1;
}
