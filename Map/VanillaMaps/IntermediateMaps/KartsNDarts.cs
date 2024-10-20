using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class KartsNDarts : RogueMap {

	public override string InternalName => "KartsNDarts";
	public override string MapName => "KartsNDarts";

	public override string MapImage => VanillaSprites.MapSelectKartsNDarts;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
