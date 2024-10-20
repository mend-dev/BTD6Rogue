using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Restart))]
internal static class InGame_Restart {
	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		if (BTD6Rogue.rogueGame == null) { return; }
		BTD6Rogue.rogueGame.gameData.gameState = GameState.Lost;
		BTD6Rogue.rogueGame.EndGame();
		BTD6Rogue.rogueGame.RestartGame();
	}
}
