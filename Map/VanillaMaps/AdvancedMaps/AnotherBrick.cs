using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class AnotherBrick : RogueMap {

	public override string InternalName => "AnotherBrick";
	public override string MapName => "Another Brick";

	public override string MapImage => VanillaSprites.MapSelectAnotherBrickButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Advanced;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
