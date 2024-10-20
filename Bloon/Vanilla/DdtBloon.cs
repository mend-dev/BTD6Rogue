namespace BTD6Rogue;

public class DdtBloon : RogueBloon {
    public override string BaseBloonId => "Ddt";
    public override int StartRound => 90;
    public override int EndRound => -1;

	public override int BloonRbe => 816;
	public override bool MoabClass => true;

	public override bool Fortified => true;
    public override int FortifiedStartRound => 110;
    public override int FortifiedEndRound => -1;
}
