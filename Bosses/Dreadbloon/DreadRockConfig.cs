using Il2CppAssets.Scripts.Models.Bloons;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class DreadRockConfig {

    // General Stats
    public static readonly float baseMaxHealth = 25;
    public static readonly float levelMaxHealthMultiplier = 2.5f;

    public static readonly float baseSpeed = 1f;
    public static readonly float levelSpeedAddition = 0.25f;

    public static readonly float baseLeakDamage = 25;
    public static readonly float levelLeakDamageAddition = 0;

    // Difficulty Multiplier
    public static readonly Dictionary<string, float> difficultyMultipliers = new Dictionary<string, float>() {
        ["Poppable"] = 0.7f,
        ["Easy"] = 0.85f,
        ["Medium"] = 1f,
        ["Hard"] = 1.15f,
        ["Impoppable"] = 1.3f
    };

    public static void ApplyDreadRockSettings(BloonModel bloonModel, string difficulty, int level) {
        float multiplier = difficultyMultipliers[difficulty];

        bloonModel.maxHealth = baseMaxHealth * (levelMaxHealthMultiplier * level) * multiplier;
        if (level == 0) { bloonModel.maxHealth = baseMaxHealth * multiplier; }

        bloonModel.leakDamage = (baseLeakDamage + levelLeakDamageAddition * level) * multiplier; ;
        bloonModel.speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
        bloonModel.Speed = (baseSpeed + levelSpeedAddition * level) * multiplier;
    }
}