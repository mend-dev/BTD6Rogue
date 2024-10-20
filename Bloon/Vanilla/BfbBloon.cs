namespace BTD6Rogue;

public class BfbBloon : RogueBloon {
    public override string BaseBloonId => "Bfb";
    public override int StartRound => 60;
    public override int EndRound => -1;

	public override int BloonRbe => 3164;
	public override bool MoabClass => true;

	public override bool Fortified => true;
    public override int FortifiedStartRound => 80;
    public override int FortifiedEndRound => -1;
}
