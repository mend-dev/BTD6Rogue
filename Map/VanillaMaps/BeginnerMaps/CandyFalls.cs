using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class CandyFalls : RogueMap {

	public override string InternalName => "Candyfalls";
	public override string MapName => "Candy Falls";

	public override string MapImage => VanillaSprites.MapSelectCandyfallsButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
