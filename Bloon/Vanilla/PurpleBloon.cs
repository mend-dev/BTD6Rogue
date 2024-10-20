namespace BTD6Rogue;

public class PurpleBloon : RogueBloon {
    public override string BaseBloonId => "Purple";
    public override int StartRound => 32;
    public override int EndRound => -1;

	public override int BloonRbe => 11;

	public override bool Camo => true;
    public override int CamoStartRound => 52;
    public override int CamoEndRound => -1;
    public override bool Regrow => true;
    public override int RegrowStartRound => 44;
    public override int RegrowEndRound => -1;
}
