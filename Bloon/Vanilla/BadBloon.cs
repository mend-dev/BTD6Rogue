namespace BTD6Rogue;

public class BadBloon : RogueBloon {
    public override string BaseBloonId => "Bad";
    public override int StartRound => 100;
    public override int EndRound => -1;

	public override int BloonRbe => 55760;
	public override bool MoabClass => true;

	public override bool Fortified => true;
    public override int FortifiedStartRound => 120;
    public override int FortifiedEndRound => -1;
}
