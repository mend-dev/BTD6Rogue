using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class CoveredGarden : RogueMap {

	public override string InternalName => "CoveredGarden";
	public override string MapName => "Covered Garden";

	public override string MapImage => VanillaSprites.MapSelectCoveredGardenMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
