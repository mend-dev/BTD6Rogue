using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public static readonly ModSettingCategory TowerSettings = new("Tower Settings") { collapsed = true };

    public static readonly ModSettingInt BaseStartingTowers = new(1) { category = TowerSettings };

    public static readonly ModSettingInt AdditionalBeginnerMapStartingTowers = new(0) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalIntermediateMapStartingTowers = new(1) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalAdvancedMapStartingTowers = new(2) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalExpertMapStartingTowers = new(3) { category = TowerSettings };

    public static readonly ModSettingInt AdditionalPoppableStartingTowers = new(0) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalEasyStartingTowers = new(0) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalMediumStartingTowers = new(1) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalHardStartingTowers = new(2) { category = TowerSettings };
    public static readonly ModSettingInt AdditionalImpoppableStartingTowers = new(3) { category = TowerSettings };

    public static readonly ModSettingBool RandomTowers = new(true) { category = TowerSettings };
    public static readonly ModSettingBool LimitAllTowersOnChoice = new(true) { category = TowerSettings };
    
    public static readonly ModSettingInt TowerChoices = new(3) { category = TowerSettings };
    
    public static readonly ModSettingInt TowersStartAtRound = new(5) { category = TowerSettings };
    public static readonly ModSettingInt RoundsPerRandomTower = new(10) { category = TowerSettings };

    public static readonly ModSettingInt Tier1MinimumRound = new(1) { category = TowerSettings, displayName = "Tier 1 Minimum Round", description = "This is the minimum round that tier 1's appear in the Random Tower Pool (this is overwritten by Tier 2 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier2MinimumRound = new(1) { category = TowerSettings, displayName = "Tier 2 Minimum Round", description = "This is the minimum round that tier 2's appear in the Random Tower Pool (this is overwritten by Tier 3 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier3MinimumRound = new(20) { category = TowerSettings, displayName = "Tier 3 Minimum Round", description = "This is the minimum round that tier 3's appear in the Random Tower Pool (this is overwritten by Tier 4 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier4MinimumRound = new(40) { category = TowerSettings, displayName = "Tier 4 Minimum Round", description = "This is the minimum round that tier 4's appear in the Random Tower Pool (this is overwritten by Tier 5 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier5MinimumRound = new(60) { category = TowerSettings, displayName = "Tier 5 Minimum Round", description = "This is the minimum round that tier 5's appear in the Random Tower Pool (this overwrites the Tier 4 pool, but doesn't get overwritten by Paragons)", min = 1, max = 999 }; // Doesn't Work
    
    public static readonly ModSettingBool ModTowers = new(false) { category = TowerSettings };
    
    // Banana Farmer
    // Pontoon
    // Inflatable Pool

    public static readonly ModSettingBool LimitUpgrades = new(true) { category = TowerSettings };
}