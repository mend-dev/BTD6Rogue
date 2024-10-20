using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Blons : RogueMap {

	public override string InternalName => "Blons";
	public override string MapName => "Blons";

	public override string MapImage => VanillaSprites.MapSelectBlonsMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
