using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BloonType = BTD_Mod_Helper.Api.Enums.BloonType;

namespace BTD6Rogue;


public class LychBoss : RogueBoss {
	public override string BossName => "Lych";

	public static readonly float baseMaxHealth = 4000;
	public static readonly float levelHealthModifier = 2.5f;

	public static readonly float baseSpeed = 1.2f;
	public static readonly float levelSpeedIncrease = 0.2f;

	public static readonly float baseTimeInterval = 14f;
	public static readonly float levelTimeIntervalAddition = -0.5f;

	public static readonly float baseHealPerBuff = 0;
	public static readonly float levelHealPerBuff = 0;
	public static readonly float baseHealPercentPerBuff = 0.02f;
	public static readonly float levelHealPercentPerBuff = 0;
	public static readonly float baseAbsorbBuffRadius = 9999;
	public static readonly float levelAbsorbBuffRadius = 0;
	public static readonly float baseTowerFreezeDuration = 5;
	public static readonly float levelTowerFreezeDuration = 0;

	public static readonly float baseHealAmount = 0;
	public static readonly float levelHealAmount = 0;
	public static readonly float baseHealPercentTier = 0.01f;
	public static readonly float levelHealPercentTier = 0;

	public static readonly float baseMaxRbe = 250;
	public static readonly float levelMaxRbe = 100;
	public static readonly float basePauseMovementDuration = 1;
	public static readonly float levelPauseMovementDuration = 0;
	public static readonly float baseReanimatedSpeedMultiplier = 0.5f;
	public static readonly float levelReanimatedSpeedMutliplier = 0;
	public static readonly float baseReanimatedHealthMultiplier = 0.5f;
	public static readonly float levelReanimatedHealthMultiplier = 0;
	public static readonly float baseTimeUntilBloonsMove = 8f;
	public static readonly float levelTimeUntilBloonsMove = 0;

	public static readonly float baseSpeedDownPercent = 0.5f;
	public static readonly float levelSpeedDownPercentAddition = 0;

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (TimeTrigger behavior in bloon.GetBloonBehaviors<TimeTrigger>()) {
			TimeTriggerModel model = behavior.timeTriggerModel;
			model.interval = (baseTimeInterval + levelTimeIntervalAddition * tier);
		}

		foreach (AbsorbTowerBuffsAction behavior in bloon.GetBloonBehaviors<AbsorbTowerBuffsAction>()) {
			AbsorbTowerBuffsActionModel model = behavior.absorbTowerBuffsActionModel;
			model.healPerBuff = Mathf.FloorToInt((baseHealPerBuff + levelHealPerBuff * tier));
			model.healPercentPerBuff = (baseHealPercentPerBuff + levelHealPercentPerBuff * tier);
			model.radius = (baseAbsorbBuffRadius + levelAbsorbBuffRadius * tier);
			model.towerFreezeDuration = (baseTowerFreezeDuration + levelTowerFreezeDuration * tier);
		}

		foreach (HealOnTowerSellAction behavior in bloon.GetBloonBehaviors<HealOnTowerSellAction>()) {
			HealOnTowerSellActionModel model = behavior.healOnTowerSellActionModel;
			model.healAmount = Mathf.FloorToInt((baseHealAmount + levelHealAmount * tier));
			model.healPercentForHighestTier = (baseHealPercentTier + levelHealPercentTier *	tier);
		}

		foreach (ReanimateMoabsAction behavior in bloon.GetBloonBehaviors<ReanimateMoabsAction>()) {
			ReanimateMoabsActionModel model = behavior.reanimateMoabsActionModel;
			model.maxRbe = Mathf.FloorToInt((baseMaxRbe + levelMaxRbe * tier));
			model.pauseMovementDuration = (basePauseMovementDuration + levelPauseMovementDuration * tier);
			model.speedMultiplier = (baseReanimatedSpeedMultiplier + levelReanimatedSpeedMutliplier * tier);
			model.healthMultiplier = (baseReanimatedHealthMultiplier + levelReanimatedHealthMultiplier * tier);
			model.miniMeModelId = BloonType.MiniLych1;
			model.timeUntilBloonsMove = (baseTimeUntilBloonsMove + levelTimeUntilBloonsMove * tier);
		}

		foreach (SetSpeedPercentAction behavior in bloon.GetBloonBehaviors<SetSpeedPercentAction>()) {
			SetSpeedPercentActionModel model = behavior.setSpeedPercentActionModel;
			if (model.actionId == "SpeedDown") {
				model.percent = (baseSpeedDownPercent + levelSpeedDownPercentAddition * tier);
			}
		}
	}
}