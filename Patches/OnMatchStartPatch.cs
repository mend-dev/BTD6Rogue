using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public override void OnMatchStart() {
        if (InGame.instance == null || InGame.instance.bridge == null) { return; }
        InGame game = InGame.instance;
        if (game.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }

        if (DisablePatchesInSandbox && game.bridge.IsSandboxMode()) { return; }

        if (game.bridge.GetCurrentRound() > 0) {
            LoadRogueGame(game);
        } else {
            StartRogueGame(game);
        }
    }
}
