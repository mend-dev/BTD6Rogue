using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class DartMonkey : RogueTower {
    public override string BaseTower => TowerType.DartMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 4, 5, 5 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, 2 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Damage, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(4, 8), new Vector2Int(2, 4) };

    public override void Register() { }
}