using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class TackShooter : RogueTower {
    public override string BaseTower => TowerType.TackShooter;

    public override int[] LeadUpgradeTiers => new int[3] { 3, 5, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Aoe, PathType.Aoe };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(3, 4), new Vector2Int() };

    public override void Register() { }
}