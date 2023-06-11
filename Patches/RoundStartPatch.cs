using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundStart))]
static class StartRoundPatch {
    [HarmonyPrefix]
    private static bool Prefix(InGame __instance) {
        return !BTD6Rogue.mod.uiOpen;
    }
}
