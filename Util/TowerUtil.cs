using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class TowerUtil {

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
    }
}
