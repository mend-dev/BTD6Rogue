using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundEnd))]
static class RoundEndPatch {
    [HarmonyPostfix]
    private static void Postfix(InGame __instance, int completedRound, int highestCompletedRound) {
        // Make rounds randomized
        __instance.GetGameModel().roundSet.rounds[completedRound + 1] = BTD6Rogue.mod.roundGenerator.GetRandomRoundModel(__instance.GetGameModel().roundSet.rounds[completedRound + 1], completedRound + 1);

        // Tower choice every 10 rounds (starting at 5)
        if ((completedRound + 1) % 10 == 5) {
            __instance.bridge.SetAutoPlay(false);
            TowerChoicePanel.Create(__instance.uiRect, __instance);
        }

        // Hero choice every 40 rounds
        if ((completedRound + 1) % 40 == 0) {
            __instance.bridge.SetAutoPlay(false);
            HeroChoicePanel.Create(__instance.uiRect, __instance);
        }
    }
}