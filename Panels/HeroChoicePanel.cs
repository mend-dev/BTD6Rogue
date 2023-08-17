using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using MelonLoader;
using UnityEngine;
using System.Collections.Generic;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class HeroChoicePanel : RoguePanel {
    public TowerModel[] towerModels = new TowerModel[3];

    public void ChooseTower(string hero) {
        TowerInventory towerInventory = game.GetTowerInventory();
        towerInventory.towerMaxes[hero]++;
        BTD6Rogue.mod.currentGame.heroData[hero].SelectedHero = true;
        game.bridge.OnTowerInventoryChangedSim(true);
        DestroyPanel();
    }
    
    public void RerollHeroes(bool useReroll = true) {
        if (useReroll) { BTD6Rogue.mod.currentGame.rerolls--; }
        BTD6Rogue.mod.currentGame.panelManager.AddPanelToQueue(rect, game, nameof(HeroChoicePanel));
        DestroyPanel();
    }

    public override void CreatePanel() {

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        RogueHero[] heroes = HeroUtil.GetThreeHeroes();
        for (int i = 0; i < 3; i++) {
            towerModels[i] = heroes[i].GetBaseTower();
        }

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < towerModels.Length; i++) {
            TowerModel hero = towerModels[i];

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -0, 650), VanillaSprites.GreenBtn, new Action(() => ChooseTower(hero.baseId)));

            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, hero.portrait.GetGUID());
        }

        if (BTD6Rogue.mod.currentGame.rerolls > 0) {
            ModHelperButton rerollButton = inset.AddButton(new Info("Reroll Button", 0, -500, 400, 200), VanillaSprites.BlueBtn, new Action(() => RerollHeroes()));
            ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", 0, 0, 650, 76), "Reroll: " + BTD6Rogue.mod.currentGame.rerolls, 64);
        }

        if (towerModels[0].name == towerModels[1].name || towerModels[1].name == towerModels[2].name || towerModels[2] == towerModels[0]) {
            RerollHeroes(false);
        }
    }
}