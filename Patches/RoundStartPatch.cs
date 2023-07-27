using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Bridge;
using System.Threading;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper;

namespace BTD6Rogue;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.StartRound))]
static class RoundStartPatch {
    [HarmonyPrefix]
    private static bool Prefix(UnityToSimulation __instance) {
        if (BTD6Rogue.DisablePatchesInSandbox && __instance.IsSandboxMode()) { return true; }

        return !BTD6Rogue.mod.uiOpen;
    }
}

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundStart))]
static class StartRoundPatch {
    [HarmonyPrefix]
    private static void Prefix(InGame __instance) {
        if ((__instance.bridge.GetCurrentRound() + 1) % 20 == 0) {
            //Thread t = new Thread(new ThreadStart(BTD6Rogue.mod.roundGenerator.SpawnBloonsDelay));
            //t.Start();
        } else {
            BTD6Rogue.mod.canGainMoney = true;
        }
    }
}
