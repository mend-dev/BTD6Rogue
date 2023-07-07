using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundStart))]
static class RoundStartPatch {
    [HarmonyPrefix]
    private static bool Prefix(InGame __instance) {
        if (BTD6Rogue.DisablePatchesInSandbox && __instance.bridge.IsSandboxMode()) { return true; }
        return !BTD6Rogue.mod.uiOpen;
    }
}
