using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class PhayzeConfig {

    // General Stats
    public static readonly float baseMaxHealth = 1000;
    public static readonly float levelMaxHealthMultiplier = 3f;

    public static readonly float baseSpeed = 1f;
    public static readonly float levelSpeedAddition = 0.1f;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    //
    public static readonly float baseDashSpeed = 20f;
    public static readonly float levelDashSpeed = 0;
    public static readonly float baseDashDistance = 0.04f;
    public static readonly float levelDashDistance = 0;

    //
    public static readonly float baseShield = 1000;
    public static readonly float levelShieldMultiplier = 3f;

    public static void ApplyPhayzeSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = (int)(baseMaxHealth * (levelMaxHealthMultiplier * level) * multiplier);
        if (level == 0) { bloonModel.maxHealth = (int)(baseMaxHealth * multiplier); }

        bloonModel.leakDamage = 99999f;
        bloonModel.speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
        bloonModel.Speed = (baseSpeed + levelSpeedAddition * level) * multiplier;

        foreach (DashForwardsActionModel model in bloonModel.GetBehaviors<DashForwardsActionModel>()) {
            model.speedMultiplier = (baseDashSpeed + levelDashSpeed * level) * multiplier;
            model.dashDistance = (baseDashDistance + levelDashDistance * level) * multiplier;
        }

        foreach (GenerateShieldActionModel model in bloonModel.GetBehaviors<GenerateShieldActionModel>()) {
            model.amount = baseShield * (levelShieldMultiplier * level) * multiplier;
            if (level == 0) { model.amount = baseShield * multiplier; }
        }

        foreach (WaitForSecondsActionModel model in bloonModel.GetBehaviors<WaitForSecondsActionModel>()) {
            if (model.actionId == "RestoreTimerEffects") {
                model.delayTime = 12f;
            } else if (model.actionId == "SkullDelay") {
                model.delayTime = 2f;
            }
        }

        foreach (PhayzeBehaviorModel model in bloonModel.GetBehaviors<PhayzeBehaviorModel>()) {
            //model.powerLevels;
            model.shieldSpeedBoost = 1.3f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 24f;
        }

        foreach (ThrowBloonsActionModel model in bloonModel.GetBehaviors<ThrowBloonsActionModel>()) {
            model.offsetMin = 2.5f;
            model.offsetMax = 20f;
        }
    }
}