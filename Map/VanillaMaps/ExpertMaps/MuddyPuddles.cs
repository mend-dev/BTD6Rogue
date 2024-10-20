using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class MuddyPuddles : RogueMap {

	public override string InternalName => "MuddyPuddles";
	public override string MapName => "Muddy Puddles";

	public override string MapImage => VanillaSprites.MapSelectMuddyPuddlesButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
