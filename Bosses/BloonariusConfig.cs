using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;

namespace BTD6Rogue;

public static class BloonariusConfig {

    // General Stats
    public static readonly float baseMaxHealth = 7500f;
    public static readonly float levelMaxHealthMultiplier = 2f;

    public static readonly float baseSpeed = 0.8f;
    public static readonly float levelSpeedAddition = 0f;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    // Strong Spawn
    public static readonly int baseStrongSpawnCount = 30;
    public static readonly float levelStrongSpawnCountAddition = -5;
    public static readonly int baseStrongSpawnDistAhead = 40;
    public static readonly float levelStrongSpawnDistAheadAddition = 0;
    public static readonly List<string> strongSpawnBloons = new List<string>() {
        BloonType.Yellow,
        BloonType.Zebra,
        BloonType.Rainbow,
        BloonType.Ceramic,
        BloonType.Moab,
        BloonType.Bfb
    };

    // Weak Spawn
    public static readonly int baseWeakSpawnCount = 30;
    public static readonly float levelWeakSpawnCountAddition = -10;
    public static readonly float baseWeakSpawnTrackMax = 0.4f;
    public static readonly float levelWeakSpawnTrackMaxAddition = 0;
    public static readonly float baseWeakSpawnTrackMin = 0.1f;
    public static readonly float levelWeakSpawnTrackMinAddition = 0;
    public static readonly List<string> weakSpawnBloons = new List<string>() {
        BloonType.Green,
        BloonType.Pink,
        BloonType.Zebra,
        BloonType.Rainbow,
        BloonType.Ceramic,
        BloonType.Moab
    };

    // Bloon Bleed
    public static readonly int baseBleedSpawnCount = 10;
    public static readonly float levelBleedSpawnCountAddition = 0;
    public static readonly float baseBleedSpawnTrackMax = 0.4f;
    public static readonly float levelBleedSpawnTrackMaxAddition = 0;
    public static readonly float baseBLeedSpawnTrackMin = 0.1f;
    public static readonly float levelBleedSpawnTrackMinAddition = 0;
    public static readonly List<string> bleedSpawnBloons = new List<string>() {
        BloonType.Blue,
        BloonType.Yellow,
        BloonType.Pink,
        BloonType.Zebra,
        BloonType.Rainbow,
        BloonType.Ceramic
    };

    public static void ApplyBloonariusSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = baseMaxHealth * level * multiplier;
        if (level == 0) { bloonModel.maxHealth = baseMaxHealth * multiplier; }

        bloonModel.leakDamage = 99999f;
        bloonModel.speed = (baseSpeed + (levelSpeedAddition * level)) * multiplier;
        bloonModel.Speed = (baseSpeed + (levelSpeedAddition * level)) * multiplier;

        foreach (SpawnBloonsActionModel model in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (model.actionId == "StrongSpawn") {
                model.bloonType = strongSpawnBloons[level];
                model.spawnCount = Mathf.FloorToInt((baseStrongSpawnCount + (levelStrongSpawnCountAddition * level)) * multiplier);
                model.spawnDistAhead = (baseStrongSpawnDistAhead + (levelStrongSpawnDistAheadAddition * level)) * multiplier;
            } else if (model.actionId == "WeakSpawn") {
                model.bloonType = weakSpawnBloons[level];
                model.spawnCount = Mathf.FloorToInt((baseWeakSpawnCount + (levelWeakSpawnCountAddition * level)) * multiplier);
                model.spawnTrackMax = (baseWeakSpawnTrackMax + (levelWeakSpawnTrackMaxAddition * level)) * multiplier;
                model.spawnTrackMin = (baseWeakSpawnTrackMin + (levelWeakSpawnTrackMinAddition * level)) * multiplier;
            } else if (model.actionId == "WeakerSpawn") {
                model.bloonType = bleedSpawnBloons[level];
                model.spawnCount = Mathf.FloorToInt((baseBleedSpawnCount + (levelBleedSpawnCountAddition * level)) * multiplier);
                model.spawnTrackMax = (baseBleedSpawnTrackMax + (levelBleedSpawnTrackMaxAddition * level)) * multiplier;
                model.spawnTrackMin = (baseBLeedSpawnTrackMin + (levelBleedSpawnTrackMinAddition * level)) * multiplier;
            }
        }

    }
}