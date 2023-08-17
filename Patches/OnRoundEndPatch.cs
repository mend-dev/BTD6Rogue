using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using System;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public override void OnRoundEnd() {
        if (InGame.instance == null || InGame.instance.bridge == null) { return; }
        InGame inGame = InGame.instance;
        if (inGame.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }
        if (DisablePatchesInSandbox && inGame.bridge.IsSandboxMode()) { return; }

        //foreach (KeyValuePair<string, ArtifactGameData> artifact in currentGame.activeArtifacts) {
        //    if (artifact.Value.artifactLength == ArtifactLength.Temp) { artifact.Value.timer--; }
        //    if (artifact.Value.timer < 1) { artifact.Value.baseArtifact.OnArtifactExpire(inGame); currentGame.activeArtifacts.Remove(artifact.Key); }
        //    artifact.Value.baseArtifact.OnRoundEnd(inGame);
        //}

        int round = inGame.bridge.GetCurrentRound();

        // Make rounds randomized
        if (RandomRounds) {
            inGame.GetGameModel().roundSet.rounds[round + 1] = currentGame.roundGenerator.GetRandomRoundModel(inGame.GetGameModel().roundSet.rounds[round + 1], round + 1);
        }

        if ((round + 1) % 20 == 1) {
            int bossInt = new Random().Next(currentGame.availableBosses.Count);
            currentGame.roundGenerator.nextBoss = currentGame.availableBosses[bossInt];
            string bossHint = BossUtil.GetBossHint(currentGame.roundGenerator.nextBoss);
            Game.instance.ShowMessage(bossHint, 20f);
        }

        // Tower choice every 10 rounds (starting at 5)
        if ((round + 1 - TowersStartAtRound) >= 0 && (round + 1 - TowersStartAtRound) % RoundsPerRandomTower == 0 && RandomTowers) {
            inGame.bridge.SetAutoPlay(false);
            if (currentGame.rerolls < 3) { currentGame.rerolls++; }
            currentGame.panelManager.AddPanelToQueue(inGame.uiRect, inGame, nameof(TowerChoicePanel));
        }

        if ((round + 1) % 90 == 0) {
            inGame.bridge.SetAutoPlay(false);
            currentGame.panelManager.AddPanelToQueue(inGame.uiRect, inGame, nameof(ParagonChoicePanel));
        }

        // Hero choice every 40 rounds
        if ((round + 1 - HeroesStartAtRound) >= 0 && (round + 1 - HeroesStartAtRound) % RoundsPerRandomHero == 0 && MultipleHeroes) {
            inGame.bridge.SetAutoPlay(false);
            currentGame.panelManager.AddPanelToQueue(inGame.uiRect, inGame, nameof(HeroChoicePanel));
        }

        // Artifact choice every 15 rounds
        //if ((round + 1) % 20 == 10) {
        //    inGame.bridge.SetAutoPlay(false);
        //    currentGame.panelManager.AddPanelToQueue(inGame.uiRect, inGame, nameof(ArtifactChoicePanel));
        //}
    }
}
