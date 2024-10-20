using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class MonkeyBuccaneer : RogueTower {
	public override string BaseTowerId => TowerType.MonkeyBuccaneer;

	public override Dictionary<string, TowerTag[]> TowerTags => [];

	public override Vector2Int[] TowerAmountRanges => [new(1, 3), new(2, 3), new(3, 6)];
}