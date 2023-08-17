using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class BananaFarm : RogueTower {
    public override string BaseTower => TowerType.BananaFarm;

    public override int[] LeadUpgradeTiers => new int[3] { -1, -1, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Money, PathType.Money, PathType.Money };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(4, 8), new Vector2Int(4, 8), new Vector2Int(4, 8) };

    public override void Register() { }
}