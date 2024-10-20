using BTD_Mod_Helper.Api;
using System;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class ParagonUtil {

	public static List<RogueParagon> GetEnabledRogueParagons(RogueGame game) {
		List<RogueParagon> enabledTowers = new List<RogueParagon>();

		foreach (RogueParagon tower in ModContent.GetContent<RogueParagon>()) {
			if (game.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Paragon)) {
				continue;
			}
			if (game.towerManager.disabledTowerSets.Contains(tower.GetBaseTower().towerSet)) {
				continue;
			}
			if (game.towerManager.disableWaterTowers && tower.GetBaseParagon().IsExclusivelyWaterBased) {
				continue;
			}
			if (game.towerManager.disableWaterTowers && tower.GetBaseTower().IsExclusivelyWaterBased) {
				continue;
			}

			enabledTowers.Add(tower);
		}

		return enabledTowers;
	}

	public static ParagonChoice CreateParagonChoiceData(RogueParagon paragon) {
		return new ParagonChoice(paragon.BaseTowerId, paragon, paragon.GetBaseParagon().portrait, paragon.GetBaseParagon());
	}

	public static ParagonData CreateDataFromChoice(ParagonChoice choiceData) {
		ParagonData paragonData = new ParagonData(choiceData.towerId, 1, false);
		return paragonData;
	}

	public static List<ParagonChoice> CreateAllValidParagonChoices(RogueGame rogueGame) {
		List<ParagonChoice> towerChoices = new List<ParagonChoice>();
		List<RogueParagon> rogueTowers = GetEnabledRogueParagons(rogueGame);
		Dictionary<string, ParagonData> playerTowers = rogueGame.towerManager.paragons;

		foreach (RogueParagon rogueTower in rogueTowers) {
			if (playerTowers.ContainsKey(rogueTower.BaseTowerId)) {
				if (playerTowers[rogueTower.BaseTowerId].locked) { continue; }
			}
			towerChoices.Add(CreateParagonChoiceData(rogueTower));
		}

		return towerChoices;
	}

	public static ParagonChoice[] CreateValidParagonChoices(RogueGame rogueGame) {
		List<ParagonChoice> paragons = new List<ParagonChoice>();

		List<ParagonChoice> possibleChoices = CreateAllValidParagonChoices(rogueGame);
		if (possibleChoices.Count < 3) { return null!; }

		while (paragons.Count < 3) {
			ParagonChoice towerChoice = possibleChoices[new Random().Next(possibleChoices.Count)];
			if (paragons.Contains(towerChoice)) { continue; }
			paragons.Add(towerChoice);
		}

		return paragons.ToArray();
	}

	public static RogueParagon GetRandomParagon() {
		List<RogueParagon> paragons = ModContent.GetContent<RogueParagon>();
		return paragons[new Random().Next(paragons.Count)];
	}
}