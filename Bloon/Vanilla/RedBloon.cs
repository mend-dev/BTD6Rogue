namespace BTD6Rogue;

public class RedBloon : RogueBloon {
	public override string BaseBloonId => "Red";
	public override int StartRound => -999;
	public override int EndRound => 12;

	public override int BloonRbe => 1;

	public override bool Camo => true;
	public override int CamoStartRound => 18;
	public override int CamoEndRound => 24;

	public override bool Regrow => true;
	public override int RegrowStartRound => 8;
	public override int RegrowEndRound => 14;
}
