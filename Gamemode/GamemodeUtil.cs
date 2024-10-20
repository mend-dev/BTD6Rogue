using BTD_Mod_Helper.Api;
using System.Collections.Generic;

namespace BTD6Rogue;

// Static functions for handling RogueGamemode classes
public static class GamemodeUtil {

	// Checks if any given gamemode id is also a gamemode which inherents RogueGamemode
	public static bool IsRogueGamemode(string id) {
		List<RogueGamemode> rogueGamemodes = ModContent.GetContent<RogueGamemode>();
		foreach (RogueGamemode mode in rogueGamemodes) { if (mode.Id == id) { return true; } }
		return false;
	}

	public static RogueGamemode GetGamemodeById(string id) {
		foreach (RogueGamemode gamemode in ModContent.GetContent<RogueGamemode>()) {
			if (gamemode.Id == id) { return gamemode; }
		}
		return null!;
	}
}
