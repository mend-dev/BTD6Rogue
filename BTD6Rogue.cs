using MelonLoader;
using BTD_Mod_Helper;
using BTD6Rogue;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Input;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;

[assembly: MelonInfo(typeof(BTD6Rogue.BTD6Rogue), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6Rogue;

public class RogueTower {
    public string baseId = ""; // Base ID of the Tower Model
    public int[] limitPaths = new int[3] { 2, 2, 2 }; // Limited tier of each path when upgrading in game
    public int[] maxPaths = new int[3] { 0, 0, 0 }; // Max tier of each path in the base Tower Model
    public bool[] lockedPaths = new bool[3] { false, false, false }; // Whether or not the path is locked out of being in the panel
    public bool[] hasPaths = new bool[3] { false, false, false }; // Whether or not the base Tower Model even has that path
    public bool isHero = false; // Whether or not the tower is a hero
    public int count = 0; // How many the player has in their inventory
    public bool noPaths = true; // If the tower has no paths
    public bool lockedTower = false; // If the tower is unable to show up in choices
    public TowerModel baseTowerModel = null!; // Base tower model for the rogue tower
}

public class BTD6Rogue : BloonsTD6Mod {

    public static BTD6Rogue mod = null!;
    public RoundGenerator roundGenerator = null!;
    public Dictionary<string, RogueTower> rogueTowers = new Dictionary<string, RogueTower>();
    public List<string> selectedHeroes = new List<string>();
    public RogueDifficulty difficulty = null!;
    public Dictionary<string, int> modifiers = new Dictionary<string, int>();

    public int towerCount = 0;
    public bool uiOpen = false;
    public float previousIncrease = 0;

    #region Mod Settings
    public static readonly ModSettingHotkey FasterForwardHotkey = new(KeyCode.F1); // Doesn't Work
    public static readonly ModSettingBool DisablePatchesInSandbox = new(true);

    public static readonly ModSettingCategory RoundSettings = new("Round Settings") { collapsed = true };
    public static readonly ModSettingBool RandomRounds = new(true) { category = RoundSettings };

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
    public static readonly ModSettingBool LimitAllTowersOnChoice = new(true) { category = TowerSettings }; // No work
    public static readonly ModSettingInt TowerChoices = new(3) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt TowersStartAtRound = new(5) { category = TowerSettings };
    public static readonly ModSettingInt RoundsPerRandomTower = new(10) { category = TowerSettings };
    public static readonly ModSettingInt Tier1MinimumRound = new(1) { category = TowerSettings, displayName = "Tier 1 Minimum Round", description = "This is the minimum round that tier 1's appear in the Random Tower Pool (this is overwritten by Tier 2 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier2MinimumRound = new(1) { category = TowerSettings, displayName = "Tier 2 Minimum Round", description = "This is the minimum round that tier 2's appear in the Random Tower Pool (this is overwritten by Tier 3 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier3MinimumRound = new(20) { category = TowerSettings, displayName = "Tier 3 Minimum Round", description = "This is the minimum round that tier 3's appear in the Random Tower Pool (this is overwritten by Tier 4 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier4MinimumRound = new(40) { category = TowerSettings, displayName = "Tier 4 Minimum Round", description = "This is the minimum round that tier 4's appear in the Random Tower Pool (this is overwritten by Tier 5 Minimum Round)", min = 1, max = 999 };
    public static readonly ModSettingInt Tier5MinimumRound = new(60) { category = TowerSettings, displayName = "Tier 5 Minimum Round", description = "This is the minimum round that tier 5's appear in the Random Tower Pool (this overwrites the Tier 4 pool, but doesn't get overwritten by Paragons)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingInt ParagonMinimumRound = new(80) { category = TowerSettings, displayName = "Paragon Minimum Round", description = "This is the minimum round that paragons appear in the Random Tower Pool (this doesn't overwrite Tier 5's appearing)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingBool ModTowers = new(false) { category = TowerSettings }; // Doesn't Work
    // Banana Farmer
    // Pontoon
    // Inflatable Pool

    public static readonly ModSettingBool LimitUpgrades = new(true); // Doesn't Work

    public static readonly ModSettingCategory HeroSettings = new("Hero Settings") { collapsed = true };
    public static readonly ModSettingBool MultipleHeroes = new(true) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingBool HeroXpSplit = new(false) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingInt StartingHeroes = new(1) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingInt HeroesStartAtRound = new(40) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerRandomHero = new(40) { category = HeroSettings }; // Doesn't Work

    public static readonly ModSettingCategory ArtifactSettings = new("Artifact Settings") { collapsed = true };
    public static readonly ModSettingBool Artifacts = new(true) { category = ArtifactSettings }; // Doesn't Work
    public static readonly ModSettingInt ArtifactsStartAtRound = new(25) { category = ArtifactSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerArtifact = new(25) { category = ArtifactSettings }; // Doesn't Work

    public static readonly ModSettingCategory ModifierSettings = new("Modifier Settings") { collapsed = true };
    public static readonly ModSettingBool Modifiers = new(true) { category = ModifierSettings }; // Doesn't Work
    public static readonly ModSettingInt ModifiersStartAtRound = new(20) { category = ModifierSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerModifier = new(20) { category = ModifierSettings }; // Doesn't Work

    public static readonly ModSettingCategory BossSettings = new("Boss Settings") { collapsed = true };
    public static readonly ModSettingBool Bosses = new(true) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingInt BossesStartAtRound = new(20) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerBoss = new(20) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingBool BloonariusBoss = new(true) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingBool VortexBoss = new(true) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingBool LychBoss = new(true) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingBool DreadbloonBoss = new(true) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingBool ModBosses = new(false) { category = BossSettings }; // Doesn't Work
    #endregion

    public override void OnApplicationStart() {
        mod = this;
        roundGenerator = new RoundGenerator();
        ModHelper.Msg<BTD6Rogue>("BTD6Rogue loaded!");
    }

    public string overrideBoss = "RogueBloonarius";

    public override void OnUpdate() {
        base.OnUpdate();

        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            overrideBoss = "RogueBloonarius";
        } else if (Input.GetKeyDown(KeyCode.Keypad1)) {
            overrideBoss = "RogueDreadbloon";
        } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
            overrideBoss = "RogueLych";
        } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
            overrideBoss = "RogueVortex";
        }
    }

    public void StartRogueGame(InGame __instance) {

        // Get rid of all ui panels if they exist
        DifficultyChoicePanel.uiPanel?.Destroy();
        HeroChoicePanel.uiPanel?.Destroy();
        InitialHeroChoicePanel.uiPanel?.Destroy();
        InitialTowerChoicePanel.uiPanel?.Destroy();
        TowerChoicePanel.uiPanel?.Destroy();

        // Check if the user is in the right gamemode
        if (__instance.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }

        // Clear all the previous information stored for the game
        rogueTowers.Clear();
        selectedHeroes.Clear();
        modifiers.Clear();

        if (RandomTowers) {
            // Get the Tower Inventory
            TowerInventory towerInventory = __instance.GetTowerInventory();
            Il2CppSystem.Collections.Generic.Dictionary<string, int> towerMaxes = towerInventory.GetTowerInventoryMaxes();

            foreach (TowerModel towerModel in __instance.GetGameModel().towers) {
                string baseId = towerModel.baseId;
                if (!towerModel.IsStandardTower() && towerModel.towerSet != TowerSet.Hero) { continue; }
                if (towerModel.GetTowerId() == "TransformedMonkey" || towerModel.GetTowerId() == "TransformedBaseMonkey") { continue; }
                if (towerModel.towerSet == TowerSet.Hero && towerModel.upgrades.Length == 0) { continue; }
                if ((towerModel.towerSet != TowerSet.Hero && towerModel.tier != 0) || (towerModel.towerSet == TowerSet.Hero && towerModel.tier != 1)) { continue; }
                if (towerModel.towerSet == TowerSet.None) { continue; }
                if (towerModel.towerSet == TowerSet.Paragon) { continue; }
                if (towerModel.towerSet == TowerSet.Items) { continue; }

                if (towerMaxes.ContainsKey(baseId)) {
                    towerMaxes[baseId] = 0;
                } else {
                    towerMaxes.Add(baseId, 0);
                }

                if (rogueTowers.ContainsKey(baseId)) {
                    rogueTowers[baseId] = new RogueTower();
                } else {
                    rogueTowers.Add(baseId, new RogueTower());
                }

                rogueTowers[baseId].baseTowerModel = towerModel;

                rogueTowers[baseId].baseId = baseId;

                if (towerModel.towerSet == TowerSet.Hero) {
                    rogueTowers[baseId].isHero = true;
                    continue;
                }

                for (int i = 0; i < 3; i++) {
                    for (int j = 1; j < 6; j++) {
                        if (towerModel.GetUpgrade(i, j) != null) {
                            rogueTowers[baseId].noPaths = false;
                            rogueTowers[baseId].hasPaths[i] = true;
                            rogueTowers[baseId].maxPaths[i] = j;
                        }
                    }
                }
            }

            towerInventory.towerMaxes = towerMaxes;
            __instance.bridge.OnTowerInventoryChangedSim(true);
        }
        
        towerCount = 0;

        __instance.bridge.SetEndRound(119);
        __instance.bridge.SetRound(0);
        
        DifficultyChoicePanel.Create(__instance.uiRect, __instance);
    }
}