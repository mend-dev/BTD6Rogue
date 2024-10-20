using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Quit))]
internal static class InGame_Quit {
	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		if (BTD6Rogue.rogueGame != null) {
			BTD6Rogue.rogueGame = null!;
		}
	}
}
