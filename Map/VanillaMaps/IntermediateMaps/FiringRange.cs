using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class FiringRange : RogueMap {

	public override string InternalName => "FiringRange";
	public override string MapName => "FiringRange";

	public override string MapImage => VanillaSprites.MapSelectFiringRangeButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
