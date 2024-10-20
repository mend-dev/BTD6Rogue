using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class QuietStreet : RogueMap {

	public override string InternalName => "QuietSteet";
	public override string MapName => "Quiet Street";

	public override string MapImage => VanillaSprites.MapSelectQuietSteetMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
