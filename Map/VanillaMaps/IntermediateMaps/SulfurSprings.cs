using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class SulfurSprings : RogueMap {

	public override string InternalName => "SulfurSprings";
	public override string MapName => "Sulfur Springs";

	public override string MapImage => VanillaSprites.MapSelectSulfurSpringsButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
