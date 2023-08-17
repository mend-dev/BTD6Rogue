using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class InitialTowerChoicePanel : RoguePanel {

    public void ChooseTower(string hero) {
        TowerInventory towerInventory = game.GetTowerInventory();
        towerInventory.towerMaxes[hero]++;
        game.bridge.OnTowerInventoryChangedSim(true);
        DestroyPanel();
    }

    public override void CreatePanel() {

        var inset = panel.AddPanel(new Info("InnerPanel") {
            AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50
        }, VanillaSprites.BrownInsertPanelDark);

        RogueTower[] rogueTowers = TowerUtil.GetAllGameTowers();

        List<string> towerIds = new List<string>();
        foreach (RogueTower rogueTower in rogueTowers) { towerIds.Add(rogueTower.BaseTower); }

        // 0  1  2  3  4  5
        // 6  7  8  9  10 11
        // 12 13 14 15 16 17
        // 18 19 20 21 22 23

        List<float> xPos = new List<float>() {
            -575, -350, -125, 125, 350, 575,
            -575, -350, -125, 125, 350, 575,
            -575, -350, -125, 125, 350, 575,
            -575, -350, -125, 125, 350, 575
        };

        List<float> yPos = new List<float>() {
            350, 350, 350, 350, 350, 350,
            125, 125, 125, 125, 125, 125,
            -125, -125, -125, -125, -125, -125,
            -350, -350, -350, -350, -350, -350
        };        

        for (int i = 0; i < towerIds.Count; i++) {
            float column = (i % 6);
            float row = Mathf.FloorToInt(i / 6);
            TowerModel tower = Game.instance.model.GetTower(towerIds[i]);
            ModHelperButton button = inset.AddButton(new Info("Tower Button", column * 250 - 625, row * -250 + 375, 200), VanillaSprites.YellowBtn, new Action(() => ChooseTower(tower.GetBaseId())));
            button.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, tower.portrait.GetGUID());
        }
    }
}
