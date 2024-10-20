using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class ParkPath : RogueMap {

	public override string InternalName => "ParkPath";
	public override string MapName => "Park Path";

	public override string MapImage => VanillaSprites.MapSelectParkPathButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
