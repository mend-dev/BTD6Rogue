using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class SuperMonkey : RogueTower {
    public override string BaseTower => TowerType.SuperMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 2, 4, 4 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, 2 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Aoe, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(1, 2), new Vector2Int(1, 2), new Vector2Int(1, 2) };

    public override void Register() { }
}