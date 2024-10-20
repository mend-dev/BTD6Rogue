using BTD_Mod_Helper.Api.Enums;

namespace BTD6Rogue;

public class RogueMode : RogueGamemode {
	public override string DisplayName => "Rogue";

	public override string Description => "BTD6 Rogue's original vision. A Gamemode that turns BTD6 into a completely new game!";

	public override string Portrait => VanillaSprites.PortraitContainerMilitary;
	public override string Image => GetSpriteReference<BTD6Rogue>("RogueModeImage").ToString();
}
