using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public static class LychConfig {

    // General Stats
    public static readonly float baseMaxHealth = 6500;
    public static readonly float levelMaxHealthMultiplier = 3;

    public static readonly float baseSpeed = 1.25f;
    public static readonly float levelSpeedAddition = 0.25f;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    // Time Trigger Model
    public static readonly float baseTimeInterval = 12f;
    public static readonly float levelTimeIntervalAddition = -0.5f;

    // Absorb Tower Buffs Action Model
    public static readonly float baseHealPerBuff = 0;
    public static readonly float levelHealPerBuff = 0;
    public static readonly float baseHealPercentPerBuff = 0.02f;
    public static readonly float levelHealPercentPerBuff = 0;
    public static readonly float baseAbsorbBuffRadius = 9999;
    public static readonly float levelAbsorbBuffRadius = 0;
    public static readonly float baseTowerFreezeDuration = 5;
    public static readonly float levelTowerFreezeDuration = 0;

    // Heal on Tower Sell Action Model
    public static readonly float baseHealAmount = 0;
    public static readonly float levelHealAmount = 0;
    public static readonly float baseHealPercentTier = 0.01f;
    public static readonly float levelHealPercentTier = 0;

    // Reanimate Moabs Model
    public static readonly float baseMaxRbe = 5000;
    public static readonly float levelMaxRbe = 0;
    public static readonly float basePauseMovementDuration = 1;
    public static readonly float levelPauseMovementDuration = 0;
    public static readonly float baseReanimatedSpeedMultiplier = 1.5f;
    public static readonly float levelReanimatedSpeedMutliplier = 0;
    public static readonly float baseReanimatedHealthMultiplier = 3;
    public static readonly float levelReanimatedHealthMultiplier = 0;
    public static readonly float baseTimeUntilBloonsMove = 1;
    public static readonly float levelTimeUntilBloonsMove = 0;

    // Speed Down Model
    public static readonly float baseSpeedDownPercent = 0.5f;
    public static readonly float levelSpeedDownPercentAddition = 0;

    public static void ApplyLychSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = (int)(baseMaxHealth * (levelMaxHealthMultiplier * level) * multiplier);
        if (level == 0) { bloonModel.maxHealth = (int)(baseMaxHealth * multiplier); }

        bloonModel.leakDamage = 99999f;
        bloonModel.speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
        bloonModel.Speed = (baseSpeed + levelSpeedAddition * level) * multiplier;

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = (baseTimeInterval + levelTimeIntervalAddition * level) * multiplier;
        }

        foreach (AbsorbTowerBuffsActionModel model in bloonModel.GetBehaviors<AbsorbTowerBuffsActionModel>())
        {
            model.healPerBuff = Mathf.FloorToInt((baseHealPerBuff + levelHealPerBuff * level) * multiplier);
            model.healPercentPerBuff = (baseHealPercentPerBuff + levelHealPercentPerBuff * level) * multiplier;
            model.radius = (baseAbsorbBuffRadius + levelAbsorbBuffRadius * level) * multiplier;
            model.towerFreezeDuration = (baseTowerFreezeDuration + levelTowerFreezeDuration * level) * multiplier;
        }

        foreach (HealOnTowerSellActionModel model in bloonModel.GetBehaviors<HealOnTowerSellActionModel>())
        {
            model.healAmount = Mathf.FloorToInt((baseHealAmount + levelHealAmount * level) * multiplier);
            model.healPercentForHighestTier = (baseHealPercentTier + levelHealPercentTier * level) * multiplier;
        }

        foreach (ReanimateMoabsActionModel model in bloonModel.GetBehaviors<ReanimateMoabsActionModel>())
        {
            model.maxRbe = Mathf.FloorToInt((baseMaxRbe + levelMaxRbe * level) * multiplier);
            model.pauseMovementDuration = (basePauseMovementDuration + levelPauseMovementDuration * level) * multiplier;
            model.speedMultiplier = (baseReanimatedSpeedMultiplier + levelReanimatedSpeedMutliplier * level) * multiplier;
            model.healthMultiplier = (baseReanimatedHealthMultiplier + levelReanimatedHealthMultiplier * level) * multiplier;
            model.miniMeModelId = "BTD6Rogue-" + difficulty + "RogueMiniLych" + (level + 1);
            model.timeUntilBloonsMove = (baseTimeUntilBloonsMove + levelTimeUntilBloonsMove * level) * multiplier;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>())
        {
            if (model.actionId == "SpeedDown")
            {
                model.percent = (baseSpeedDownPercent + levelSpeedDownPercentAddition * level) * multiplier;
            }
        }
    }
}