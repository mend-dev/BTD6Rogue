using System;
using System.Collections.Generic;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;
using static Il2CppAssets.Scripts.Models.ServerEvents.QuickMatchSkuSettings;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class GameSettingsPanel : MonoBehaviour {

    public InGame __instance = null!;

    public ModHelperDropdown dropdown;

    public GameSettingsPanel(IntPtr ptr) : base(ptr) { }

    public void StartGame() {
        List<string> possibleBosses = new List<string>();

        if (dropdown.Text.Text.text == "All") {
            possibleBosses.Add("RogueDreadbloon");
            possibleBosses.Add("RogueVortex");
            possibleBosses.Add("RoguePhayze");
            possibleBosses.Add("RogueBloonarius");
            possibleBosses.Add("RogueLych");
        } else {
            possibleBosses.Add("Rogue" + dropdown.Text.Text.text);
        }

        BTD6Rogue.mod.roundGenerator.possibleBosses = possibleBosses;

        InitialHeroChoicePanel.Create(__instance.uiRect, __instance);
        Destroy(gameObject);
    }

    public static GameSettingsPanel Create(RectTransform menu, InGame __instance) {
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 2000, 1600),
            VanillaSprites.BrownInsertPanel);
        GameSettingsPanel gameSettingsPannel = panel.AddComponent<GameSettingsPanel>();
        gameSettingsPannel.__instance = __instance;

        ModHelperPanel inset = panel.AddPanel(new Info("InnerPanel") {
            AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50
        }, VanillaSprites.BrownInsertPanelDark);

        // Limit tower sets
        //ModHelperCheckbox primaryOnly = inset.AddCheckbox(new Info("Checkbox", 0, 0, 100), false, VanillaSprites.BlueBtn);

        List<string> bosses = new List<string>() { "All", "Bloonarius", "Vortex", "Dreadbloon", "Lych", "Phayze" };

        // Other stuff
        ModHelperDropdown bossDropdown = inset.AddDropdown(new Info("BossDropdown", 0, 0, 600, 200), bosses.ToIl2CppList(), 600f, null, VanillaSprites.BlueInsertPanelRound, 80f);
        gameSettingsPannel.dropdown = bossDropdown;

        // Limitations
        //ModHelperCheckbox primaryOnly = inset.AddCheckbox(new Info("Checkbox", 0, 0, 100), false, VanillaSprites.BlueBtn);

        // Start Game
        ModHelperButton button = inset.AddButton(new Info("Difficulty", 600, 0, 400, 200), VanillaSprites.GreenBtn, new Action(() => gameSettingsPannel.StartGame()));
        ModHelperText difficultyText = button.AddText(new Info("Difficulty Name", 0, 0, 500, 500), "Start Game", 72);

        return gameSettingsPannel;
    }
}