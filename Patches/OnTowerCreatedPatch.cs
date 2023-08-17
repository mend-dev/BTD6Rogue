using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {

    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse) {
        if (InGame.instance == null || InGame.instance.bridge == null) { return; }
        InGame inGame = InGame.instance;
        if (inGame.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }

        foreach (KeyValuePair<string, ArtifactGameData> artifact in currentGame.activeArtifacts) {
            if (artifact.Value.artifactRange == ArtifactRange.Local) { continue; }
            artifact.Value.baseArtifact.OnPlaceTower(inGame, tower);
        }
    }
}
