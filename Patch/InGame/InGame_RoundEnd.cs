using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Races;
using System.Linq;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Data.Boss;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundEnd))]
internal static class InGame_RoundEnd {

	[HarmonyPostfix]
	private static void Postfix(InGame __instance) {
		if (__instance == null || __instance.bridge == null) { return; }
        if (BTD6Rogue.rogueGame == null) { return; }

        InGame game = __instance;

        // Generate a random round for the next round when the current round ends
		int round = game.bridge.GetCurrentRound();

        BTD6Rogue.rogueGame.roundManager.GenerateRound(round + 1, true);

		if (new int[] { 9, 29, 49, 69, 89, 109, 129, 149, 169, 189, 209, 229, 249, 269, 289, 309 }.Contains(round)) {
			string nextBoss = BTD6Rogue.rogueGame.roundManager.GenerateNextBoss();
			__instance.bridge.simulation.model.bossBloonType = nextBoss;


			Transform transform = __instance.GetInGameUI().transform.FindChildWithName("BossUi(Clone)");
			BossUI bossUi = transform.GetComponent<BossUI>();
			BossData bossData = Il2CppAssets.Scripts.Data.GameData.Instance.bosses.GetBossData(nextBoss);
			ResourceLoader.LoadSpriteFromSpriteReference(bossData.normalHudIcon, bossUi.bossImg);
			ResourceLoader.LoadSpriteFromSpriteReference(bossData.normalHudIcon, bossUi.arriveBossImg);
			bossUi.Show();
		}

		if (new int[] { 19, 39, 59, 79, 99, 119, 139, 159, 179, 199, 219, 239, 259, 279, 299 }.Contains(round)) {
			Transform transform = __instance.GetInGameUI().transform.FindChildWithName("BossUi(Clone)");
			BossUI bossUi = transform.GetComponent<BossUI>();
			bossUi.Hide();
		}

		// Tower choice every 10 rounds (starting at 5)
		if ((round + 1 - 5) >= 0 && (round + 1 - 5) % 10 == 0) {
			if (BTD6Rogue.rogueGame.rerolls < 3) { BTD6Rogue.rogueGame.rerolls++; }
			BTD6Rogue.rogueGame.encounterManager.AddEncounter(ModContent.GetContent<GainTowerEncounter>()[0]);
		}

		if ((round + 1 - 40) >= 0 && (round + 1 - 40) % 40 == 0) {
			if (BTD6Rogue.rogueGame.rerolls < 3) { BTD6Rogue.rogueGame.rerolls++; }
			BTD6Rogue.rogueGame.encounterManager.AddEncounter(ModContent.GetContent<GainHeroEncounter>()[0]);
		}

		if ((round + 1 - 90) >= 0 && (round + 1 - 90) % 90 == 0) {
			if (BTD6Rogue.rogueGame.rerolls < 3) { BTD6Rogue.rogueGame.rerolls++; }
			BTD6Rogue.rogueGame.encounterManager.AddEncounter(ModContent.GetContent<GainParagonEncounter>()[0]);
		}
	}
}

/*
public partial class BTD6Rogue {
    public override void OnRoundEnd() {
        InGame inGame = InGame.instance;
        if (inGame.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }
        if (DisablePatchesInSandbox && inGame.bridge.IsSandboxMode()) { return; }

        //foreach (KeyValuePair<string, ArtifactGameData> artifact in currentGame.activeArtifacts) {
        //    if (artifact.Value.artifactLength == ArtifactLength.Temp) { artifact.Value.timer--; }
        //    if (artifact.Value.timer < 1) { artifact.Value.baseArtifact.OnArtifactExpire(inGame); currentGame.activeArtifacts.Remove(artifact.Key); }
        //    artifact.Value.baseArtifact.OnRoundEnd(inGame);
        //}


        if ((round + 1) % 20 == 1) {
            int bossInt = new Random().Next(currentGame.availableBosses.Count);
            currentGame.roundGenerator.nextBoss = currentGame.availableBosses[bossInt];
            string bossHint = BossUtil.GetBossHint(currentGame.roundGenerator.nextBoss);
            Game.instance.ShowMessage(bossHint, 20f);
        }

        // Artifact choice every 15 rounds
        //if ((round + 1) % 20 == 10) {
        //    inGame.bridge.SetAutoPlay(false);
        //    currentGame.panelManager.AddPanelToQueue(inGame.uiRect, inGame, nameof(ArtifactChoicePanel));
        //}
    }
}
*/