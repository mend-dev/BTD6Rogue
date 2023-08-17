using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class BeastHandler : RogueTower {
    public override string BaseTower => TowerType.BeastHandler;

    public override int[] LeadUpgradeTiers => new int[3] { 3, 2, 5 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, 2 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Damage, PathType.Damage, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(3, 6), new Vector2Int(3, 6), new Vector2Int(3, 6) };

    public override void Register() { }
}