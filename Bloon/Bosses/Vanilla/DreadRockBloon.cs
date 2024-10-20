using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using UnityEngine;

namespace BTD6Rogue;

public class DreadRockBoss : RogueBoss {
	public override string BossName => "DreadRock";
	public override bool IsBoss => false;

	public static readonly float baseMaxHealth = 40;
	public static readonly float levelHealthModifier = 1.5f;

	public static readonly float baseSpeed = 1.2f;
	public static readonly float levelSpeedIncrease = 0.2f;

	public static readonly float baseLeakDamage = 25;
	public static readonly float levelLeakDamageAddition = 0;

	public override void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite) {
		bloonModel.maxHealth = Mathf.FloorToInt(baseMaxHealth * Mathf.Pow(levelHealthModifier, tier));
		bloonModel.speed = baseSpeed + levelSpeedIncrease * tier;
		bloonModel.leakDamage = (baseLeakDamage + levelLeakDamageAddition * tier);
	}

	public override void AdjustBloon(Bloon bloon, int tier, bool elite) {}
}