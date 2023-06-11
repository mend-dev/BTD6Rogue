using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class InitialHeroChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public RectTransform menu = null!;

    public InitialHeroChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(string hero) {
        TowerInventory towerInventory = __instance.GetTowerInventory();
        towerInventory.towerMaxes[hero] = 1;
        __instance.bridge.OnTowerInventoryChangedSim(true);
        InitialTowerChoicePanel.Create(__instance.uiRect, __instance);
        Destroy(gameObject);
    }

    public static InitialHeroChoicePanel Create(RectTransform menu, InGame __instance) {
        var panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 1920, 1080), VanillaSprites.BrownInsertPanel);
        var initialHeroChoicePanel = panel.AddComponent<InitialHeroChoicePanel>();
        initialHeroChoicePanel.menu = menu;
        initialHeroChoicePanel.__instance = __instance;

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50  },
            VanillaSprites.BrownInsertPanelDark);

        string[] heroes = TowerUtil.heroNames.ToArray();

        // 0  1  2  3  4
        // 5  6  7  8  9
        // 10 11 12 13 14

        List<float> xPos = new List<float>() {
            -700, -350, 0, 350, 700,
            -700, -350, 0, 350, 700,
            -700, -350, 0, 350, 700
        };

        List<float> yPos = new List<float>() {
            350, 350, 350, 350, 350,
            0, 0, 0, 0, 0,
            -350, -350, -350, -350, -350
        };

        for (int i = 0; i < heroes.Length; i++) {
            TowerModel hero = Game.instance.model.GetTower(heroes[i]);

            ModHelperButton button = inset.AddButton(new Info("HeroButton", xPos[i], yPos[i], 300), VanillaSprites.YellowBtn,
                new Action(() => initialHeroChoicePanel.ChooseTower(hero.GetBaseId())));

            button.AddImage(new Info("HeroImage") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, hero.portrait.GetGUID());
        }

        inset.AddText(new Info("InfoText"), "Choose a hero to start with");

        return initialHeroChoicePanel;
    }
}