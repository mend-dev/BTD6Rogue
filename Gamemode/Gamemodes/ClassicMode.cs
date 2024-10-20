using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models;
using MelonLoader;

namespace BTD6Rogue;

public class ClassicMode : RogueGamemode {
	public override string DisplayName => "Classic";

	public override bool Enabled => true;

	public override string Description => "The original BTD6 Rogue experience! Towers, Heroes, Bosses, and lots of Bloons!";

	public override string Portrait => VanillaSprites.PortraitContainerPrimary;
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();
}
