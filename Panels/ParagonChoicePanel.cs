using System;
using System.Collections.Generic;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.Powers;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class ParagonChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public static ParagonChoicePanel uiPanel = null!;

    public string[] paragonChoices = new string[3];

    public ParagonChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(string towerName) {
        TowerInventory towerInventory = __instance.GetTowerInventory();
        int tower = Array.IndexOf(paragonChoices, towerName);
        string towerStr = Game.instance.model.GetTowerWithName(towerName).baseId;
        towerInventory.towerMaxes[towerStr] += 3;

        BTD6Rogue.mod.rogueTowers[towerStr].limitPaths[0] = 6;
        BTD6Rogue.mod.rogueTowers[towerStr].limitPaths[1] = 6;
        BTD6Rogue.mod.rogueTowers[towerStr].limitPaths[2] = 6;
        BTD6Rogue.mod.rogueTowers[towerStr].lockedPaths[0] = true;
        BTD6Rogue.mod.rogueTowers[towerStr].lockedPaths[1] = true;
        BTD6Rogue.mod.rogueTowers[towerStr].lockedPaths[2] = true;

        __instance.bridge.OnTowerInventoryChangedSim(true);
        __instance.bridge.SetAutoPlay(true);
        BTD6Rogue.mod.uiOpen = false;
        uiPanel = null!;
        Destroy(gameObject);
    }

    public static ParagonChoicePanel Create(RectTransform menu, InGame __instance) {
        BTD6Rogue.mod.uiOpen = true;
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 2400, 1000), VanillaSprites.BrownInsertPanel);
        ParagonChoicePanel towerChoicePanel = panel.AddComponent<ParagonChoicePanel>();
        towerChoicePanel.__instance = __instance;
        uiPanel = towerChoicePanel!;

        var inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        TowerModel[] towerModels = ParagonUtil.GetThreeParagons();

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < towerModels.Length; i++) {
            TowerModel tower = towerModels[i];
            towerChoicePanel.paragonChoices[i] = tower.GetTowerId();

            ModHelperButton towerButton = inset.AddButton(new Info("Tower Button", xPos[i], -100, 650), VanillaSprites.GreenBtn, new Action(() => towerChoicePanel.ChooseTower(tower.GetTowerId())));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, tower.portrait.GetGUID());
        }
        ModHelperText chooseText = inset.AddText(new Info("Tower Amount", 0, 400, 2000, 100), "Choose a Path", 86);
        ModHelperText infoText = inset.AddText(new Info("Tower Amount", 0, 300, 2000, 100), "None of these paths will show up again, choose wisely", 56);

        return towerChoicePanel;
    }
}