using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class InitialTowerChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public RectTransform menu = null!;

    public InitialTowerChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(string hero) {
        BTD6Rogue.mod.towerCount++;
        TowerInventory towerInventory = __instance.GetTowerInventory();
        towerInventory.towerMaxes[hero]++;
        __instance.bridge.OnTowerInventoryChangedSim(true);

        if (__instance.GetMap().mapModel.mapDifficulty == 0 && BTD6Rogue.mod.towerCount < 1) { Create(__instance.uiRect, __instance);
        } else if (__instance.GetMap().mapModel.mapDifficulty == 1 && BTD6Rogue.mod.towerCount < 2) { Create(__instance.uiRect, __instance);
        } else if (__instance.GetMap().mapModel.mapDifficulty == 2 && BTD6Rogue.mod.towerCount < 3) { Create(__instance.uiRect, __instance);
        } else if (__instance.GetMap().mapModel.mapDifficulty == 3 && BTD6Rogue.mod.towerCount < 4) { Create(__instance.uiRect, __instance); }

        Destroy(gameObject);
    }

    public static InitialTowerChoicePanel Create(RectTransform menu, InGame __instance) {
        var panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 1600, 1080),
            VanillaSprites.BrownInsertPanel);
        var reforgePanel = panel.AddComponent<InitialTowerChoicePanel>();
        reforgePanel.menu = menu;
        reforgePanel.__instance = __instance;

        var inset = panel.AddPanel(new Info("InnerPanel") {
            AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50
        }, VanillaSprites.BrownInsertPanelDark);

        string[] heroes = TowerUtil.towerNames.ToArray();

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

        for (int i = 0; i < heroes.Length; i++) {
            TowerModel hero = Game.instance.model.GetTower(heroes[i]);
            ModHelperButton button = inset.AddButton(new Info("TowerButton3", xPos[i], yPos[i], 200), VanillaSprites.YellowBtn, new Action(() => reforgePanel.ChooseTower(hero.GetBaseId())));
            button.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, hero.portrait.GetGUID());
        }
        return reforgePanel;
    }
}