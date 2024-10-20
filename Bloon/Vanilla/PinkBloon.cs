namespace BTD6Rogue;

public class PinkBloon : RogueBloon {
    public override string BaseBloonId => "Pink";
    public override int StartRound => 14;
    public override int EndRound => 30;

	public override int BloonRbe => 5;

	public override bool Camo => true;
    public override int CamoStartRound => 26;
    public override int CamoEndRound => 32;
    public override bool Regrow => true;
    public override int RegrowStartRound => 16;
    public override int RegrowEndRound => 22;
}
