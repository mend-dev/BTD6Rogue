using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Menu;
using UnityEngine.SceneManagement;
using BTDMenuManager = Il2CppAssets.Scripts.Unity.Menu.MenuManager;
using Object = Il2CppSystem.Object;
using System;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(BTDMenuManager._UnloadSceneAsync_d__36), nameof(BTDMenuManager._UnloadSceneAsync_d__36.MoveNext))]
static class LoadSceneAsync_MoveNexttttttttttttttttttttttttttttttttttttttt {
	[HarmonyPrefix]
	static void Prefix(BTDMenuManager._UnloadSceneAsync_d__36 __instance) {
		if (__instance.sceneName.Contains("ModdedMenu") && __instance.__1__state == 0) {
			__instance.__4__this.sceneInstanceDict.Remove(__instance.sceneName);
			Scene scene = SceneManager.GetSceneByName(__instance.sceneName);
			__instance.__2__current = SceneManager.UnloadSceneAsync(scene);
			__instance.__1__state = 1;
		}
	}
}