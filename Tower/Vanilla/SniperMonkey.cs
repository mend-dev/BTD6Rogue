using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class SniperMonkey : RogueTower {
	public override string BaseTowerId => TowerType.SniperMonkey;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(2, 3), new(3, 5), new(2, 4)];
}