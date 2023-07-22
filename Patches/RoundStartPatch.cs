using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Bridge;

namespace BTD6Rogue;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.StartRound))]
static class RoundStartPatch {
    [HarmonyPrefix]
    private static bool Prefix(UnityToSimulation __instance) {
        if (BTD6Rogue.DisablePatchesInSandbox && __instance.IsSandboxMode()) { return true; }
        return !BTD6Rogue.mod.uiOpen;
    }
}
