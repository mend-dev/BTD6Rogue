using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors.Actions;

namespace BTD6Rogue;

public class DreadbloonBoss : RogueBoss {
	public override string BossName => "Dreadbloon";

	public static readonly float baseMaxHealth = 1500;
	public static readonly float levelHealthModifier = 2f;

	public static readonly float baseSpeed = 1.2f;
	public static readonly float levelSpeedIncrease = 0.2f;

	public static readonly float baseDamageReduction = 0.5f;
	public static readonly float levelDamageReductionAddition = 0.1f;

	public static readonly float baseArmorAmount = 2000;
	public static readonly float levelArmorAmountMultiplier = 2f;
	public static readonly float baseSpeedMultiplier = 0.75f;
	public static readonly float levelSpeedMultiplierAddition = 0;

	public static readonly float baseInitialSpawnSize = 5;
	public static readonly float levelInitialSpawnSizeAddition = 5;
	public static readonly float baseTimeBetweenSpawns = 10;
	public static readonly float levelTimeBetweenSpawnsAddition = -1;

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;
		bloonModel.RemoveTag("Rock");

		foreach (GenerateArmourActionModel model in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
			model.amount = baseArmorAmount * (levelArmorAmountMultiplier * tier);
			if (tier == 0) { model.amount = baseArmorAmount; }
			model.speedMultiplier = (levelSpeedMultiplierAddition + levelSpeedMultiplierAddition * tier);
		}
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (DamageReduction behavior in bloon.GetBloonBehaviors<DamageReduction>()) {
			DamageReductionModel model = behavior.damageReductionModel;
			model.amount = baseDamageReduction + (levelDamageReductionAddition * tier);
		}

		foreach (SpawnBloonsUntilArmourBreaksAction behavior in bloon.GetBloonBehaviors<SpawnBloonsUntilArmourBreaksAction>()) {
			SpawnBloonsUntilArmourBreaksActionModel model = behavior.spawnBloonsFromEntranceActionModel;
			model.bloonType = "DreadRockBloonStandard1";
			model.initialSpawnPackSize = Mathf.FloorToInt((baseInitialSpawnSize + levelInitialSpawnSizeAddition * tier));
			model.timeBetweenSpawns = (baseTimeBetweenSpawns + levelTimeBetweenSpawnsAddition * tier);
		}
	}
}