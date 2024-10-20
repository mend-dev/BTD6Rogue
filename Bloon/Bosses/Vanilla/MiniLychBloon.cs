using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;

namespace BTD6Rogue;

public class MiniLychBloon : RogueBoss {
	public override string BossName => "MiniLych";
	public override bool IsBoss => false;

	public static readonly float baseMaxHealth = 500;
	public static readonly float levelHealthModifier = 2;

	public static readonly float baseSpeed = 2f;
	public static readonly float levelSpeedIncrease = 1.5f;

	public static readonly float baseTimeInterval = 15;
	public static readonly float levelTimeIntervalAddition = -1;

	public static readonly float baseDrainLives = 2;
	public static readonly float levelDrainLives = 1;

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

		foreach (DrainLivesAction behavior in bloon.GetBloonBehaviors<DrainLivesAction>()) {
			DrainLivesActionModel model = behavior.drainLivesActionModel;
			model.livesDrained = Mathf.FloorToInt((baseDrainLives + levelDrainLives * tier));
		}
	}
}
