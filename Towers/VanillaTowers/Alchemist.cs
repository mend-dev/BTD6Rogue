using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class Alchemist : RogueTower {
    public override string BaseTower => TowerType.Alchemist;

    public override int[] LeadUpgradeTiers => new int[3] { 0, 0, 0 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Support, PathType.Damage, PathType.Money };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(1, 2), new Vector2Int(3, 5), new Vector2Int(2, 4) };

    public override void Register() { }
}