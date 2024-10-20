using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Bridge;

namespace BTD6Rogue;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.StartRound))]
internal static class UnityToSimulation_StartRound {
	[HarmonyPrefix]
	private static bool Prefix(UnityToSimulation __instance) {
		if (__instance == null) { return true; }
		if (BTD6Rogue.rogueGame == null) { return true; }
		if (BTD6Rogue.rogueGame.encounterManager == null) { return true; }
		return BTD6Rogue.rogueGame.encounterManager.currentEncounter == null;
	}
}
