namespace BTD6Rogue;

public class BlueBloon : RogueBloon {
    public override string BaseBloonId => "Blue";
    public override int StartRound => 3;
    public override int EndRound => 14;

	public override int BloonRbe => 2;

	public override bool Camo => true;
    public override int CamoStartRound => 20;
    public override int CamoEndRound => 26;
    public override bool Regrow => true;
    public override int RegrowStartRound => 10;
    public override int RegrowEndRound => 16;
}
