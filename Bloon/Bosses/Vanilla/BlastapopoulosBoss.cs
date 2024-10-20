using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using UnityEngine;

namespace BTD6Rogue;

public class BlastapopoulosBoss : RogueBoss {
	public override string BossName => "Blastapopoulos";

	public static readonly float baseMaxHealth = 3000;
	public static readonly float levelHealthModifier = 2.5f;

	public static readonly float baseSpeed = 2f;
	public static readonly float levelSpeedIncrease = 0.5f;

	// RangeReductionZoneModel
	public static readonly float baseRangeReduction = -0.04f;
	public static readonly float levelRangeReductionAddition = -0.02f;

	// AbilityCooldownZoneModel
	public static readonly float baseAbilityCooldown = -0.04f;
	public static readonly float levelAbilityCooldownAddition = -0.01f;

	// TimeTriggerModel for RemoveDot
	public static readonly float baseInterval = 4.0f;
	public static readonly float levelIntervalAddition = -0.4f;

	// CreatePropsOnBloonActionModel
	public static readonly float baseRockDuration = 20.0f;
	public static readonly float levelRockDurationAddition = 2.0f;

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (RangeReductionZone behavior in bloon.GetBloonBehaviors<RangeReductionZone>()) {
			RangeReductionZoneModel model = behavior.rangeReductionModel;
			model.rangeMultiplier = (baseRangeReduction + levelRangeReductionAddition * tier);
		}
		foreach (AbilityCooldownZone behavior in bloon.GetBloonBehaviors<AbilityCooldownZone>()) {
			AbilityCooldownZoneModel model = behavior.abilityCooldownZoneModel;
			model.multiplier = (baseAbilityCooldown + levelAbilityCooldownAddition * tier);
		}
		foreach (TimeTrigger behavior in bloon.GetBloonBehaviors<TimeTrigger>()) {
			TimeTriggerModel model = behavior.timeTriggerModel;
			model.interval = (baseInterval + levelIntervalAddition * tier);
		}
		foreach (CreatePropsOnBloonAction behavior in bloon.GetBloonBehaviors<CreatePropsOnBloonAction>()) {
			CreatePropsOnBloonActionModel model = behavior.createPropsModel;
			model.rockDuration = (baseRockDuration + levelRockDurationAddition * tier);
		}
	}
}