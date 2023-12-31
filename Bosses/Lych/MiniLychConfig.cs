﻿using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace BTD6Rogue;

public static class MiniLychConfig {

    // General Stats
    public static readonly float baseMaxHealth = 1000;
    public static readonly float levelMaxHealthMultiplier = 2;

    public static readonly float baseSpeed = 5;
    public static readonly float levelSpeedAddition = 1f;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    // Time Trigger Model
    public static readonly float baseTimeInterval = 10;
    public static readonly float levelTimeIntervalAddition = -1;

    // Drain Lives Model
    public static readonly float baseDrainLives = 2;
    public static readonly float levelDrainLives = 1;

    public static void ApplyMiniLychSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = (int)(baseMaxHealth * (levelMaxHealthMultiplier * level) * multiplier);
        if (level == 0) { bloonModel.maxHealth = (int)(baseMaxHealth * multiplier); }

        bloonModel.leakDamage = 99999f;
        bloonModel.speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
        bloonModel.Speed = (baseSpeed + levelSpeedAddition * level) * multiplier;

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = (baseTimeInterval + levelTimeIntervalAddition * level) * multiplier;
        }

        foreach (DrainLivesActionModel model in bloonModel.GetBehaviors<DrainLivesActionModel>()) {
            model.livesDrained = Mathf.FloorToInt((baseDrainLives + levelDrainLives * level) * multiplier);
        }
    }
}
