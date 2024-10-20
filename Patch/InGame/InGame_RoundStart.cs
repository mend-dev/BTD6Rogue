using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundStart))]
internal static class InGame_RoundStart {

	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		if (__instance == null || __instance.bridge == null) { return; }
        if (BTD6Rogue.rogueGame == null) { return; }
	}
}