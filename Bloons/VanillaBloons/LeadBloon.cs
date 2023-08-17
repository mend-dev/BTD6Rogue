namespace BTD6Rogue;

public class LeadBloon : RogueBloon {
    public override string BaseBloonId => "Lead";
    public override int MinRound => 28;
    public override int MaxRound => -1;
    public override bool Camo => true;
    public override int CamoMinRound => 57;
    public override int CamoMaxRound => -1;
    public override bool Regrow => true;
    public override int RegrowMinRound => 46;
    public override int RegrowMaxRound => -1;
    public override bool Fortified => true;
    public override int FortifiedMinRound => 51;
    public override int FortifiedMaxRound => -1;
}
