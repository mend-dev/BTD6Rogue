namespace BTD6Rogue;

public class GreenBloon : RogueBloon {
    public override string BaseBloonId => "Green";
    public override int MinRound => 6;
    public override int MaxRound => 18;
    public override bool Camo => true;
    public override int CamoMinRound => 22;
    public override int CamoMaxRound => 28;
    public override bool Regrow => true;
    public override int RegrowMinRound => 12;
    public override int RegrowMaxRound => 18;
}
