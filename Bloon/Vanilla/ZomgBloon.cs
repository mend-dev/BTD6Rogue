namespace BTD6Rogue;

public class ZomgBloon : RogueBloon {
    public override string BaseBloonId => "Zomg";
    public override int StartRound => 80;
    public override int EndRound => -1;

	public override int BloonRbe => 16656;
	public override bool MoabClass => true;

	public override bool Fortified => true;
    public override int FortifiedStartRound => 100;
    public override int FortifiedEndRound => -1;
}
