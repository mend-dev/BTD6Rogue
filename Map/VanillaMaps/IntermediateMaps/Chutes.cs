using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Chutes : RogueMap {

	public override string InternalName => "Chutes";
	public override string MapName => "Chutes";

	public override string MapImage => VanillaSprites.MapSelectChutesButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
