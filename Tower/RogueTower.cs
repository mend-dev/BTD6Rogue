using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD6Rogue;

// Abstract implementation for towers to be used within a BTD6Rogue game
// Every tower needs an equivalent RogueTower to function properly
public abstract class RogueTower : NamedModContent {
    public abstract string BaseTowerId { get; } // Tower ID to access it during games

    // Dictionary which maps a given path and tier to a list of tower tags
    // The strings are written in the general XXX format when talking about a specific upgrade
    // To make sure Enchanted Eyesight for Dart Monkey has the Camo Tag
    // baseTags["002"] = ["Camo"];
    // To make sure the Bomb Shooter always has the Lead Tag
    // baseTags["000"] = ["Lead"];
    // With the dictionary being gotten from the corrosponding RogueTower
    // Tags are used to attach specific information to a given tower, path, and tier
    // Used in other mechanics of BTD6Rogue
    public abstract Dictionary<string, TowerTag[]> TowerTags { get; }

    // Going forward I want to make an "optional" dictionary that maps to all of the upgrade paths of a tower which can contain tags and ranges
    // Optional as it should be able to automatically generate (both so I have less work and also to provide functionality for modded towers)
    public abstract Vector2Int[] TowerAmountRanges { get; }

	// Get the RogueTower's TowerModel at 0-0-0
	public virtual TowerModel GetBaseTower() {
        return Game.instance.model.GetTowerModel(BaseTowerId);
    }

	// Get the RogueTower's TowerModel at a path and tier of that path
	// TODO: make it so it can get crosspaths, additionally combine functionality with getbasetower
	public virtual TowerModel GetTower(int[] tiers) {
        return Game.instance.model.GetTowerModel(BaseTowerId, tiers[0], tiers[1], tiers[2]);
    }

    // Generate a random number based off the tower amount range set for a RogueTower
    public virtual int GetTowerAmount(int[] tiers) {
		int path = Array.IndexOf(tiers, tiers.Max());
		if (TowerAmountRanges[path].x == 0 && TowerAmountRanges[path].y == 0) {
            return new System.Random().Next(1, 4);
        } else {
            return new System.Random().Next(TowerAmountRanges[path].x, TowerAmountRanges[path].y + 1);
        }
    }

    public override void Register() {}
}
