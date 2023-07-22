using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Restart))]
static class RestartGamePatch {
    [HarmonyPostfix]
    private static void Postfix(InGame __instance) {
        if (BTD6Rogue.DisablePatchesInSandbox && __instance.bridge.IsSandboxMode()) { return; }
        BTD6Rogue.mod.StartRogueGame(__instance);
    }
}