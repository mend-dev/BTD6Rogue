using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTD6Rogue;

// Functions to handle common tower related code
// Code here should not change anything game data
// Handle all of that in TowerManager
public static class TowerUtil {

	public static List<RogueTower> GetEnabledRogueTowers(RogueGame game) {
		List<RogueTower> enabledTowers = new List<RogueTower>();

		foreach (RogueTower tower in ModContent.GetContent<RogueTower>()) {
			if (game.towerManager.disabledTowerSets.Contains(tower.GetBaseTower().towerSet)) {
				continue;
			}

			if (game.towerManager.disableWaterTowers && tower.GetBaseTower().IsExclusivelyWaterBased) {
				continue;
			}

			enabledTowers.Add(tower);
		}

		return enabledTowers;
	}

	public static TowerChoice[] GetTier0TowersChoiceData(RogueGame game) {
		List<TowerChoice> towerChoices = new List<TowerChoice>();

		List<RogueTower> rogueTowers = GetEnabledRogueTowers(game);
		foreach (RogueTower rogueTower in rogueTowers) {
			towerChoices.Add(CreateTowerChoiceData(rogueTower, [0, 0, 0]));
		}

		return towerChoices.ToArray();
	}

	public static TowerChoice CreateTowerChoiceData(RogueTower tower, int[] tiers) {
		TowerModel towerModel = tower.GetTower(tiers);
		int path = Array.IndexOf(tiers, tiers.Max());

		string towerName = tower.GetTower(tiers).GetBaseId();
		if (tiers[path] > 0) {
			towerName = towerModel.GetUpgrade(path, tiers[path]).name;
		}
		return new TowerChoice(tower.BaseTowerId, towerName, tower.GetTowerAmount(tiers), tiers, tower, tower.GetTower(tiers).portrait, tower.GetTower(tiers));
	}

	public static TowerChoice[] CreateTowerChoiceDatas(RogueTower tower, int tier) {
		List<TowerChoice> towerChoices = new List<TowerChoice>();

		TowerModel path1Tower = tower.GetTower([tier, 0, 0]);
		TowerModel path2Tower = tower.GetTower([0, tier, 0]);
		TowerModel path3Tower = tower.GetTower([0, 0, tier]);

		string path1Name = path1Tower.GetBaseId();
		string path2Name = path2Tower.GetBaseId();
		string path3Name = path3Tower.GetBaseId();
		if (tier > 0) {
			path1Name = path1Tower.GetUpgrade(0, tier).name;
			path2Name = path2Tower.GetUpgrade(1, tier).name;
			path3Name = path3Tower.GetUpgrade(2, tier).name;
		}

		towerChoices.Add(new TowerChoice(tower.BaseTowerId, path1Name, tower.GetTowerAmount([tier, 0, 0]), [tier, 0, 0], tower, path1Tower.portrait, path1Tower));
		towerChoices.Add(new TowerChoice(tower.BaseTowerId, path2Name, tower.GetTowerAmount([0, tier, 0]), [0, tier, 0], tower, path2Tower.portrait, path2Tower));
		towerChoices.Add(new TowerChoice(tower.BaseTowerId, path3Name, tower.GetTowerAmount([0, 0, tier]), [0, 0, tier], tower, path3Tower.portrait, path3Tower));

		return towerChoices.ToArray();
	}

	public static TowerData MergeTowerData(TowerData tower1, TowerData tower2) {
		// Check if the BaseIds for both TowerDatas are the same, if they aren't log error and return
		if (tower1.baseId != tower2.baseId) {
			BTD6Rogue.LogMessage("tower1.baseId is not equal to tower2.baseId", "TowerUtil.MergeTowerData", ErrorLevels.Error);
			return null!;
		}

		TowerData newData = new TowerData();

		newData.baseId = tower1.baseId; // BaseIds are same after check

		for (int i = 0; i < 3; i++) {
			newData.limitTiers[i] = Math.Max(tower1.limitTiers[i], tower2.limitTiers[i]);
			newData.hasTiers[i] = Math.Max(tower1.hasTiers[i], tower2.hasTiers[i]);
			newData.limitPaths[i] = tower1.limitPaths[i] || tower2.limitPaths[i];
			newData.hasPaths[i] = tower1.hasPaths[i] || tower2.hasPaths[i];
		}

		newData.count = tower1.count + tower2.count;
		newData.locked = tower1.locked || tower2.locked;

		return newData;
	}

	public static TowerData CreateDataFromChoice(TowerChoice choiceData) {
		int[] towerPaths = [Math.Max(choiceData.towerPaths[0], 2), Math.Max(choiceData.towerPaths[1], 2), Math.Max(choiceData.towerPaths[2], 2)];
		TowerData towerData = new TowerData(choiceData.towerId, towerPaths, count: choiceData.towerAmount);
		return towerData;
	}

	public static List<TowerChoice> CreateAllValidTowerChoices(RogueGame rogueGame) {
		List<TowerChoice> towerChoices = new List<TowerChoice>();
		List<RogueTower> rogueTowers = GetEnabledRogueTowers(rogueGame);
		Dictionary<string, TowerData> playerTowers = rogueGame.towerManager.towers;
		int round = rogueGame.game.bridge.GetCurrentRound() + 1;
		int tier = Math.Min((int) Math.Floor(round / 20d) + 2, 5);

		foreach (RogueTower rogueTower in rogueTowers) {
			if (playerTowers.ContainsKey(rogueTower.BaseTowerId)) {
				if (playerTowers[rogueTower.BaseTowerId].locked) { continue; }
				if (!playerTowers[rogueTower.BaseTowerId].limitPaths[0]) { towerChoices.Add(CreateTowerChoiceData(rogueTower, [tier, 0, 0])); }
				if (!playerTowers[rogueTower.BaseTowerId].limitPaths[1]) { towerChoices.Add(CreateTowerChoiceData(rogueTower, [0, tier, 0])); }
				if (!playerTowers[rogueTower.BaseTowerId].limitPaths[2]) { towerChoices.Add(CreateTowerChoiceData(rogueTower, [0, 0, tier])); }
			} else {
				towerChoices.AddRange(CreateTowerChoiceDatas(rogueTower, tier));
			}
		}

		return towerChoices;
	}

	public static TowerChoice[] CreateValidTowerChoices(RogueGame rogueGame) {
		List<TowerChoice> towers = new List<TowerChoice>();

		List<TowerChoice> possibleChoices = CreateAllValidTowerChoices(rogueGame);
		if (possibleChoices.Count < 3) { return null!; }

		while (towers.Count < 3) {
			TowerChoice towerChoice = possibleChoices[new Random().Next(possibleChoices.Count)];
			if (towers.Contains(towerChoice)) { continue; }
			towers.Add(towerChoice);
		}

		return towers.ToArray();
	}

	public static RogueTower GetRandomTower() {
		List<RogueTower> towers = ModContent.GetContent<RogueTower>();
		return towers[new Random().Next(towers.Count)];
	}

	/*
	public static string[] GetAllTowerSets() {
		List<string> towerSets = new List<string>() { "Primary", "Military", "Magic", "Support" };

		foreach (ModTowerSet towerSet in ModContent.GetContent<ModTowerSet>()) {
			towerSets.Add(towerSet.Id);
		}
		return towerSets.ToArray();
	}

	public static TowerModel[] GetThreeTowers() {
		List<TowerModel> towers = new List<TowerModel>();

		if (!CheckTowersValidity()) { ResetLockedPaths(); }

		for (int i = 0; i < 3; i++) {
			TowerModel tower = GetRandomTower();
			int whileChecker = 0;
			while (towers.Contains(tower) || IsLockedTower(tower) || (tower.IsWaterBased() && !MapUtil.waterMaps.Contains(InGame.instance.bridge.GetMapName()))) {
				tower = GetRandomTower();
				whileChecker++;
				if (whileChecker >= 1250) { ResetLockedPaths(); }
			}
			towers.Add(tower);
		}

		return towers.ToArray();
	}

	public static TowerModel GetRandomTower() {
		Random random = new Random();

		RogueTower[] towers = GetAllGameTowers();
		RogueTower tower = towers[random.Next(towers.Length)];

		return tower.GetTower(new Random(Guid.NewGuid().GetHashCode()).Next(0, 3), TowerUtil.GetMaxTier(InGame.instance.bridge.GetCurrentRound()));
	}

	public static RogueTower GetRogueTowerFromModel(TowerModel tower) {
		RogueTower[] rogueTowers = GetAllTowers();
		foreach (RogueTower rogueTower in rogueTowers) {
			if (tower.baseId == rogueTower.BaseTower) {
				return rogueTower;
			}
		}
		return null;
	}

	public static RogueTower[] GetAllGameTowers() {
		List<RogueTower> gameTowers = new List<RogueTower>();

		foreach (TowerGameData towerGameData in BTD6Rogue.mod.currentGame.towerData.Values) {
			gameTowers.Add(towerGameData.baseRogueTower);
		}

		return gameTowers.ToArray();
	}

	public static RogueTower[] GetAllTowers() {
		List<RogueTower> towers = ModContent.GetContent<RogueTower>();
		return towers.ToArray();
	}

	public static int GetMaxTier(int round) {
		if (round + 1 >= BTD6Rogue.Tier5MinimumRound) {
			return 5;
		} else if (round + 1 >= BTD6Rogue.Tier4MinimumRound) {
			return 4;
		} else if (round + 1 >= BTD6Rogue.Tier3MinimumRound) {
			return 3;
		} else if (round + 1 >= BTD6Rogue.Tier2MinimumRound) {
			return 2;
		} else {
			return 1;
		}
	}

	public static int GetTowerPath(TowerModel tower) {
		if (tower.GetUpgradeLevel(0) >= 1) { return 0; }
		if (tower.GetUpgradeLevel(1) >= 1) { return 1; }
		if (tower.GetUpgradeLevel(2) >= 1) { return 2; }
		return 0;
	}

	public static bool IsLockedTower(TowerModel tower) {
		if (BTD6Rogue.mod.currentGame.towerData[tower.baseId].lockedTower) { return true; }
		if (tower.GetUpgradeLevel(0) >= 1 && BTD6Rogue.mod.currentGame.towerData[tower.baseId].lockedPaths[0]) { return true; }
		if (tower.GetUpgradeLevel(1) >= 1 && BTD6Rogue.mod.currentGame.towerData[tower.baseId].lockedPaths[1]) { return true; }
		if (tower.GetUpgradeLevel(2) >= 1 && BTD6Rogue.mod.currentGame.towerData[tower.baseId].lockedPaths[2]) { return true; }
		return false;
	}

	public static bool CheckTowersValidity() {
		int validPaths = 0;
		foreach (TowerGameData data in BTD6Rogue.mod.currentGame.towerData.Values) {
			if (!data.lockedPaths[0]) { validPaths++; }
			if (!data.lockedPaths[1]) { validPaths++; }
			if (!data.lockedPaths[2]) { validPaths++; }
		}

		if (validPaths > 3) {
			return true;
		} else {
			return false;
		}
	}

	public static void ResetLockedPaths() {
		foreach (TowerGameData data in BTD6Rogue.mod.currentGame.towerData.Values) {
			data.lockedPaths[0] = false;
			data.lockedPaths[1] = false;
			data.lockedPaths[2] = false;
			data.lockedTower = false;
		}
	}8*/
}
