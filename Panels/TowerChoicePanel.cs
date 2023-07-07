using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.Powers;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class TowerChoicePanel : MonoBehaviour {

    public InGame __instance = null!;

    public string[] towerChoices = new string[3];
    public string[] towerPaths = new string[3];
    public int[] towerAmounts = new int[3];

    public TowerChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(string towerStr) {
        TowerInventory towerInventory = __instance.GetTowerInventory();
        int tower = Array.IndexOf(towerChoices, towerStr);
        towerInventory.towerMaxes[towerStr] += towerAmounts[tower];

        if (towerPaths[tower] == "top") {
            BTD6Rogue.mod.rogueTowers[towerStr].maxTopPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            //BTD6Rogue.mod.rogueTowers[towerStr].top = true;
        } else if (towerPaths[tower] == "mid") {
            BTD6Rogue.mod.rogueTowers[towerStr].maxMidPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            //BTD6Rogue.mod.rogueTowers[towerStr].mid = true;
        } else if (towerPaths[tower] == "bot") {
            BTD6Rogue.mod.rogueTowers[towerStr].maxBotPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            //BTD6Rogue.mod.rogueTowers[towerStr].bot = true;
        }

        __instance.bridge.OnTowerInventoryChangedSim(true);

        foreach (Tower ttower in __instance.GetTowers()) {
            if (!TowerUtil.towerNames.Contains(ttower.towerModel.baseId)) { continue; }

            for (int i = 0; i < 3; i++) {
                int maxPath = 0;
                if (i == 0) { maxPath = BTD6Rogue.mod.rogueTowers[ttower.towerModel.baseId].maxTopPath; }
                if (i == 1) { maxPath = BTD6Rogue.mod.rogueTowers[ttower.towerModel.baseId].maxMidPath; }
                if (i == 2) { maxPath = BTD6Rogue.mod.rogueTowers[ttower.towerModel.baseId].maxBotPath; }

                if (ttower.GetUpgrade(i) != null && ttower.GetUpgrade(i).tier >= maxPath) { ttower.GetUpgrade(i).cost = 9999999; } else if (ttower.GetUpgrade(i) != null) {
                    if (ttower.towerModel != null && ttower.towerModel.GetUpgrade(i, ttower.GetUpgrade(i).tier) != null) {
                        ttower.GetUpgrade(i).cost = ttower.towerModel.GetUpgrade(i, ttower.GetUpgrade(i).tier + 1).cost;
                    }
                }
            }
        }
        __instance.bridge.SetAutoPlay(true);
        Destroy(gameObject);
    }

    public static TowerChoicePanel Create(RectTransform menu, InGame __instance) {
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 2400, 1000), VanillaSprites.BrownInsertPanel);
        TowerChoicePanel towerChoicePanel = panel.AddComponent<TowerChoicePanel>();
        towerChoicePanel.__instance = __instance;

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        TowerModel[] towerModels = TowerUtil.GetThreeTowers(TowerUtil.GetMaxPath(__instance.currentRoundId + 1), TowerUtil.waterMaps.Contains(__instance.GetMap().mapModel.mapName));

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < towerModels.Length; i++) {
            TowerModel tower = towerModels[i];
            towerChoicePanel.towerChoices[i] = tower.baseId;
            if (tower.GetUpgradeLevel(0) >= 1) { towerChoicePanel.towerPaths[i] = "top"; BTD6Rogue.mod.rogueTowers[tower.baseId].top = true; }
            if (tower.GetUpgradeLevel(1) >= 1) { towerChoicePanel.towerPaths[i] = "mid"; BTD6Rogue.mod.rogueTowers[tower.baseId].mid = true; }
            if (tower.GetUpgradeLevel(2) >= 1) { towerChoicePanel.towerPaths[i] = "bot"; BTD6Rogue.mod.rogueTowers[tower.baseId].bot = true; }
            towerChoicePanel.towerAmounts[i] = TowerUtil.GetTowerCount(tower);

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -100, 650), VanillaSprites.GreenBtn, new Action(() => towerChoicePanel.ChooseTower(tower.baseId)));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, tower.portrait.GetGUID());
            ModHelperText towerName = towerButton.AddText(new Info("Tower Name", 0, -225, 650, 76), tower.name, 64);
            ModHelperText amountText = towerButton.AddText(new Info("Tower Amount", 225, 225, 500, 500), towerChoicePanel.towerAmounts[i].ToString(), 110);
            towerName.Text.enableAutoSizing = true;
        }
        ModHelperText chooseText = inset.AddText(new Info("Tower Amount", 0, 400, 2000, 100), "Choose a Path", 86);
        ModHelperText infoText = inset.AddText(new Info("Tower Amount", 0, 300, 2000, 100), "None of these paths will show up again, choose wisely", 56);

        return towerChoicePanel;
    }
}