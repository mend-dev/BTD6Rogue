using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppSystem.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;

namespace BTD6Rogue;

// Instance created when RogueGame.GameStarted is called
// Handles all of the functionality related to Towers, Heroes, and Paragons in a RogueGame
public class TowerManager(InGame game) {
	private InGame game = game;

	public List<TowerSet> disabledTowerSets = new List<TowerSet>();
	public bool disableWaterTowers = false;

	public System.Collections.Generic.Dictionary<string, TowerData> towers = new System.Collections.Generic.Dictionary<string, TowerData>();
	public System.Collections.Generic.Dictionary<string, HeroData> heroes = new System.Collections.Generic.Dictionary<string, HeroData>();
	public System.Collections.Generic.Dictionary<string, ParagonData> paragons = new System.Collections.Generic.Dictionary<string, ParagonData>();

	// Clear the Tower Inventory by looping through all the keys in the TowerInventory and setting them to 0
	// If they don't exist in the dictionary, add them and set the value to 0
	public void ClearTowerInventory() {
		TowerInventory towerInventory = game.GetTowerInventory();
		Dictionary<string, int> towerMaxes = towerInventory.GetTowerInventoryMaxes();

		foreach (string tower in TowerType.towers) {
			if (towerMaxes.ContainsKey(tower)) {
				towerMaxes[tower] = 0;
			} else {
				towerMaxes.Add(tower, 0);
			}
		}

		towerInventory.towerMaxes = towerMaxes;
		UpdateInventory();
	}

	public void DisableTowerSet(TowerSet towerSet, bool towerSetDisabled = true) {
		if (towerSetDisabled && !disabledTowerSets.Contains(towerSet)) {
			disabledTowerSets.Add(towerSet);
		} else if (!towerSetDisabled && disabledTowerSets.Contains(towerSet)) {
			disabledTowerSets.Remove(towerSet);
		}
	}

	public void DisableWaterTowers(bool waterTowersDisabled = true) {
		disableWaterTowers = waterTowersDisabled;
	}

	public void AddTowerToInventory(TowerData tower) {
		// If the towers dictionary already contains a TowerData object with the same Tower BaseId merge the TowerData's instead of adding it
		if (towers.ContainsKey(tower.baseId)) {
			towers[tower.baseId] = TowerUtil.MergeTowerData(towers[tower.baseId], tower);
		} else {
			towers[tower.baseId] = tower;
		}
		UpdateInventory();
	}

	public void AddHeroToInventory(HeroData hero) {
		heroes[hero.baseId] = hero;
		heroes[hero.baseId].locked = true;
		UpdateInventory();
	}

	public void AddParagonToInventory(ParagonData paragon) {
		paragons[paragon.towerId] = paragon;
		paragons[paragon.towerId].locked = true;
		AddTowerToInventory(new TowerData(paragon.towerId, [5, 5, 5], count: 3));
		UpdateInventory();
	}

	// move looping through inventory to here
	public void UpdateInventory() {
		TowerInventory towerInventory = game.GetTowerInventory();
		Dictionary<string, int> towerMaxes = towerInventory.GetTowerInventoryMaxes();
		foreach (string key in towers.Keys) { towerMaxes[key] = towers[key].count; }
		foreach (string key in heroes.Keys) { towerMaxes[key] = heroes[key].count; }
		towerInventory.towerMaxes = towerMaxes;
		ShopMenu.instance.ForceRefreshTowerSet();
		ShopMenu.instance.RebuildTowerSet();
	}

	public void UnlockAllTowers() {
		foreach (string key in towers.Keys) {
			towers[key].locked = false;
			towers[key].limitPaths[0] = false;
			towers[key].limitPaths[1] = false;
			towers[key].limitPaths[2] = false;
		}
	}

	public void UnlockTowerPath(string towerId, int path) {
		if (towers.ContainsKey(towerId)) {
			towers[towerId].limitPaths[path] = false;
		}
	}

	public void UnlockHero(string heroId) {
		if (heroes.ContainsKey(heroId)) {
			heroes[heroId].locked = false;
		}
	}

	public void UnlockParagon(string towerId) {
		if (paragons.ContainsKey(towerId)) {
			paragons[towerId].locked = false;
		}
	}

	public void UnlockAllHeroes() {
		foreach (string key in heroes.Keys) {
			heroes[key].locked = false;
		}
	}

	public void UnlockAllParagons() {
		foreach (string key in paragons.Keys) {
			paragons[key].locked = false;
		}
	}

	public void LockTowerPath(string towerId, int path) {
		if (towers.ContainsKey(towerId)) {
			towers[towerId].limitPaths[path] = true;
		} else {
			towers[towerId] = new TowerData(towerId);
			towers[towerId].limitPaths[path] = true;
		}
	}

	public void LockHero(string heroId) {
		if (heroes.ContainsKey(heroId)) {
			heroes[heroId].locked = true;
		} else {
			heroes[heroId] = new HeroData(heroId);
			heroes[heroId].locked = true;
		}
	}

	public void LockParagon(string towerId) {
		if (paragons.ContainsKey(towerId)) {
			paragons[towerId].locked = true;
		} else {
			paragons[towerId] = new ParagonData(towerId);
			paragons[towerId].locked = true;
		}

		LockTowerPath(towerId, 0);
		LockTowerPath(towerId, 1);
		LockTowerPath(towerId, 2);
	}
}
