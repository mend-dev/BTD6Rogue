using BTD_Mod_Helper.Api;
using System;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class HeroUtil {

	public static List<RogueHero> GetEnabledRogueHeroes(RogueGame game) {
		List<RogueHero> enabledTowers = new List<RogueHero>();

		foreach (RogueHero tower in ModContent.GetContent<RogueHero>()) {
			if (game.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero)) {
				continue;
			}

			if (game.towerManager.disableWaterTowers && tower.GetBaseHero().IsExclusivelyWaterBased) {
				continue;
			}

			enabledTowers.Add(tower);
		}

		return enabledTowers;
	}

	public static HeroChoice[] GetHeroesChoiceData(RogueGame game) {
		List<HeroChoice> heroChoices = new List<HeroChoice>();

		List<RogueHero> rogueHeroes = GetEnabledRogueHeroes(game);
		foreach (RogueHero rogueHero in rogueHeroes) {
			heroChoices.Add(CreateHeroChoiceData(rogueHero));
		}

		return heroChoices.ToArray();
	}

	public static HeroChoice CreateHeroChoiceData(RogueHero hero) {
		return new HeroChoice(hero.BaseHeroId, 1, hero, hero.GetBaseHero().portrait, hero.GetBaseHero());
	}

	public static HeroData CreateDataFromChoice(HeroChoice choiceData) {
		HeroData heroData = new HeroData(choiceData.towerId, choiceData.towerAmount);
		return heroData;
	}

	public static List<HeroChoice> CreateAllValidHeroChoices(RogueGame rogueGame) {
		List<HeroChoice> towerChoices = new List<HeroChoice>();
		List<RogueHero> rogueTowers = GetEnabledRogueHeroes(rogueGame);
		Dictionary<string, HeroData> playerTowers = rogueGame.towerManager.heroes;

		foreach (RogueHero rogueTower in rogueTowers) {
			if (playerTowers.ContainsKey(rogueTower.BaseHeroId)) {
				if (playerTowers[rogueTower.BaseHeroId].locked) { continue; }
			}
			towerChoices.Add(CreateHeroChoiceData(rogueTower));
		}

		return towerChoices;
	}

	public static HeroChoice[] CreateValidHeroChoices(RogueGame rogueGame) {
		List<HeroChoice> heroes = new List<HeroChoice>();

		List<HeroChoice> possibleChoices = CreateAllValidHeroChoices(rogueGame);
		if (possibleChoices.Count < 3) { return null!; }

		while (heroes.Count < 3) {
			HeroChoice towerChoice = possibleChoices[new Random().Next(possibleChoices.Count)];
			if (heroes.Contains(towerChoice)) { continue; }
			heroes.Add(towerChoice);
		}

		return heroes.ToArray();
	}

	public static RogueHero GetRandomHero() {
		List<RogueHero> heroes = ModContent.GetContent<RogueHero>();
		return heroes[new Random().Next(heroes.Count)];
	}
}