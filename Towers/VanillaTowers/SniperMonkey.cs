using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class SniperMonkey : RogueTower {
    public override string BaseTower => TowerType.SniperMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 1, 4, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, 2, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Damage, PathType.Money, PathType.Aoe };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(2, 3), new Vector2Int(4, 8), new Vector2Int() };

    public override void Register() { }
}