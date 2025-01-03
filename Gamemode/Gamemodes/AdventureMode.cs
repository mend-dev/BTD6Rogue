﻿using BTD_Mod_Helper.Api.Enums;

namespace BTD6Rogue;

public class AdventureMode : RogueGamemode {
	public override string DisplayName => "Adventure";

	public override string Description => "Coming Soon!";

	public override string Portrait => VanillaSprites.PortraitContainerMagic;
	public override string Image => GetSpriteReference<BTD6Rogue>("AdventureModeImage").ToString();
}
