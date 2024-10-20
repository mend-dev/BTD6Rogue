using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Races;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem;
using Il2CppSystem.Collections;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
internal static class InGame_StartMatch {

	[HarmonyPostfix]
	private static void Postfix(InGame __instance, MapSaveDataModel mapSaveData, bool wasSaveOverwritten) {
		if (BTD6Rogue.rogueGame == null) { return; }
		__instance.bridge.simulation.bossSpawnRounds = new int[] { 19, 39, 59, 79, 99, 119, 139, 159, 179, 199, 219, 239, 259, 279, 299 };
		__instance.bridge.simulation.model.bossBloonType = "Bloonarius";
		__instance.bridge.simulation.model.bossEliteMode = false;
		BossBloonManager bbm = new BossBloonManager();
		__instance.bridge.simulation.map.spawner.bossBloonManager = bbm;
		bbm.Init(__instance.bridge.simulation);

		Transform transform = __instance.GetInGameUI().transform.FindChildWithName("BossUi(Clone)");
		BossUI bossUi = transform.GetComponent<BossUI>();
		bossUi.Hide();

		BTD6Rogue.rogueGame.gameData.gameState = GameState.Loaded;
		if (mapSaveData != null) {
			BTD6Rogue.rogueGame.GameLoaded(__instance);
		} else {
			BTD6Rogue.rogueGame.GameStarted(__instance);
		}
	}
}


[HarmonyPatch(typeof(InGame), nameof(InGame.Initialise))]
internal static class InGame_StartMatcah {

	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		IEnumerator enumer = __instance.InstantiateUiObject(__instance.inGameMenuDefs[15]);
		enumer.MoveNext();
		enumer.MoveNext();
	}
}
