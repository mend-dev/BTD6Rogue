using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class ProtectTheYacht : RogueMap {

	public override string InternalName => "ProtectTheYacht";
	public override string MapName => "Protect The Yacht";

	public override string MapImage => VanillaSprites.MapSelectProtectTheYachtMapButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => false;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
