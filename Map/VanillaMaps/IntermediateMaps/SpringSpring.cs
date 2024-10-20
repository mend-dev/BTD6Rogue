using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class SpringSpring : RogueMap {

	public override string InternalName => "SpringSpring";
	public override string MapName => "SpringSpring";

	public override string MapImage => VanillaSprites.MapSelectSpringSpringButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
