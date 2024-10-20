using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Spillway : RogueMap {

	public override string InternalName => "Spillway";
	public override string MapName => "Spillway";

	public override string MapImage => VanillaSprites.MapSelectSpillwayButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Advanced;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
