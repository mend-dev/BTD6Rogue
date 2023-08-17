using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class IceMonkey : RogueTower {
    public override string BaseTower => TowerType.IceMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 2, -1, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { 2, -1, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Stall, PathType.Stall, PathType.Stall };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(3, 5), new Vector2Int() };

    public override void Register() { }
}