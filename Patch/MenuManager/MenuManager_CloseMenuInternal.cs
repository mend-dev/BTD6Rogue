using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Menu;
using UnityEngine.SceneManagement;
using BTDMenuManager = Il2CppAssets.Scripts.Unity.Menu.MenuManager;
using Object = Il2CppSystem.Object;
using System;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(BTDMenuManager._CloseCurrentMenuInternal_d__57), nameof(BTDMenuManager._CloseCurrentMenuInternal_d__57.MoveNext))]
static class CloseCur {
	[HarmonyPrefix]
	static void Prefix(BTDMenuManager._CloseCurrentMenuInternal_d__57 __instance, out string __state) {
		__state = __instance._menuName_5__2;
		Il2CppSystem.ValueTuple<string, Object> lastStackedMenu = __instance.__4__this.menuStack[__instance.__4__this.menuStack.Count - 1];

		if (__instance.__1__state == 0 && lastStackedMenu.Item1.Contains("ModdedMenu")) {
			__instance.__8__1 = new BTDMenuManager.__c__DisplayClass57_0();
			__instance.__8__1.__4__this = __instance.__4__this;
			__instance.__4__this.IsClosingOrOpeningMenu = true;
			__instance.__8__1.closingMenu = __instance.__4__this.currMenu;

			__instance.__4__this.SetCanvasGroupInteractable(__instance.__8__1.closingMenu.Item2.gameObject, false);

			Il2CppSystem.Action action = new Action(__instance.__8__1._CloseCurrentMenuInternal_b__0).ToIl2CppSystemAction();
			__instance.__8__1.closingMenu.Item2.PlayAnim(1, action);
			__instance.__4__this.menuStack.RemoveAt(__instance.__4__this.menuStack.Count - 1);

			lastStackedMenu = __instance.__4__this.menuStack[__instance.__4__this.menuStack.Count - 1];
			__instance._menuData_5__3 = lastStackedMenu.Item2;
			__instance._menuName_5__2 = lastStackedMenu.Item1;

			Il2CppSystem.ValueTuple<string, GameMenu, BTDMenuManager.MenuStatus> newCurrMenu =
				new(__instance._menuName_5__2, null!, BTDMenuManager.MenuStatus.loading);

			__instance.__4__this.currMenu = newCurrMenu;

			Il2CppSystem.Collections.IEnumerator enumerator = __instance.__4__this.EnsureCorrectWorldScene(__instance.__4__this.menuStack);
			__instance.__2__current = enumerator.Current;
			__instance.__1__state = 9;
		}

		if (__instance.__1__state == 12 && __instance._menuName_5__2 != null && __instance._menuName_5__2.Contains("ModdedMenu")) {
			__state = __instance._menuName_5__2;
			__instance._menuName_5__2 = __state.Split("-")[0];
		}
	}
	[HarmonyPostfix]
	static void Postfix(BTDMenuManager._CloseCurrentMenuInternal_d__57 __instance, string __state) {
		if (__state != null && __state.Contains("ModdedMenu") && __instance.__4__this.menuStack.Count > 1) {
			string oldName = __state.Split("-")[0];

			Scene newScene = SceneManager.CreateScene(__state, new CreateSceneParameters());
			Scene sceneFromName = SceneManager.GetSceneByName(oldName);
			SceneManager.MergeScenes(sceneFromName, newScene);

			__instance.__4__this.sceneInstanceDict[__state] = __instance.__4__this.sceneInstanceDict[oldName];
			__instance.__4__this.sceneInstanceDict.Remove(oldName);

			Il2CppSystem.ValueTuple<string, GameMenu, BTDMenuManager.MenuStatus> currMenu = __instance.__4__this.currMenu;
			currMenu.Item1 = __state;
			__instance.__4__this.currMenu = currMenu;

			Il2CppSystem.ValueTuple<string, Object> menuStackItem = __instance.__4__this.menuStack[__instance.__4__this.menuStack.Count - 1];
			menuStackItem.Item1 = __state;
			__instance.__4__this.menuStack[__instance.__4__this.menuStack.Count - 1] = menuStackItem;
		}
	}
}