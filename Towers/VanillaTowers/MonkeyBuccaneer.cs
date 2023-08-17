using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class MonkeyBuccaneer : RogueTower {
    public override string BaseTower => TowerType.MonkeyBuccaneer;

    public override int[] LeadUpgradeTiers => new int[3] { -1, 2, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, 2 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Damage, PathType.Money };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(), new Vector2Int(4, 8) };

    public override void Register() { }
}