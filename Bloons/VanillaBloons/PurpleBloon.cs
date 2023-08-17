namespace BTD6Rogue;

public class PurpleBloon : RogueBloon {
    public override string BaseBloonId => "Purple";
    public override int MinRound => 32;
    public override int MaxRound => -1;
    public override bool Camo => true;
    public override int CamoMinRound => 52;
    public override int CamoMaxRound => -1;
    public override bool Regrow => true;
    public override int RegrowMinRound => 44;
    public override int RegrowMaxRound => -1;
}
