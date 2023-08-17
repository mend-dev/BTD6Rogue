using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class EngineerMonkey : RogueTower {
    public override string BaseTower => TowerType.EngineerMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 4, 3, 4 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, 3, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Support, PathType.Money };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(), new Vector2Int(3, 7) };

    public override void Register() { }
}