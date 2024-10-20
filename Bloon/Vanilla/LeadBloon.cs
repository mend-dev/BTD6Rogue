namespace BTD6Rogue;

public class LeadBloon : RogueBloon {
    public override string BaseBloonId => "Lead";
    public override int StartRound => 28;
    public override int EndRound => -1;

	public override int BloonRbe => 23;

	public override bool Camo => true;
    public override int CamoStartRound => 57;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 46;
    public override int RegrowEndRound => -1;
    public override bool Fortified => true;
    public override int FortifiedStartRound => 51;
    public override int FortifiedEndRound => -1;
}
