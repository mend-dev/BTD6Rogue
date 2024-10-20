namespace BTD6Rogue;

public class GreenBloon : RogueBloon {
    public override string BaseBloonId => "Green";
    public override int StartRound => 6;
    public override int EndRound => 18;

	public override int BloonRbe => 3;

	public override bool Camo => true;
    public override int CamoStartRound => 22;
    public override int CamoEndRound => 28;
    public override bool Regrow => true;
    public override int RegrowStartRound => 12;
    public override int RegrowEndRound => 18;
}
