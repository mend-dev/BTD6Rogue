using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Bazaar : RogueMap {

	public override string InternalName => "Bazaar";
	public override string MapName => "Bazaar";

	public override string MapImage => VanillaSprites.MapSelectBazaarButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
