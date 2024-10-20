namespace BTD6Rogue;

public class RainbowBloon : RogueBloon {
    public override string BaseBloonId => "Rainbow";
    public override int StartRound => 36;
    public override int EndRound => -1;

	public override int BloonRbe => 47;

	public override bool Camo => true;
    public override int CamoStartRound => 55;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 48;
    public override int RegrowEndRound => -1;
}
