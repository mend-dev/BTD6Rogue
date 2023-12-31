﻿using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public static class DreadbloonConfig {

    // General Stats
    public static readonly float baseMaxHealth = 2000;
    public static readonly float levelMaxHealthMultiplier = 3;

    public static readonly float baseSpeed = 1;
    public static readonly float levelSpeedAddition = 0.25f;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    //
    public static readonly float baseDamageReduction = 0.5f;
    public static readonly float levelDamageReductionAddition = 0.1f;

    //
    public static readonly float baseArmorAmount = 100;
    public static readonly float levelArmorAmountMultiplier = 3;
    public static readonly float baseSpeedMultiplier = 1f;
    public static readonly float levelSpeedMultiplierAddition = 0;

    //
    public static readonly float baseInitialSpawnSize = 5;
    public static readonly float levelInitialSpawnSizeAddition = 5;
    public static readonly float baseTimeBetweenSpawns = 10;
    public static readonly float levelTimeBetweenSpawnsAddition = -1;

    public static void ApplyDreadbloonSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = (int)(baseMaxHealth * (levelMaxHealthMultiplier * level) * multiplier);
        if (level == 0) { bloonModel.maxHealth = (int)(baseMaxHealth * multiplier); }

        bloonModel.leakDamage = 99999f;
        bloonModel.speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
        bloonModel.Speed = (baseSpeed + levelSpeedAddition * level) * multiplier;

        foreach (DamageReductionModel model in bloonModel.GetBehaviors<DamageReductionModel>()) {
            model.amount = 0.5f;
        }

        foreach (GenerateArmourActionModel model in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            model.amount = baseArmorAmount * (levelArmorAmountMultiplier * level) * multiplier;
            if (level == 0) { model.amount = baseArmorAmount * multiplier; }
            model.speedMultiplier = (levelSpeedMultiplierAddition + levelSpeedMultiplierAddition * level) * multiplier;
        }

        foreach (SpawnBloonsUntilArmourBreaksActionModel model in bloonModel.GetBehaviors<SpawnBloonsUntilArmourBreaksActionModel>()) {
            model.bloonType = "BTD6Rogue-" + difficulty + "RogueDreadRock" + (level + 1);
            model.initialSpawnPackSize = Mathf.FloorToInt((baseInitialSpawnSize + levelInitialSpawnSizeAddition * level) * multiplier);
            model.timeBetweenSpawns = (baseTimeBetweenSpawns + levelTimeBetweenSpawnsAddition * level) * multiplier;
        }

        bloonModel.RemoveTag("Rock");
    }
}