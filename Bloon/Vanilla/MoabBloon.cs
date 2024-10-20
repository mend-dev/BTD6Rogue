namespace BTD6Rogue;

public class MoabBloon : RogueBloon {
    public override string BaseBloonId => "Moab";
    public override int StartRound => 40;
    public override int EndRound => -1;

	public override int BloonRbe => 616;
	public override bool MoabClass => true;

	public override bool Fortified => true;
    public override int FortifiedStartRound => 60;
    public override int FortifiedEndRound => -1;
}
