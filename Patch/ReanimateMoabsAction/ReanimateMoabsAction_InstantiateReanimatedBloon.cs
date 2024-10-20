using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

[HarmonyPatch(typeof(ReanimateMoabsAction), nameof(ReanimateMoabsAction.InstantiateReanimatedBloon))]
internal static class ReanimateMoabsAction_InstantiateReanimatedBloon {
	[HarmonyPrefix]
	private static void Prefix(ReanimateMoabsAction __instance, ref BloonModel bloonModel) {
		if (bloonModel.baseId.ToLower().Contains("minilych")) {
			BossUtil.GetBossFromBloonId(bloonModel.baseId).AdjustBloonModel(bloonModel, InGame.instance.bridge.GetCurrentRound() / 20, false);
		}
	}

	[HarmonyPostfix]
	private static void Postfix(Spawner __instance, BloonModel bloonModel, ref Bloon __result) {
		if (bloonModel.baseId.ToLower().Contains("minilych")) {
			BossUtil.GetBossFromBloonId(bloonModel.baseId).AdjustBloon(__result, InGame.instance.bridge.GetCurrentRound() / 20, false);
		}
	}
}
