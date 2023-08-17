using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class NinjaMonkey : RogueTower {
    public override string BaseTower => TowerType.NinjaMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { -1, -1, 3 };

    public override int[] CamoUpgradeTiers => new int[3] { 0, 0, 0 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Stall, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(4, 10), new Vector2Int(3, 5) };

    public override void Register() { }
}