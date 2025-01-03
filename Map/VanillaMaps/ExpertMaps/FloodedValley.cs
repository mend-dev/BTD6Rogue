﻿using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public class FloodedValley : RogueMap {

	public override string InternalName => "FloodedValley";
	public override string MapName => "Flooded Valley";

	public override string MapImage => VanillaSprites.MapSelectFloodedValleyButton;

	public override MapDifficulty GameDifficulty => MapDifficulty.Expert;
	public override int RogueDifficulty => 0;

	public override bool Water => true;

	public override float[] TrackLengths => [0f];
	public override int[] TrackTypes => [0];
}
