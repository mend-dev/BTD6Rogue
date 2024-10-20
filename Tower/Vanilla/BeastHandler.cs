using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class BeastHandler : RogueTower {
	public override string BaseTowerId => TowerType.BeastHandler;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(4, 5), new(4, 5), new(4, 5)];
}