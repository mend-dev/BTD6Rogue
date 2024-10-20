using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.CreateCurrentMapSave))]
internal static class InGame_CreateCurrentMapSave {
	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		if (BTD6Rogue.rogueGame == null) { return; }
		BTD6Rogue.rogueGame.SaveGame();
	}
}
