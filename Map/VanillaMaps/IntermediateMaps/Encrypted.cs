using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class Encrypted : RogueMap {

	public override string InternalName => "Encrypted";
	public override string MapName => "Encrypted";

	public override string MapImage => VanillaSprites.MapSelectEncryptedButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Intermediate;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
