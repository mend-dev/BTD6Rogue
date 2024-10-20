using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class TackShooter : RogueTower {
	public override string BaseTowerId => TowerType.TackShooter;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(2, 3), new(2, 4), new(1, 3)];
}