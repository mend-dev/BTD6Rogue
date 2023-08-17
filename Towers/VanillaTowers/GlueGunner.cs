using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class GlueGunner : RogueTower {
    public override string BaseTower => TowerType.GlueGunner;

    public override int[] LeadUpgradeTiers => new int[3] { 2, -1, 5 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Stall, PathType.Stall };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(1, 4), new Vector2Int(1, 4), new Vector2Int(1, 4) };

    public override void Register() { }
}