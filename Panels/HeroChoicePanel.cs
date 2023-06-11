using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class HeroChoicePanel : MonoBehaviour
{

    public InGame __instance = null!;

    public RectTransform menu = null!;
    public string hero1Choice = null!;
    public string hero2Choice = null!;
    public string hero3Choice = null!;

    public ModHelperButton button1 = null!;

    public ModHelperButton button2 = null!;

    public ModHelperButton button3 = null!;

    public ModHelperText cost = null!;

    public ModHelperText description = null!;

    public HeroChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseTower(int tower)
    {
        TowerInventory towerInventory = __instance.GetTowerInventory();
        if (tower == 1)
        {
            towerInventory.towerMaxes[hero1Choice]++;
        }
        else if (tower == 2)
        {
            towerInventory.towerMaxes[hero2Choice]++;
        }
        else if (tower == 3)
        {
            towerInventory.towerMaxes[hero3Choice]++;
        };
        __instance.bridge.OnTowerInventoryChangedSim(true);
        __instance.bridge.SetAutoPlay(true);
        Destroy(gameObject);
    }

    public static HeroChoicePanel Create(RectTransform menu, InGame __instance)
    {
        var panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 1920, 1080),
            VanillaSprites.BrownInsertPanel);
        var reforgePanel = panel.AddComponent<HeroChoicePanel>();
        reforgePanel.menu = menu;
        reforgePanel.__instance = __instance;

        var inset = panel.AddPanel(new Info("InnerPanel")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 1),
            Size = -50
        }, VanillaSprites.BrownInsertPanelDark, RectTransform.Axis.Horizontal, 25);

        TowerModel[] heroes = TowerUtil.GetHeroes(TowerUtil.waterMaps.Contains(__instance.GetMap().mapModel.mapName));
        TowerModel tower1 = heroes[0];
        TowerModel tower2 = heroes[1];
        TowerModel tower3 = heroes[2];
        reforgePanel.hero1Choice = tower1.baseId;
        reforgePanel.hero2Choice = tower2.baseId;
        reforgePanel.hero3Choice = tower3.baseId;

        reforgePanel.button1 = inset.AddButton(new Info("TowerButton1", 500, 500),
            VanillaSprites.GreenBtn, new Action(() => reforgePanel.ChooseTower(1)));

        reforgePanel.button1.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 },
            tower1.portrait.GetGUID());

        reforgePanel.button2 = inset.AddButton(new Info("TowerButton2", 500, 500),
            VanillaSprites.RedBtn, new Action(() => reforgePanel.ChooseTower(2)));

        reforgePanel.button2.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 },
            tower2.portrait.GetGUID());

        reforgePanel.button3 = inset.AddButton(new Info("TowerButton3", 500, 500),
            VanillaSprites.BlueBtn, new Action(() => reforgePanel.ChooseTower(3)));

        reforgePanel.button3.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 },
            tower3.portrait.GetGUID());

        return reforgePanel;
    }
}