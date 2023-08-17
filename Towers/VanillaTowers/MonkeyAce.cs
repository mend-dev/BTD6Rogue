using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class MonkeyAce : RogueTower {
    public override string BaseTower => TowerType.MonkeyAce;

    public override int[] LeadUpgradeTiers => new int[3] { 5, 1, 4 };
    
    public override int[] CamoUpgradeTiers => new int[3] { -1, 2, -1 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Aoe, PathType.Aoe, PathType.Damage };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(), new Vector2Int() };

    public override void Register() { }
}