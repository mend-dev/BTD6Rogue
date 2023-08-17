namespace BTD6Rogue;

public class ZebraBloon : RogueBloon {
    public override string BaseBloonId => "Zebra";
    public override int MinRound => 31;
    public override int MaxRound => -1;
    public override bool Camo => true;
    public override int CamoMinRound => 45;
    public override int CamoMaxRound => -1;
    public override bool Regrow => true;
    public override int RegrowMinRound => 39;
    public override int RegrowMaxRound => -1;
}
