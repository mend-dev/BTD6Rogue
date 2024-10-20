using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors.Actions;

namespace BTD6Rogue;

public class PhayzeBoss : RogueBoss {
	public override string BossName => "Phayze";

	public static readonly float baseMaxHealth = 1500;
	public static readonly float levelHealthModifier = 2f;

	public static readonly float baseSpeed = 1.25f;
	public static readonly float levelSpeedIncrease = 0.25f;

	public static readonly float baseDashSpeed = 15f;
	public static readonly float levelDashSpeed = 0;
	public static readonly float baseDashDistance = 0.1f;
	public static readonly float levelDashDistance = 0;

	public static readonly float baseShield = 1000;
	public static readonly float levelShieldMultiplier = 2f;

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;

		foreach (GenerateShieldActionModel model in bloonModel.GetBehaviors<GenerateShieldActionModel>()) {
			model.amount = baseShield * (levelShieldMultiplier * tier);
			if (tier == 0) { model.amount = baseShield; }
		}
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (DashForwardsAction behavior in bloon.GetBloonBehaviors<DashForwardsAction>()) {
			DashForwardsActionModel model = behavior.dashForwardsActionModel;
			model.speedMultiplier = (baseDashSpeed + levelDashSpeed * tier);
			model.dashDistance = (baseDashDistance + levelDashDistance * tier);
		}

		foreach (WaitForSecondsAction behavior in bloon.GetBloonBehaviors<WaitForSecondsAction>()) {
			WaitForSecondsActionModel model = behavior.waitForSecondsActionModel;
			if (model.actionId == "RestoreTimerEffects") {
				model.delayTime = 15f;
			} else if (model.actionId == "SkullDelay") {
				model.delayTime = 3f;
			}
		}

		foreach (PhayzeBehavior behavior in bloon.GetBloonBehaviors<PhayzeBehavior>()) {
			PhayzeBehaviorModel model = behavior.phayzeBehaviorModel;
			model.shieldSpeedBoost = 1.25f;
		}

		foreach (TimeTrigger behavior in bloon.GetBloonBehaviors<TimeTrigger>()) {
			TimeTriggerModel model = behavior.timeTriggerModel;
			model.interval = 25f;
		}

		foreach (ThrowBloonsAction behavior in bloon.GetBloonBehaviors<ThrowBloonsAction>()) {
			ThrowBloonsActionModel model = behavior.throwBloonsActionModel;
			model.offsetMin = 2.5f;
			model.offsetMax = 20f;
		}
	}
}
