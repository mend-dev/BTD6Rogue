using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class Druid : RogueTower {
    public override string BaseTower => TowerType.Druid;

    public override int[] LeadUpgradeTiers => new int[3] { 1, -1, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Stall, PathType.Aoe, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(), new Vector2Int(5, 6) };

    public override void Register() { }
}