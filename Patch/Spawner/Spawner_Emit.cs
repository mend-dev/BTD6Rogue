using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using System;

namespace BTD6Rogue;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.Emit))]
internal static class Spawner_Emit {
	[HarmonyPrefix]
	private static void Prefix(Spawner __instance, ref BloonModel bloonModel, int roundNumber, int emissionIndex) {
		if (bloonModel.isBoss || bloonModel.baseId.Contains("Lych") || bloonModel.IsRock) {
			BossUtil.GetBossFromBloonId(bloonModel.baseId).AdjustBloonModel(bloonModel, roundNumber / 20, false);
		}
	}

	[HarmonyPostfix]
	private static void Postfix(Spawner __instance, BloonModel bloonModel, int roundNumber, int emissionIndex, ref Bloon __result) {
		if (bloonModel.isBoss || bloonModel.baseId.Contains("Lych") || bloonModel.IsRock) {
			RogueBoss boss = BossUtil.GetBossFromBloonId(bloonModel.baseId);
			boss.AdjustBloon(__result, roundNumber / 20, false);
			if (boss.IsBoss) {
				BTD6Rogue.rogueGame.roundManager.BossSpawned();
			}
		}

		if (emissionIndex >= 5000) {
			IncreaseBloonWorthModel.BloonWorthMutator bme = new IncreaseBloonWorthModel.BloonWorthMutator(
				"CashlessBloon", 0, 0, "");
			__result.AddMutator(bme, -1, false);
		}

		if (bloonModel.isBoss) {
			__instance.bossBloonManager.currentBoss = __result;
			__instance.bossBloonManager.currentBossTier = Math.Min(((roundNumber + 1) / 20), 5);
		}

	}
}

[HarmonyPatch(typeof(SpawnChildren), nameof(SpawnChildren.CreatedChildren))]
internal static class Spawner_Emasddsit {
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
