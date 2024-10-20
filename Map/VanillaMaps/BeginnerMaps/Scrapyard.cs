using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Scrapyard : RogueMap {

	public override string InternalName => "Scrapyard";
	public override string MapName => "Scrapyard";

	public override string MapImage => VanillaSprites.MapSelectScrapyardMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
