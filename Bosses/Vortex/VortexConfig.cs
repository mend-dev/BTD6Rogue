using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class VortexConfig {

    // General Stats
    public static readonly float baseMaxHealth = 5000;
    public static readonly float levelMaxHealthMultiplier = 3;

    public static readonly float baseSpeed = 2.5f;
    public static readonly float levelSpeedAddition = 0.25f;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    // Stun Towers in Radius Action Model
    public static readonly float baseStunRadius = 50f;
    public static readonly float levelStunRadiusAddition = 3f;
    public static readonly float baseStunDuration = 20f;
    public static readonly float levelStunDurationAddition = 2.5f;

    // Set Speed Percent Action Model
    public static readonly float baseBackupDistance = -100f;
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
    public static readonly float baseSpeedBoost = 1.5f;
    public static readonly float levelSpeedBoostAddition = 0.1f;
    public static readonly float baseDebuffRadius = 30f;
    public static readonly float levelDebuffRadiusAddition = 2f;

    public static void ApplyVortexSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = (int)(baseMaxHealth * (levelMaxHealthMultiplier * level) * multiplier);
        if (level == 0) { bloonModel.maxHealth = (int)(baseMaxHealth * multiplier); }

        bloonModel.leakDamage = 99999f;
        bloonModel.speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
        bloonModel.Speed = (baseSpeed + levelSpeedAddition * level) * multiplier;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>())
        {
            model.radius = (baseStunRadius + levelStunRadiusAddition * level) * multiplier;
            model.stunDuration = (baseStunDuration + levelStunDurationAddition * level) * multiplier;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>())
        {
            model.distance = (baseBackupDistance + levelBackupDistanceAddition * level) * multiplier;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>())
        {
            model.radius = (baseDestroyProjectileRadius + levelDestroyProjectileRadiusAddition * level) * multiplier;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>())
        {
            model.lifespan = (baseReflectProjectileLifespan + levelRelfectProjectileLifespanAddition * level) * multiplier;
            model.innerRadius = (baseReflectProjectileInnerRadius + levelReflectProjectileInnerRadiusAddition * level) * multiplier;
            model.outerRadius = (baseReflectProjectileOuterRadius + levelReflectProjectileOuterRadiusAddition * level) * multiplier;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>())
        {
            model.interval = (baseTimeInterval + levelTimeIntervalAddition * level) * multiplier;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>())
        {
            model.speedBoost = (baseSpeedBoost + levelSpeedBoostAddition * level) * multiplier;
            model.debuffInRadius = (baseDebuffRadius + levelDebuffRadiusAddition * level) * multiplier;
        }
    }
}