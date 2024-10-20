namespace BTD6Rogue;

public class ZebraBloon : RogueBloon {
    public override string BaseBloonId => "Zebra";
    public override int StartRound => 31;
    public override int EndRound => -1;

	public override int BloonRbe => 23;

	public override bool Camo => true;
    public override int CamoStartRound => 45;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 39;
    public override int RegrowEndRound => -1;
}
