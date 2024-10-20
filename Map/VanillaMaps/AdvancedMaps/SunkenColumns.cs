using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class SunkenColumns : RogueMap {

	public override string InternalName => "SunkenColumns";
	public override string MapName => "Sunken Columns";

	public override string MapImage => VanillaSprites.MapSelectSunkenColumnsMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Advanced;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
