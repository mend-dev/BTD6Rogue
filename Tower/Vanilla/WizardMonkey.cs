using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class WizardMonkey : RogueTower {
	public override string BaseTowerId => TowerType.WizardMonkey;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(2, 3), new(2, 4), new(2, 4)];
}