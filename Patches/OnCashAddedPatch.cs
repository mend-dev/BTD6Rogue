using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static Il2CppAssets.Scripts.Simulation.Simulation;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {

    public override void OnCashAdded(double amount, CashType from, int cashIndex, CashSource source, Tower tower) {
        if (InGame.instance == null || InGame.instance.bridge == null) { return; }
        InGame inGame = InGame.instance;
        if (inGame.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }

        if (source == CashSource.Normal && from == CashType.Normal && !currentGame.canGainMoney) {
            inGame.SetCash(inGame.GetCash() - amount);
        }
    }
}
