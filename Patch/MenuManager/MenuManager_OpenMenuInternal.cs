using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Menu;
using UnityEngine.SceneManagement;
using BTDMenuManager = Il2CppAssets.Scripts.Unity.Menu.MenuManager;
using Object = Il2CppSystem.Object;
using System;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;


// This patch required multiple days to create.
// Praise the patch for it allows menus OF THE SAME TYPE TO BE STACKED OVER EACHOTHER!!!
// TODO: Menus of the same type overwrite eachother in the stack making it so if you press the back button, in this case, it sends the user back to the main menu rather than the previous menu
// TODO: Delete Il2Cpp and obfuscation from existence
[HarmonyPatch(typeof(BTDMenuManager._OpenMenuInternal_d__53), nameof(BTDMenuManager._OpenMenuInternal_d__53.MoveNext))]
static class MenuManagerOpenMenuInternal54_MoveNext {
	[HarmonyPrefix]
	static void Prefix(BTDMenuManager._OpenMenuInternal_d__53 __instance) {
		bool isModdedMenu = false;
		ModMenuData mmd = null!;
		if (__instance.menuData != null) {
			if (__instance.menuData.TryCast<ModMenuData>() != null) {
				mmd = __instance.menuData.Cast<ModMenuData>();
				isModdedMenu = true;
			}
		}
		if (__instance.__1__state == 0 && isModdedMenu) {
			__instance.__1__state = 1;
			__instance.__8__1 = new BTDMenuManager.__c__DisplayClass53_0();
			__instance.__8__1.__4__this = __instance.__4__this;
			__instance.__8__1.previousMenu = __instance.__4__this.currMenu;

			Il2CppSystem.Collections.Generic.List<Il2CppSystem.ValueTuple<string, Object>> menuStack2 = __instance.__4__this.menuStack;
			menuStack2.Add(new Il2CppSystem.ValueTuple<string, Object>(__instance.menuName, __instance.menuData));

			Il2CppSystem.ValueTuple<string, GameMenu, BTDMenuManager.MenuStatus> newCurrMenu =
				new(__instance.menuName, null!, BTDMenuManager.MenuStatus.loading);

			__instance.__4__this.currMenu = newCurrMenu;

			__instance.__8__1._OpenMenuInternal_b__0();
		}
	}
	[HarmonyPostfix]
	static void Postfix(BTDMenuManager._OpenMenuInternal_d__53 __instance) {
		bool isModdedMenu = false;
		ModMenuData mmd = null!;
		if (__instance.menuData != null) {
			if (__instance.menuData.TryCast<ModMenuData>() != null) {
				mmd = __instance.menuData.Cast<ModMenuData>();
				isModdedMenu = true;
			}
		}
		if (__instance.__1__state == -1 && isModdedMenu) {
			string oldName = __instance.menuName;
			__instance.menuName = __instance.menuName + "-ModdedMenu" + mmd.id;

			Scene newScene = SceneManager.CreateScene(__instance.menuName, new CreateSceneParameters());
			Scene sceneFromName = SceneManager.GetSceneByName(oldName);
			SceneManager.MergeScenes(sceneFromName, newScene);

			__instance.__4__this.sceneInstanceDict[__instance.menuName] = __instance.__4__this.sceneInstanceDict[oldName];
			__instance.__4__this.sceneInstanceDict.Remove(oldName);

			Il2CppSystem.ValueTuple<string, GameMenu, BTDMenuManager.MenuStatus> currMenu = __instance.__4__this.currMenu;
			currMenu.Item1 = __instance.menuName;
			__instance.__4__this.currMenu = currMenu;

			Il2CppSystem.ValueTuple<string, Object> menuStackItem = __instance.__4__this.menuStack[__instance.__4__this.menuStack.Count - 1];
			menuStackItem.Item1 = __instance.menuName;
			__instance.__4__this.menuStack[__instance.__4__this.menuStack.Count - 1] = menuStackItem;
		}
	}
}