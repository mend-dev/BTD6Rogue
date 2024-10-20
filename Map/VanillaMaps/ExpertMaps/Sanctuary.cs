using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Sanctuary : RogueMap {

	public override string InternalName => "Sanctuary";
	public override string MapName => "Sanctuary";

	public override string MapImage => VanillaSprites.MapSelectSanctuaryMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
