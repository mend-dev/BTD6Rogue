using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class TreeStump : RogueMap {

	public override string InternalName => "TreeStump";
	public override string MapName => "Tree Stump";

	public override string MapImage => VanillaSprites.MapSelectTreeStumpButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
