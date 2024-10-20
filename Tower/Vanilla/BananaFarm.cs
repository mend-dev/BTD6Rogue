using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class BananaFarm : RogueTower {
	public override string BaseTowerId => TowerType.BananaFarm;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(2, 4), new(2, 4), new(2, 4)];
}