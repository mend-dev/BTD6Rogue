using MelonLoader;
using BTD_Mod_Helper;
using BTD6Rogue;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Input;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

[assembly: MelonInfo(typeof(BTD6Rogue.BTD6Rogue), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6Rogue;

public class RogueTower {
    public int maxTopPath = 2;
    public int maxMidPath = 2;
    public int maxBotPath = 2;
    public bool top = false;
    public bool mid = false;
    public bool bot = false;
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

    #region Mod Settings
    public static readonly ModSettingHotkey FasterForwardHotkey = new(KeyCode.F1); // Doesn't Work
    public static readonly ModSettingBool DisablePatchesInSandbox = new(true);

    public static readonly ModSettingCategory RoundSettings = new("Round Settings") { collapsed = true };
    public static readonly ModSettingBool RandomRounds = new(true) { category = RoundSettings };

    public static readonly ModSettingCategory TowerSettings = new("Tower Settings") { collapsed = true };
    public static readonly ModSettingInt StartingTowers = new(1) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalBeginnerMapStartingTowers = new(0) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalIntermediateMapStartingTowers = new(1) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalAdvancedMapStartingTowers = new(2) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalExpertMapStartingTowers = new(3) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalPoppableStartingTowers = new(0) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalEasyStartingTowers = new(0) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalMediumStartingTowers = new(0) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalHardStartingTowers = new(1) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt AdditionalImpoppableStartingTowers = new(2) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingBool RandomTowers = new(true) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt TowersStartAtRound = new(5) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerRandomTower = new(10) { category = TowerSettings }; // Doesn't Work
    public static readonly ModSettingInt Tier1MinimumRound = new(1) { category = TowerSettings, displayName = "Tier 1 Minimum Round", description = "This is the minimum round that tier 1's appear in the Random Tower Pool (this is overwritten by Tier 2 Minimum Round)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingInt Tier2MinimumRound = new(1) { category = TowerSettings, displayName = "Tier 2 Minimum Round", description = "This is the minimum round that tier 2's appear in the Random Tower Pool (this is overwritten by Tier 3 Minimum Round)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingInt Tier3MinimumRound = new(20) { category = TowerSettings, displayName = "Tier 3 Minimum Round", description = "This is the minimum round that tier 3's appear in the Random Tower Pool (this is overwritten by Tier 4 Minimum Round)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingInt Tier4MinimumRound = new(40) { category = TowerSettings, displayName = "Tier 4 Minimum Round", description = "This is the minimum round that tier 4's appear in the Random Tower Pool (this is overwritten by Tier 5 Minimum Round)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingInt Tier5MinimumRound = new(60) { category = TowerSettings, displayName = "Tier 5 Minimum Round", description = "This is the minimum round that tier 5's appear in the Random Tower Pool (this overwrites the Tier 4 pool, but doesn't get overwritten by Paragons)", min = 1, max = 999 }; // Doesn't Work
    public static readonly ModSettingInt ParagonMinimumRound = new(80) { category = TowerSettings, displayName = "Paragon Minimum Round", description = "This is the minimum round that paragons appear in the Random Tower Pool (this doesn't overwrite Tier 5's appearing)", min = 1, max = 999 }; // Doesn't Work

    public static readonly ModSettingBool LimitUpgrades = new(true); // Doesn't Work

    public static readonly ModSettingCategory HeroSettings = new("Hero Settings") { collapsed = true };
    public static readonly ModSettingBool MultipleHeroes = new(true) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingInt StartingHeroes = new(1) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingInt HeroesStartAtRound = new(0) { category = HeroSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerRandomHero = new(40) { category = HeroSettings }; // Doesn't Work

    public static readonly ModSettingCategory ArtifactSettings = new("Artifact Settings") { collapsed = true };
    public static readonly ModSettingBool Artifacts = new(true) { category = ArtifactSettings }; // Doesn't Work
    public static readonly ModSettingInt ArtifactsStartAtRound = new(0) { category = ArtifactSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerArtifact = new(10) { category = ArtifactSettings }; // Doesn't Work

    public static readonly ModSettingCategory ModifierSettings = new("Modifier Settings") { collapsed = true };
    public static readonly ModSettingBool Modifiers = new(true) { category = ModifierSettings }; // Doesn't Work
    public static readonly ModSettingInt ModifiersStartAtRound = new(0) { category = ModifierSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerModifier = new(50) { category = ModifierSettings }; // Doesn't Work

    public static readonly ModSettingCategory BossSettings = new("Boss Settings") { collapsed = true };
    public static readonly ModSettingBool Bosses = new(true) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingInt BossesStartAtRound = new(0) { category = BossSettings }; // Doesn't Work
    public static readonly ModSettingInt RoundsPerBoss = new(50) { category = BossSettings }; // Doesn't Work
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
        rogueTowers.Clear();
        selectedHeroes.Clear();
        modifiers.Clear();
        TowerInventory towerInventory = __instance.GetTowerInventory();
        Il2CppSystem.Collections.Generic.Dictionary<string, int> towerMaxes = towerInventory.GetTowerInventoryMaxes();
        foreach (string towerName in TowerUtil.towerNames) { towerMaxes[towerName] = 0; rogueTowers.Add(towerName, new RogueTower()); }
        foreach (string heroName in TowerUtil.heroNames) { towerMaxes[Game.instance.model.GetTower(heroName).GetBaseId()] = 0; rogueTowers.Add(heroName, new RogueTower()); }
        towerInventory.towerMaxes = towerMaxes;
        __instance.bridge.OnTowerInventoryChangedSim(true);
        towerCount = 0;
        __instance.bridge.SetEndRound(119);
        __instance.bridge.SetRound(0);
        DifficultyChoicePanel.Create(__instance.uiRect, __instance);
    }
}