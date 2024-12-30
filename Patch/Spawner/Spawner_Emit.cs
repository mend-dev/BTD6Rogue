using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System;

namespace BTD6Rogue;

[HarmonyPatch(typeof(Spawner), nameof(Spawner.Emit))]
internal static class Spawner_Emit {
	[HarmonyPrefix]
	private static void Prefix(Spawner __instance, ref BloonModel bloonModel, int roundNumber, int emissionIndex) {
        if (BTD6Rogue.rogueGame is null) { return; }
        if (bloonModel.isBoss || bloonModel.baseId.Contains("Lych") || bloonModel.IsRock) {
			BossUtil.GetBossFromBloonId(bloonModel.baseId).AdjustBloonModel(bloonModel, roundNumber / 20, false);
		}
	}

	[HarmonyPostfix]
	private static void Postfix(Spawner __instance, BloonModel bloonModel, int roundNumber, int emissionIndex, ref Bloon __result) {
		if (BTD6Rogue.rogueGame is not null)
		{
			if (bloonModel.isBoss || bloonModel.baseId.Contains("Lych") || bloonModel.IsRock)
			{
				RogueBoss boss = BossUtil.GetBossFromBloonId(bloonModel.baseId);
				boss.AdjustBloon(__result, roundNumber / 20, false);
				if (boss.IsBoss)
				{
					BTD6Rogue.rogueGame.roundManager.BossSpawned();
				}
			}

			if (emissionIndex >= 5000)
			{
				IncreaseBloonWorthModel.BloonWorthMutator bme = new IncreaseBloonWorthModel.BloonWorthMutator(
					"CashlessBloon", 0, 0, "");
				__result.AddMutator(bme, -1, false);
			}
		}

		if (bloonModel.isBoss)
        { //Todo: maybe don't do the BTD6Rogue-Boss UI in non BTD6Rogue GameModes?
            __instance.bossBloonManager.currentBoss = __result;
            __instance.bossBloonManager.currentBossTier = Math.Min(((roundNumber + 1) / 20), 5);
		}

	}
}
