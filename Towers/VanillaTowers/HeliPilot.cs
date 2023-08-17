using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class HeliPilot : RogueTower {
    public override string BaseTower => TowerType.HeliPilot;

    public override int[] LeadUpgradeTiers => new int[3] { 3, -1, 3 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, 2, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Damage, PathType.Stall, PathType.Aoe };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(2, 5), new Vector2Int() };

    public override void Register() { }
}