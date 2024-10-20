using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class SpikeFactory : RogueTower {
	public override string BaseTowerId => TowerType.SpikeFactory;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(1, 2), new(1, 4), new(1, 3)];
}