using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class TowerChoicePanel : MonoBehaviour {

    public InGame __instance = null!;

    public RectTransform menu = null!;
    public string tower1Choice = null!;
    public string tower1Path = null!;
    public int tower1Amount = 0;
    public string tower2Choice = null!;
    public string tower2Path = null!;
    public int tower2Amount = 0;
    public string tower3Choice = null!;
    public string tower3Path = null!;
    public int tower3Amount = 0;

    public ModHelperButton button1 = null!;

    public ModHelperButton button2 = null!;

    public ModHelperButton button3 = null!;

    public ModHelperText cost = null!;

    public ModHelperText description = null!;

    public TowerChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(int tower)
    {
        TowerInventory towerInventory = __instance.GetTowerInventory();
        if (tower == 1)
        {
            towerInventory.towerMaxes[tower1Choice] += tower1Amount;
            if (tower1Path == "top")
            {
                BTD6Rogue.mod.rogueTowers[tower1Choice].maxTopPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
            else if (tower1Path == "mid")
            {
                BTD6Rogue.mod.rogueTowers[tower1Choice].maxMidPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
            else if (tower1Path == "bot")
            {
                BTD6Rogue.mod.rogueTowers[tower1Choice].maxBotPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
        }
        else if (tower == 2)
        {
            towerInventory.towerMaxes[tower2Choice] += tower2Amount;
            if (tower2Path == "top")
            {
                BTD6Rogue.mod.rogueTowers[tower2Choice].maxTopPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
            else if (tower2Path == "mid")
            {
                BTD6Rogue.mod.rogueTowers[tower2Choice].maxMidPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
            else if (tower2Path == "bot")
            {
                BTD6Rogue.mod.rogueTowers[tower2Choice].maxBotPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
        }
        else if (tower == 3)
        {
            towerInventory.towerMaxes[tower3Choice] += tower3Amount;
            if (tower3Path == "top")
            {
                BTD6Rogue.mod.rogueTowers[tower3Choice].maxTopPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
            else if (tower3Path == "mid")
            {
                BTD6Rogue.mod.rogueTowers[tower3Choice].maxMidPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
            else if (tower3Path == "bot")
            {
                BTD6Rogue.mod.rogueTowers[tower3Choice].maxBotPath = TowerUtil.GetMaxPath(__instance.currentRoundId + 1);
            }
        };
        __instance.bridge.OnTowerInventoryChangedSim(true);

        foreach (Tower ttower in __instance.GetTowers())
        {
            if (ttower.towerModel.IsHero()) { continue; }
            if (ttower.GetUpgrade(0) != null && ttower.GetUpgrade(0).tier >= BTD6Rogue.mod.rogueTowers[ttower.towerModel.baseId].maxTopPath) { ttower.GetUpgrade(0).cost = 9999999; }
            else if (ttower.GetUpgrade(0) != null)
            {
                if (ttower.towerModel != null && ttower.towerModel.GetUpgrade(0, ttower.GetUpgrade(0).tier) != null)
                {
                    ttower.GetUpgrade(0).cost = ttower.towerModel.GetUpgrade(0, ttower.GetUpgrade(0).tier + 1).cost;
                }
            }
            if (ttower.GetUpgrade(1) != null && ttower.GetUpgrade(1).tier >= BTD6Rogue.mod.rogueTowers[ttower.towerModel.baseId].maxMidPath) { ttower.GetUpgrade(1).cost = 9999999; }
            else if (ttower.GetUpgrade(1) != null)
            {
                if (ttower.towerModel != null && ttower.towerModel.GetUpgrade(1, ttower.GetUpgrade(1).tier) != null)
                {
                    ttower.GetUpgrade(1).cost = ttower.towerModel.GetUpgrade(1, ttower.GetUpgrade(1).tier + 1).cost;
                }
            }
            if (ttower.GetUpgrade(2) != null && ttower.GetUpgrade(2).tier >= BTD6Rogue.mod.rogueTowers[ttower.towerModel.baseId].maxBotPath) { ttower.GetUpgrade(2).cost = 9999999; }
            else if (ttower.GetUpgrade(2) != null)
            {
                if (ttower.towerModel != null && ttower.towerModel.GetUpgrade(2, ttower.GetUpgrade(2).tier) != null)
                {
                    ttower.GetUpgrade(2).cost = ttower.towerModel.GetUpgrade(2, ttower.GetUpgrade(2).tier + 1).cost;
                }
            }

        }
        __instance.bridge.SetAutoPlay(true);
        Destroy(gameObject);
    }

    public static TowerChoicePanel Create(RectTransform menu, InGame __instance)
    {
        var panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 2500, 1500),
            VanillaSprites.BrownInsertPanel);
        var reforgePanel = panel.AddComponent<TowerChoicePanel>();
        reforgePanel.menu = menu;
        reforgePanel.__instance = __instance;

        TowerModel[] towerModels = TowerUtil.GetThreeTowers(TowerUtil.GetMaxPath(__instance.currentRoundId + 1), TowerUtil.waterMaps.Contains(__instance.GetMap().mapModel.mapName));
        TowerModel tower1 = towerModels[0];
        TowerModel tower2 = towerModels[1];
        TowerModel tower3 = towerModels[2];
        reforgePanel.tower1Choice = tower1.baseId;
        if (tower1.GetUpgradeLevel(0) >= 3) { reforgePanel.tower1Path = "top"; }
        if (tower1.GetUpgradeLevel(1) >= 3) { reforgePanel.tower1Path = "mid"; }
        if (tower1.GetUpgradeLevel(2) >= 3) { reforgePanel.tower1Path = "bot"; }
        reforgePanel.tower2Choice = tower2.baseId;
        if (tower2.GetUpgradeLevel(0) >= 3) { reforgePanel.tower2Path = "top"; }
        if (tower2.GetUpgradeLevel(1) >= 3) { reforgePanel.tower2Path = "mid"; }
        if (tower2.GetUpgradeLevel(2) >= 3) { reforgePanel.tower2Path = "bot"; }
        reforgePanel.tower3Choice = tower3.baseId;
        if (tower3.GetUpgradeLevel(0) >= 3) { reforgePanel.tower3Path = "top"; }
        if (tower3.GetUpgradeLevel(1) >= 3) { reforgePanel.tower3Path = "mid"; }
        if (tower3.GetUpgradeLevel(2) >= 3) { reforgePanel.tower3Path = "bot"; }
        reforgePanel.tower1Amount = TowerUtil.GetTowerCount(tower1);
        reforgePanel.tower2Amount = TowerUtil.GetTowerCount(tower2);
        reforgePanel.tower3Amount = TowerUtil.GetTowerCount(tower3);



        var inset = panel.AddPanel(new Info("InnerPanel")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 1),
            Size = -50
        }, VanillaSprites.BrownInsertPanelDark, RectTransform.Axis.Horizontal, 25);



        reforgePanel.button1 = inset.AddButton(new Info("TowerButton1", 650, 650),
            VanillaSprites.GreenBtn, new Action(() => reforgePanel.ChooseTower(1)));

        reforgePanel.button1.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 },
            tower1.portrait.GetGUID());
        ModHelperText text1 = reforgePanel.button1.AddText(new Info("Tower 1 Name", 0, -50, 650, 76),
            tower1.name, 64);
        reforgePanel.button1.AddText(new Info("Tower 1 Amount", 0, 80, 650, 76),
            reforgePanel.tower1Amount.ToString(), 64);
        text1.Text.enableAutoSizing = true;

        reforgePanel.button2 = inset.AddButton(new Info("TowerButton2", 650, 650),
            VanillaSprites.RedBtn, new Action(() => reforgePanel.ChooseTower(2)));

        reforgePanel.button2.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 },
            tower2.portrait.GetGUID());
        ModHelperText text2 = reforgePanel.button2.AddText(new Info("Tower 2 Name", 0, -50, 650, 76),
            tower2.name, 64);
        reforgePanel.button2.AddText(new Info("Tower 2 Amount", 0, 80, 650, 76),
            reforgePanel.tower2Amount.ToString(), 64);
        text2.Text.enableAutoSizing = true;

        reforgePanel.button3 = inset.AddButton(new Info("TowerButton3", 650, 650),
            VanillaSprites.BlueBtn, new Action(() => reforgePanel.ChooseTower(3)));

        reforgePanel.button3.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 },
            tower3.portrait.GetGUID());

        ModHelperText text3 = reforgePanel.button3.AddText(new Info("Tower 3 Name", 0, -50, 650, 76),
            tower3.name, 64);
        reforgePanel.button3.AddText(new Info("Tower 3 Amount", 0, 80, 650, 76),
            reforgePanel.tower3Amount.ToString(), 64);
        text3.Text.enableAutoSizing = true;

        return reforgePanel;
    }
}