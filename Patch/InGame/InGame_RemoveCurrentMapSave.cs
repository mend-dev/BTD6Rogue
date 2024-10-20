using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RemoveCurrentMapSave))]
internal static class InGame_RemoveCurrentMapSave {
	[HarmonyPostfix]
	private static void Postfix(InGame __instance, ref bool canClearCheckpoints) {
		if (BTD6Rogue.rogueGame == null) { return; }
		if (canClearCheckpoints) {
			BTD6Rogue.rogueGame.EndGame();
		}
	}
}
