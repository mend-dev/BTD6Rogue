using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using UnityEngine;
using System;
using BloonType = BTD_Mod_Helper.Api.Enums.BloonType;

namespace BTD6Rogue;

public class BloonariusBoss : RogueBoss {
	public override string BossName => "Bloonarius";

	public static readonly float baseMaxHealth = 3000;
	public static readonly float levelHealthModifier = 2.2f;

	public static readonly float baseSpeed = 1.5f;
	public static readonly float levelSpeedIncrease = 0.25f;

	// Strong Spawn
	public static readonly int baseStrongSpawnCount = 30;
	public static readonly float levelStrongSpawnCountAddition = -3;
	public static readonly int baseStrongSpawnDistAhead = 30;
	public static readonly float levelStrongSpawnDistAheadAddition = 0;
	public static readonly List<string> strongSpawnBloons = new List<string>() {
		BloonType.Yellow,
		BloonType.Zebra,
		BloonType.Rainbow,
		BloonType.Ceramic,
		BloonType.Moab,
		BloonType.Bfb
	};

	// Weak Spawn
	public static readonly int baseWeakSpawnCount = 40;
	public static readonly float levelWeakSpawnCountAddition = -2.5f;
	public static readonly float baseWeakSpawnTrackMax = 0.4f;
	public static readonly float levelWeakSpawnTrackMaxAddition = 0;
	public static readonly float baseWeakSpawnTrackMin = 0.1f;
	public static readonly float levelWeakSpawnTrackMinAddition = 0;
	public static readonly List<string> weakSpawnBloons = new List<string>() {
		BloonType.Green,
		BloonType.Pink,
		BloonType.Zebra,
		BloonType.Rainbow,
		BloonType.Ceramic,
		BloonType.Moab
	};

	// Bloon Bleed
	public static readonly int baseBleedSpawnCount = 20;
	public static readonly float levelBleedSpawnCountAddition = 5;
	public static readonly float baseBleedSpawnTrackMax = 0.4f;
	public static readonly float levelBleedSpawnTrackMaxAddition = 0;
	public static readonly float baseBLeedSpawnTrackMin = 0.1f;
	public static readonly float levelBleedSpawnTrackMinAddition = 0;
	public static readonly List<string> bleedSpawnBloons = new List<string>() {
		BloonType.Blue,
		BloonType.Yellow,
		BloonType.Pink,
		BloonType.Zebra,
		BloonType.Rainbow,
		BloonType.Ceramic
	};

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (SpawnBloonsAction behavior in bloon.GetBloonBehaviors<SpawnBloonsAction>()) {
			SpawnBloonsActionModel model = behavior.modl;
			if (model.actionId == "StrongSpawn") {
				model.bloonType = strongSpawnBloons[Math.Min(tier, 5)];
				model.spawnCount = Mathf.FloorToInt(baseStrongSpawnCount + levelStrongSpawnCountAddition * tier);
				model.spawnDistAhead = baseStrongSpawnDistAhead + levelStrongSpawnDistAheadAddition * tier;
			} else if (model.actionId == "WeakSpawn") {
				model.bloonType = weakSpawnBloons[Math.Min(tier, 5)];
				model.spawnCount = Mathf.FloorToInt(baseWeakSpawnCount + levelWeakSpawnCountAddition * tier);
				model.spawnTrackMax = baseWeakSpawnTrackMax + levelWeakSpawnTrackMaxAddition * tier;
				model.spawnTrackMin = baseWeakSpawnTrackMin + levelWeakSpawnTrackMinAddition * tier;
			} else if (model.actionId == "WeakerSpawn") {
				model.bloonType = bleedSpawnBloons[Math.Min(tier, 5)];
				model.spawnCount = Mathf.FloorToInt(baseBleedSpawnCount + levelBleedSpawnCountAddition * tier);
				model.spawnTrackMax = baseBleedSpawnTrackMax + levelBleedSpawnTrackMaxAddition * tier;
				model.spawnTrackMin = baseBLeedSpawnTrackMin + levelBleedSpawnTrackMinAddition * tier;
			}
		}
	}
}