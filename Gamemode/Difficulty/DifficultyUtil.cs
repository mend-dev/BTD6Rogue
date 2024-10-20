using BTD_Mod_Helper.Api;

namespace BTD6Rogue;

public static class DifficultyUtil {
	// Todo: Figure out a better way to order these
	public static RogueDifficulty[] GetOrderedRogueDifficulties() {
		RogueDifficulty[] orderedDifficultyList = [
			ModContent.GetContent<PoppableDifficulty>()[0],
			ModContent.GetContent<EasyDifficulty>()[0],
			ModContent.GetContent<MediumDifficulty>()[0],
			ModContent.GetContent<HardDifficulty>()[0],
			ModContent.GetContent<ImpoppableDifficulty>()[0],
		];
		return orderedDifficultyList;
	}

	public static RogueDifficulty GetDifficultyById(string id) {
		foreach (RogueDifficulty difficulty in ModContent.GetContent<RogueDifficulty>()) {
			if (difficulty.Id == id) { return difficulty; }
		}
		return null!;
	}
}
