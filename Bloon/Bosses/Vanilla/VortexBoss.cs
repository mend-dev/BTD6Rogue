using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors.Actions;

namespace BTD6Rogue;

public class VortexBoss : RogueBoss {
	public override string BossName => "Vortex";

	public static readonly float baseMaxHealth = 3000;
	public static readonly float levelHealthModifier = 2f;

	public static readonly float baseSpeed = 2.5f;
	public static readonly float levelSpeedIncrease = 0.5f;

	// Stun Towers in Radius Action Model
	public static readonly float baseStunRadius = 40f;
	public static readonly float levelStunRadiusAddition = 3f;
	public static readonly float baseStunDuration = 15f;
	public static readonly float levelStunDurationAddition = 2.5f;

	// Set Speed Percent Action Model
	public static readonly float baseBackupDistance = -80f;
	public static readonly float levelBackupDistanceAddition = 10f;

	// Destroy Projectiles in Radius Action Model
	public static readonly float baseDestroyProjectileRadius = 40f;
	public static readonly float levelDestroyProjectileRadiusAddition = 2f;

	// Reflect Projectiles in Radius Action Model
	public static readonly float baseReflectProjectileLifespan = 5f;
	public static readonly float levelRelfectProjectileLifespanAddition = 1f;
	public static readonly float baseReflectProjectileInnerRadius = 60f;
	public static readonly float levelReflectProjectileInnerRadiusAddition = 0f;
	public static readonly float baseReflectProjectileOuterRadius = 70f;
	public static readonly float levelReflectProjectileOuterRadiusAddition = 0f;

	// Time Trigger Model
	public static readonly float baseTimeInterval = 30f;
	public static readonly float levelTimeIntervalAddition = -4f;

	// Buff Bloon Speed Model
	public static readonly float baseSpeedBoost = 1f;
	public static readonly float levelSpeedBoostAddition = 0.2f;
	public static readonly float baseDebuffRadius = 25f;
	public static readonly float levelDebuffRadiusAddition = 2.5f;

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = 99999f;
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {
		foreach (StunTowersInRadiusAction behavior in bloon.GetBloonBehaviors<StunTowersInRadiusAction>()) {
			StunTowersInRadiusActionModel model = behavior.modl;
			model.radius = (baseStunRadius + levelStunRadiusAddition * tier);
			model.stunDuration = (baseStunDuration + levelStunDurationAddition * tier);
		}

		foreach (SetSpeedPercentAction behavior in bloon.GetBloonBehaviors<SetSpeedPercentAction>()) {
			SetSpeedPercentActionModel model = behavior.setSpeedPercentActionModel;
			model.distance = (baseBackupDistance + levelBackupDistanceAddition * tier);
		}

		foreach (DestroyProjectilesInRadiusAction behavior in bloon.GetBloonBehaviors<DestroyProjectilesInRadiusAction>()) {
			DestroyProjectilesInRadiusActionModel model = behavior.modl;
			model.radius = (baseDestroyProjectileRadius + levelDestroyProjectileRadiusAddition * tier);
		}

		foreach (ReflectProjectilesInRadiusAction behavior in bloon.GetBloonBehaviors<ReflectProjectilesInRadiusAction>()) {
			ReflectProjectilesInRadiusActionModel model = behavior.modl;
			model.lifespan = (baseReflectProjectileLifespan + levelRelfectProjectileLifespanAddition * tier);
			model.innerRadius = (baseReflectProjectileInnerRadius + levelReflectProjectileInnerRadiusAddition * tier);
			model.outerRadius = (baseReflectProjectileOuterRadius + levelReflectProjectileOuterRadiusAddition * tier);
		}

		foreach (TimeTrigger behavior in bloon.GetBloonBehaviors<TimeTrigger>()) {
			TimeTriggerModel model = behavior.timeTriggerModel;
			model.interval = (baseTimeInterval + levelTimeIntervalAddition * tier);
		}

		foreach (BuffBloonSpeed behavior in bloon.GetBloonBehaviors<BuffBloonSpeed>()) {
			BuffBloonSpeedModel model = behavior.modl;
			model.speedBoost = (baseSpeedBoost + levelSpeedBoostAddition * tier);
			model.debuffInRadius = (baseDebuffRadius + levelDebuffRadiusAddition * tier);
		}

	}
}