using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Lose))]
internal static class InGame_Lose {
	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		if (BTD6Rogue.rogueGame == null) { return; }
		if (BTD6Rogue.rogueGame.gameData.gameState != GameState.Won) { BTD6Rogue.rogueGame.gameData.gameState = GameState.Lost; }
	}
}
