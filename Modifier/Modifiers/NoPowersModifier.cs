﻿using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

public class NoPowersModifier : RogueModifier {
	public override string DisplayName => "No Powers";
	public override string Description => "";
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {
		model.RemoveMutator<LockTowerSetModModel>("LockPowers");
		model.AddMutator(new LockTowerSetModModel("LockPowers", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Items));
	}

	public override void RemoveRogueModifier(ModModel model) { model.RemoveMutator<LockTowerSetModModel>("LockPowers"); }

	public override void GameStarted(RogueGame rogueGame, InGame game) {
		rogueGame.towerManager.DisableTowerSet(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Items);
	}
}
