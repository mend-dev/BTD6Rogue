using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class TheCabin : RogueMap {

	public override string InternalName => "TheCabin";
	public override string MapName => "The Cabin";

	public override string MapImage => VanillaSprites.MapSelectTheCabinMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Beginner;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
