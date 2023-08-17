using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class MortarMonkey : RogueTower {
    public override string BaseTower => TowerType.MortarMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 0, 0, 0 };

    public override int[] CamoUpgradeTiers => new int[3] { 0, 0, 0 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Damage, PathType.Aoe, PathType.Aoe };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(3, 6), new Vector2Int(3, 6), new Vector2Int(3, 6) };

    public override void Register() { }
}