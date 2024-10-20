using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class Alchemist : RogueTower {
	public override string BaseTowerId => TowerType.Alchemist;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(1, 2), new(2, 4), new(2, 4)];
}