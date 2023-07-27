using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.CashChanged))]
static class BloonPopPatch {

    static double lastCashValue;

    [HarmonyPrefix]
    private static void Prefix(InGame __instance) {
        if (BTD6Rogue.mod.canGainMoney) {
            lastCashValue = __instance.GetCash();
        }
    }

    [HarmonyPostfix]
    private static void Postfix(InGame __instance) {
        if (!BTD6Rogue.mod.canGainMoney) {
            //__instance.bridge.SetCash(lastCashValue);
        }
    }
}
