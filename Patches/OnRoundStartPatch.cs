using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Bridge;
using BTD_Mod_Helper;
using System.Threading;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public override void OnRoundStart() {
        if (InGame.instance == null || InGame.instance.bridge == null) { return; }
        InGame game = InGame.instance;
        if (game.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }
        //inGame.CheckAndShowHintMessage();
        //inGame.roundHintTxt.text = "Test message";

        if ((game.bridge.GetCurrentRound() + 1) % 20 == 0 && game.bridge.GetCurrentRound() != 0) {
            Thread t = new Thread(new ThreadStart(currentGame.roundGenerator.SpawnBloonsDelay));
            t.Start();
        } else {
            currentGame.canGainMoney = true;
        }
    }
}


[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.StartRound))]
static class RoundStartPatch {
    [HarmonyPrefix]
    private static bool Prefix(UnityToSimulation __instance) {
        return true;
        //return !BTD6Rogue.mod.currentGame.uiOpen;
    }
}