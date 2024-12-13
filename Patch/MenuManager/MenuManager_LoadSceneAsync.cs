using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Menu;
using UnityEngine.SceneManagement;
using BTDMenuManager = Il2CppAssets.Scripts.Unity.Menu.MenuManager;
using Object = Il2CppSystem.Object;
using System;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(BTDMenuManager._LoadSceneAsync_d__34), nameof(BTDMenuManager._LoadSceneAsync_d__34.MoveNext))]
static class LoadSceneAsync_MoveNext {
	[HarmonyPrefix]
	static void Prefix(BTDMenuManager._LoadSceneAsync_d__34 __instance, out string __state) {
		__state = __instance.sceneName;
		if (__instance.__1__state == 0 && __instance.sceneName.Contains("ModdedMenu")) {
			string oldName = __instance.sceneName.Split("-")[0];


			__instance.sceneName = oldName;
		}
	}

	[HarmonyPostfix]
	static void PostFix(BTDMenuManager._LoadSceneAsync_d__34 __instance, string __state) {
		if (__instance.__1__state == -1 && __state.Contains("ModdedMenu")) {
			Scene newScene = SceneManager.CreateScene(__state, new CreateSceneParameters());
			Scene sceneFromName = SceneManager.GetSceneByName(__instance.sceneName);
			SceneManager.MergeScenes(sceneFromName, newScene);
		}
	}
}