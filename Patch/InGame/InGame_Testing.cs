/*using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;  

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.MatchReady))]
internal static class InGame_StartMatcasdh {

	[HarmonyPostfix]
	private static void Postfix(UnityToSimulation __instance) {
		InGame game = InGame.instance;
		BossBloonManager bbm = new BossBloonManager() {
			spawnRounds = new int[] { 20, 40, 60, 80, 100, 120 },
			currentBossTier = 0,
		};
		__instance.simulation.map.spawner.bossBloonManager = bbm;
		//bbm.Init(__instance.simulation);
	}
}
*/