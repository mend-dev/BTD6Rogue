using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Bloons;

namespace BTD6Rogue;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Degrade))]
internal static class Bloon_Degrade {
	[HarmonyPostfix]
	private static void Postfix(Bloon __instance) {
		if (__instance.bloonModel.isBoss) {
			BTD6Rogue.rogueGame.roundManager.BossDefeated();
		}
	}
}
