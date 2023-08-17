namespace BTD6Rogue;

public class CeramicBloon : RogueBloon {
    public override string BaseBloonId => "Ceramic";
    public override int MinRound => 39;
    public override int MaxRound => -1;
    public override bool Camo => true;
    public override int CamoMinRound => 62;
    public override int CamoMaxRound => -1;
    public override bool Regrow => true;
    public override int RegrowMinRound => 47;
    public override int RegrowMaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 56;
    public override int FortifiedMaxRound => -1;
}
