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
public class InitialHeroChoicePanel : RoguePanel {

    public void ChooseHero(string hero) {
        TowerInventory towerInventory = game.GetTowerInventory();
        towerInventory.towerMaxes[hero] = 1;
        BTD6Rogue.mod.currentGame.heroData[hero].SelectedHero = true;
        game.bridge.OnTowerInventoryChangedSim(true);
        DestroyPanel();
    }

    public override void CreatePanel() {

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50  },
            VanillaSprites.BrownInsertPanelDark);

        RogueHero[] rogueHeroes = HeroUtil.GetAllHeroes();

        List<string> heroIds = new List<string>();
        foreach (RogueHero rogueHero in rogueHeroes) { heroIds.Add(rogueHero.BaseHeroId); }

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

        for (int i = 0; i < heroIds.Count; i++) {
            TowerModel hero = Game.instance.model.GetTower(heroIds[i]);

            ModHelperButton button = inset.AddButton(new Info("HeroButton", xPos[i], yPos[i], 300), VanillaSprites.YellowBtn,
                new Action(() => ChooseHero(hero.GetBaseId())));

            button.AddImage(new Info("HeroImage") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, hero.portrait.GetGUID());
        }

        inset.AddText(new Info("InfoText"), "Choose a hero to start with");
    }
}