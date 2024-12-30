using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;

namespace BTD6Rogue;

[HarmonyPatch(typeof(SpawnChildren), nameof(SpawnChildren.CreatedChildren))]
internal static class SpawnChildren_CreatedChildren {
	[HarmonyPostfix]
	private static void Postfix(SpawnChildren __instance, List<Bloon> childernCreatedIn) {
		if (__instance.bloon.emissionIndex >= 5000) {
			foreach (Bloon bloon in childernCreatedIn) {
				IncreaseBloonWorthModel.BloonWorthMutator bme = new IncreaseBloonWorthModel.BloonWorthMutator(
					"CashlessBloon", 0, 0, "");
				bloon.AddMutator(bme, -1, false);
			}
		}

	}
}
