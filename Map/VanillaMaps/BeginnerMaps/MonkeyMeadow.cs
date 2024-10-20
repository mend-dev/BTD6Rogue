using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class MonkeyMeadow : RogueMap {
	public override string InternalName => "Tutorial";
	public override string MapName => "Monkey Meadow";

	public override string MapImage => VanillaSprites.MapSelectMonkeyMeadowButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
