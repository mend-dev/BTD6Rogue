using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine;

namespace BTD6Rogue;

public class WizardMonkey : RogueTower {
    public override string BaseTower => TowerType.WizardMonkey;

    public override int[] LeadUpgradeTiers => new int[3] { 4, 1, 4 };

    public override int[] CamoUpgradeTiers => new int[3] { -1, -1, 2 };

    public override PathType[] UpgradePathTypes => new PathType[3] { PathType.Damage, PathType.Aoe, PathType.Aoe };

    public override Vector2Int[] TowerAmountRanges => new Vector2Int[3] { new Vector2Int(), new Vector2Int(), new Vector2Int(3, 5) };

    public override void Register() {}
}