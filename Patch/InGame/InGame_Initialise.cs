using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem;
using Il2CppSystem.Collections;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Initialise))]
internal static class InGame_Initialise {

	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		IEnumerator enumer = __instance.InstantiateUiObject(__instance.inGameMenuDefs[15]);
		enumer.MoveNext();
		enumer.MoveNext();
	}
}
