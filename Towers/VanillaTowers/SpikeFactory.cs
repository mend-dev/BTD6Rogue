using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class SpikeFactory : RogueTower {
    public override string BaseTower => TowerType.SpikeFactory;

    public override int[] LeadUpgradeTiers => new int[3] { 2, -1, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { 0, 0, 0 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Damage, PathType.Aoe, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(1, 2), new Vector2Int(2, 5), new Vector2Int(1, 2) };

    public override void Register() { }
}