using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class MoonLanding : RogueMap {

	public override string InternalName => "MoonLanding";
	public override string MapName => "Moon Landing";

	public override string MapImage => VanillaSprites.MapSelectMoonLandingButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
