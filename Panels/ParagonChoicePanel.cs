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
public class ParagonChoicePanel : RoguePanel {

    public TowerModel[] paragonChoices = new TowerModel[3];

    public void ChooseTower(string towerName) {
        TowerInventory towerInventory = game.GetTowerInventory();
        int tower = Array.IndexOf(paragonChoices, towerName);
        string towerStr = Game.instance.model.GetTowerWithName(towerName).baseId;
        towerInventory.towerMaxes[towerStr] += 3;

        BTD6Rogue.mod.currentGame.towerData[towerStr].limitPaths[0] = 6;
        BTD6Rogue.mod.currentGame.towerData[towerStr].limitPaths[1] = 6;
        BTD6Rogue.mod.currentGame.towerData[towerStr].limitPaths[2] = 6;
        BTD6Rogue.mod.currentGame.towerData[towerStr].lockedPaths[0] = true;
        BTD6Rogue.mod.currentGame.towerData[towerStr].lockedPaths[1] = true;
        BTD6Rogue.mod.currentGame.towerData[towerStr].lockedPaths[2] = true;

        game.bridge.OnTowerInventoryChangedSim(true);
        DestroyPanel();
    }
    
    public void RerollParagons(bool useReroll = true) {
        if (useReroll) { BTD6Rogue.mod.currentGame.rerolls--; }
        BTD6Rogue.mod.currentGame.panelManager.AddPanelToQueue(rect, game, nameof(ParagonChoicePanel));
        DestroyPanel();
    }

    public override void CreatePanel() {

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        
        RogueParagon[] rogueParagons = ParagonUtil.GetThreeParagons();
        for (int i = 0; i < 3; i++) {
            paragonChoices[i] = rogueParagons[i].GetParagonTowerModel();
        }

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < paragonChoices.Length; i++) {
            TowerModel tower = paragonChoices[i];

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -100, 650), VanillaSprites.PurpleBtnLong, new Action(() => ChooseTower(tower.GetTowerId())));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, tower.portrait.GetGUID());
        }
        ModHelperText chooseText = inset.AddText(new Info("Tower Amount", 0, 400, 2000, 100), "Choose a Paragon", 86);
        ModHelperText infoText = inset.AddText(new Info("Tower Amount", 0, 300, 2000, 100), "You will gain all the tier 5's of the tower", 56);

        if (BTD6Rogue.mod.currentGame.rerolls > 0) {
            ModHelperButton rerollButton = inset.AddButton(new Info("Reroll Button", 0, -500, 400, 200), VanillaSprites.BlueBtn, new Action(() => RerollParagons()));
            ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", 0, 0, 650, 76), "Reroll: " + BTD6Rogue.mod.currentGame.rerolls, 64);
        }

        if (paragonChoices[0].name == paragonChoices[1].name || paragonChoices[1].name == paragonChoices[2].name || paragonChoices[2].name == paragonChoices[0].name) {
            RerollParagons(false);
        }
    }
}