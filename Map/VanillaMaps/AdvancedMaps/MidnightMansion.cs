using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class MidnightMansion : RogueMap {

	public override string InternalName => "MidnightMansion";
	public override string MapName => "Midnight Mansion";

	public override string MapImage => VanillaSprites.MapSelectMidnightMansionMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Advanced;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
