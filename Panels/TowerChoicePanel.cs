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
public class TowerChoicePanel : RoguePanel {

    public string[] towerChoices = new string[3];
    public string[] towerPaths = new string[3];
    public int[] towerAmounts = new int[3];
    public TowerModel[] towerModels = new TowerModel[3];

    public void ChooseTower(string towerName) {
        TowerInventory towerInventory = game.GetTowerInventory();
        int tower = Array.IndexOf(towerChoices, towerName);
        string towerStr = Game.instance.model.GetTowerWithName(towerName).baseId;
        towerInventory.towerMaxes[towerStr] += towerAmounts[tower];

        if (towerPaths[tower] == "top") {
            BTD6Rogue.mod.currentGame.towerData[towerStr].limitPaths[0] = TowerUtil.GetMaxTier(game.currentRoundId + 1);
        } else if (towerPaths[tower] == "mid") {
            BTD6Rogue.mod.currentGame.towerData[towerStr].limitPaths[1] = TowerUtil.GetMaxTier(game.currentRoundId + 1);
        } else if (towerPaths[tower] == "bot") {
            BTD6Rogue.mod.currentGame.towerData[towerStr].limitPaths[2] = TowerUtil.GetMaxTier(game.currentRoundId + 1);
        }

        for (int i = 0; i < towerModels.Length; i++) {
            if (towerModels[i]
                .GetUpgradeLevel(0)
                >= 1) {
                BTD6Rogue
                    .mod
                    .currentGame.towerData[
                    towerModels[i]
                    .baseId]
                    .lockedPaths[0]
                    = true; }
            if (towerModels[i].GetUpgradeLevel(1) >= 1) { BTD6Rogue.mod.currentGame.towerData[towerModels[i].baseId].lockedPaths[1] = true; }
            if (towerModels[i].GetUpgradeLevel(2) >= 1) { BTD6Rogue.mod.currentGame.towerData[towerModels[i].baseId].lockedPaths[2] = true; }
        }

        game.bridge.OnTowerInventoryChangedSim(true);
        DestroyPanel();
    }

    public void RerollTowers(bool useReroll = true) {
        if (useReroll) { BTD6Rogue.mod.currentGame.rerolls--; }
        BTD6Rogue.mod.currentGame.panelManager.AddPanelToQueue(rect, game, nameof(TowerChoicePanel));
        DestroyPanel();
    }

    public override void CreatePanel() {

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        towerModels = TowerUtil.GetThreeTowers();

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < towerModels.Length; i++) {
            TowerModel tower = towerModels[i];
            towerChoices[i] = tower.GetTowerId();
            towerAmounts[i] = TowerUtil.GetRogueTowerFromModel(tower).GetTowerAmount(TowerUtil.GetTowerPath(tower));

            if (tower.GetUpgradeLevel(0) >= 1) { towerPaths[i] = "top"; }
            if (tower.GetUpgradeLevel(1) >= 1) { towerPaths[i] = "mid"; }
            if (tower.GetUpgradeLevel(2) >= 1) { towerPaths[i] = "bot"; }

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -50, 650), VanillaSprites.GreenBtn, new Action(() => ChooseTower(tower.GetTowerId())));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, tower.portrait.GetGUID());
            ModHelperText towerName = towerButton.AddText(new Info("Tower Name", 0, -225, 650, 76), tower.name, 64);
            ModHelperText amountText = towerButton.AddText(new Info("Tower Amount", 225, 225, 500, 500), towerAmounts[i].ToString(), 110);
            towerName.Text.enableAutoSizing = true;
        }
        ModHelperText chooseText = inset.AddText(new Info("Tower Amount", 0, 500, 2000, 100), "Choose a Path", 86);
        ModHelperText infoText = inset.AddText(new Info("Tower Amount", 0, 400, 2000, 100), "None of these paths will show up again, choose wisely", 56);

        if (BTD6Rogue.mod.currentGame.rerolls > 0) {
            ModHelperButton rerollButton = inset.AddButton(new Info("Reroll Button", 0, -500, 400, 200), VanillaSprites.BlueBtn, new Action(() => RerollTowers()));
            ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", 0, 0, 650, 76), "Reroll: " + BTD6Rogue.mod.currentGame.rerolls, 64);
        }

        if (towerChoices[0] == towerChoices[1] || towerChoices[1] == towerChoices[2] || towerChoices[2] == towerChoices[0]) {
            RerollTowers(false);
        }
    }
}