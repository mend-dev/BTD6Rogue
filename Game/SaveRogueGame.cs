using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {

    public void SaveRogueGame(InGame game) {
        // currentGame

        double currentRound = game.bridge.GetCurrentRound();
        double currentCash = game.GetCash();
        double currentHealth = game.GetHealth();
        double maxHealth = game.GetMaxHealth();
    }
}
