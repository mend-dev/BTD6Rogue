using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Track;

namespace BTD6Rogue;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.SpawnBoss))]
internal static class BossBloonManager_SpawnBoss {

	[HarmonyPostfix]
	private static bool Prefix(BossBloonManager __instance) {
		return false;
	}
}

