using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;
using System.Collections.Generic;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class HeroChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public static HeroChoicePanel uiPanel = null!;
    public string[] heroChoices = new string[3];

    public HeroChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(string hero) {
        BTD6Rogue.mod.selectedHeroes.Add(hero);
        TowerInventory towerInventory = __instance.GetTowerInventory();
        towerInventory.towerMaxes[hero]++;
        __instance.bridge.OnTowerInventoryChangedSim(true);
        __instance.bridge.SetAutoPlay(true);
        BTD6Rogue.mod.uiOpen = false;
        uiPanel = null!;
        Destroy(gameObject);
    }

    public static HeroChoicePanel Create(RectTransform menu, InGame __instance) {
        BTD6Rogue.mod.uiOpen = true;
        var panel = menu.gameObject.AddModHelperPanel(new Info("HeroChoicePanel", 0, 0, 2400, 800),
            VanillaSprites.BrownInsertPanel);
        HeroChoicePanel heroChoicePanel = panel.AddComponent<HeroChoicePanel>();
        heroChoicePanel.__instance = __instance;
        uiPanel = heroChoicePanel!;

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        TowerModel[] heroes = TowerUtil.GetHeroes(TowerUtil.waterMaps.Contains(__instance.GetMap().mapModel.mapName));

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < heroes.Length; i++) {
            TowerModel hero = heroes[i];
            heroChoicePanel.heroChoices[i] = hero.baseId;

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -0, 650), VanillaSprites.GreenBtn, new Action(() => heroChoicePanel.ChooseTower(hero.baseId)));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, hero.portrait.GetGUID());
        }

        return heroChoicePanel;
    }
}