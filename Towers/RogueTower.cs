using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;

namespace BTD6Rogue;

public abstract class RogueTower : NamedModContent {
    public abstract string BaseTower { get; }
    public abstract int[] LeadUpgradeTiers { get; }
    public abstract int[] CamoUpgradeTiers { get; }
    public abstract PathType[] UpgradePathTypes { get; }
    public abstract Vector2Int[] TowerAmountRanges { get; }

    public TowerModel GetBaseTower() {
        return Game.instance.model.GetTowerModel(BaseTower);
    }

    public TowerModel GetTower(int path, int tier) {
        if (path == 0) {
            return Game.instance.model.GetTowerModel(BaseTower, tier, 0, 0);
        } else if (path == 1) {
            return Game.instance.model.GetTowerModel(BaseTower, 0, tier, 0);
        } else {
            return Game.instance.model.GetTowerModel(BaseTower, 0, 0, tier);
        }
    }

    public int GetTowerAmount(int path) {
        if (TowerAmountRanges[path].x == 0 && TowerAmountRanges[path].y == 0) {
            return new System.Random().Next(1, 4);
        } else {
            return new System.Random().Next(TowerAmountRanges[path].x, TowerAmountRanges[path].y + 1);
        }
    }
}

public enum PathType {
    Damage,
    Aoe,
    Support,
    Stall,
    Money
}

public class TowerGameData {
    public string baseId = ""; // Base ID of the Tower Model
    public int[] limitPaths = new int[3] { 2, 2, 2 }; // Limited tier of each path when upgrading in game
    public int[] maxPaths = new int[3] { 0, 0, 0 }; // Max tier of each path in the base Tower Model
    public bool[] lockedPaths = new bool[3] { false, false, false }; // Whether or not the path is locked out of being in the panel
    public bool[] hasPaths = new bool[3] { false, false, false }; // Whether or not the base Tower Model even has that path
    public int count = 0; // How many the player has in their inventory
    public bool noPaths = true; // If the tower has no paths
    public bool lockedTower = false; // If the tower is unable to show up in choices
    public TowerModel baseTowerModel = null!; // Base tower model for the rogue tower
    public RogueTower baseRogueTower = null!;
}
