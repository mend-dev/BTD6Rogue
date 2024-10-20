using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class BloodyPuddles : RogueMap {

	public override string InternalName => "BloodyPuddles";
	public override string MapName => "Bloody Puddles";

	public override string MapImage => VanillaSprites.MapSelectBloodyPuddlesButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
