namespace BTD6Rogue;

public class WhiteBloon : RogueBloon {
    public override string BaseBloonId => "White";
    public override int StartRound => 18;
    public override int EndRound => 39;

	public override int BloonRbe => 11;

	public override bool Camo => true;
    public override int CamoStartRound => 28;
    public override int CamoEndRound => 34;
    public override bool Regrow => true;
    public override int RegrowStartRound => 18;
    public override int RegrowEndRound => 24;
}
