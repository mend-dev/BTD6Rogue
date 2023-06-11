using MelonLoader;
using BTD_Mod_Helper;
using BTD6Rogue;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Input;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(BTD6Rogue.BTD6Rogue), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6Rogue;

public class RogueTower {
    public int maxTopPath = 2;
    public int maxMidPath = 2;
    public int maxBotPath = 2;
}

public class BTD6Rogue : BloonsTD6Mod {

    public static BTD6Rogue mod = null!;
    public RoundGenerator roundGenerator = null!;
    public Dictionary<string, RogueTower> rogueTowers = new Dictionary<string, RogueTower>();

    public int towerCount = 0;
    public bool uiOpen = false;

    public static readonly ModSettingBool TestSetting = false;

    public override void OnApplicationStart() {
        mod = this;
        roundGenerator = new RoundGenerator();
        ModHelper.Msg<BTD6Rogue>("BTD6Rogue loaded!");
        foreach (string towerName in TowerUtil.towerNames) { rogueTowers.Add(towerName, new RogueTower()); }
    }

    public override void OnUpdate() {
        base.OnUpdate();

       /* if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.F1)) {
            PopupScreen.instance.ShowSetValuePopup("Min Increase", "",
                new Action<int>(i => {
                    if (i < 0) { i = 0; }
                    if (i > 3000) { i = 3000; }
                    minIncrease= i;
                }), 600);
        }*/
    }

    public void StartRogueGame(InGame __instance) {
        __instance.GetGameModel().roundSet.rounds[0] = roundGenerator.GetRandomRoundModel(__instance.GetGameModel().roundSet.rounds[0], 0);
        TowerInventory towerInventory = __instance.GetTowerInventory();
        Il2CppSystem.Collections.Generic.Dictionary<string, int> towerMaxes = towerInventory.GetTowerInventoryMaxes();
        foreach (string towerName in TowerUtil.towerNames) { towerMaxes[towerName] = 0; }
        foreach (string heroName in TowerUtil.heroNames) { towerMaxes[Game.instance.model.GetTower(heroName).GetBaseId()] = 0; }
        towerInventory.towerMaxes = towerMaxes;
        __instance.bridge.OnTowerInventoryChangedSim(true);
        towerCount = 0;
        InitialHeroChoicePanel.Create(__instance.uiRect, __instance);
    }
}