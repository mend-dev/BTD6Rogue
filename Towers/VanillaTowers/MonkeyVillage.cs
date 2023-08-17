using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class MonkeyVillage : RogueTower {
    public override string BaseTower => TowerType.MonkeyVillage;

    public override int[] LeadUpgradeTiers => new int[3] { -1, 3, -1 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, 2, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Support, PathType.Support, PathType.Money };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(2, 3), new Vector2Int(2, 3), new Vector2Int(2, 3) };

    public override void Register() { }
}