using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Track;

namespace BTD6Rogue;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.OnRoundStart))]
internal static class BossBloonManager_OnRoundStart {

	[HarmonyPostfix]
	private static bool Prefix(BossBloonManager __instance, int spawnedRound) {
		if (__instance.GetNextBossSpawnRound().Value != spawnedRound) { return true; }
		return false;
	}
}

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.SpawnBoss))]
internal static class BossBloonManager_SpawnBoss {

	[HarmonyPostfix]
	private static bool Prefix(BossBloonManager __instance) {
		return false;
	}
}

