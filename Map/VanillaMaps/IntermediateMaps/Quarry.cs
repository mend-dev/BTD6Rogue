using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Quarry : RogueMap {

	public override string InternalName => "Quarry";
	public override string MapName => "Quarry";

	public override string MapImage => VanillaSprites.MapSelectQuarryMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
