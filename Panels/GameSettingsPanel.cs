using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class GameSettingsPanel : MonoBehaviour {

    public InGame __instance = null!;

    public GameSettingsPanel(IntPtr ptr) : base(ptr) { }

    public void ChooseDifficulty(string difficulty) {
        Destroy(gameObject);
    }

    public static GameSettingsPanel Create(RectTransform menu, InGame __instance) {
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 1600, 1080),
            VanillaSprites.BrownInsertPanel);
        GameSettingsPanel difficultyChoicePanel = panel.AddComponent<GameSettingsPanel>();
        difficultyChoicePanel.__instance = __instance;

        ModHelperPanel inset = panel.AddPanel(new Info("InnerPanel") {
            AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50
        }, VanillaSprites.BrownInsertPanelDark);
        
        // 0  1  2  3  4

        List<float> xPos = new List<float>() {
            -600, -300, -0, 300, 600,
        };

        return difficultyChoicePanel;
    }
}