using System;
using System.Collections.Generic;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class DifficultyChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public static DifficultyChoicePanel uiPanel = null!;

    public DifficultyChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseDifficulty(string difficulty) {
        GameSettingsPanel.Create(__instance.uiRect, __instance);


        if (difficulty == "Poppable") {
            BTD6Rogue.mod.difficulty = new PoppableDifficulty();
            //__instance.GetGameModel().GetModModel("BTD6Rogue-Roguemode").GetMutator<GlobalCostModModel>().multiplier = 0.7f;
        } else if (difficulty == "Easy") {
            BTD6Rogue.mod.difficulty = new EasyDifficulty();
            //__instance.GetGameModel().GetModModel("BTD6Rogue-Roguemode").GetMutator<GlobalCostModModel>().multiplier = 0.85f;
        } else if (difficulty == "Medium") {
            BTD6Rogue.mod.difficulty = new MediumDifficulty();
            //__instance.GetGameModel().GetModModel("BTD6Rogue-Roguemode").GetMutator<GlobalCostModModel>().multiplier = 1f;
        } else if (difficulty == "Hard") {
            BTD6Rogue.mod.difficulty = new HardDifficulty();
            //__instance.GetGameModel().GetModModel("BTD6Rogue-Roguemode").GetMutator<GlobalCostModModel>().multiplier = 1.15f;
        } else if (difficulty == "Impoppable") {
            BTD6Rogue.mod.difficulty = new ImpoppableDifficulty();
            //__instance.GetGameModel().GetModModel("BTD6Rogue-Roguemode").GetMutator<GlobalCostModModel>().multiplier = 1.3f;
        }

        uiPanel = null!;
        __instance.GetGameModel().roundSet.rounds[0] = BTD6Rogue.mod.roundGenerator.GetRandomRoundModel(__instance.GetGameModel().roundSet.rounds[0], 0);
        Destroy(gameObject);
    }

    public static DifficultyChoicePanel Create(RectTransform menu, InGame __instance) {
        BTD6Rogue.mod.uiOpen = true;
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ReforgePanel", 0, 0, 2400, 1000),
            VanillaSprites.BrownInsertPanel);
        DifficultyChoicePanel difficultyChoicePanel = panel.AddComponent<DifficultyChoicePanel>();
        difficultyChoicePanel.__instance = __instance;
        uiPanel = difficultyChoicePanel!;

        ModHelperPanel inset = panel.AddPanel(new Info("InnerPanel") {
            AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 }, VanillaSprites.BrownInsertPanelDark);

        // 0  1  2  3  4

        List<float> xPos = new List<float>() {
            -900, -450, -0, 450, 900,
        };

        List<string> difficulties = new List<string>() {
            "Poppable", "Easy", "Medium", "Hard", "Impoppable"
        };

        List<string> difficultyIcons = new List<string>() {
            VanillaSprites.Red,
            VanillaSprites.Pink,
            VanillaSprites.Rainbow,
            VanillaSprites.MOABIcon,
            VanillaSprites.BADIcon,
        };

        ModHelperText infoText = inset.AddText(new Info("Title", 0, 400, 500, 500), "Difficulty", 96);
        ModHelperText subtitleText = inset.AddText(new Info("Sub Title", 0, 300, 2200, 500), "This effects when bloons can spawn", 56);

        foreach (string difficulty in difficulties) {
            ModHelperButton button = inset.AddButton(new Info("Difficulty", xPos[difficulties.IndexOf(difficulty)], 0, 400), VanillaSprites.YellowBtn, new Action(() => difficultyChoicePanel.ChooseDifficulty(difficulty)));
            ModHelperImage image = button.AddImage(new Info("Difficulty Icon", 0, 0, 350), difficultyIcons[difficulties.IndexOf(difficulty)]); 
            ModHelperText difficultyText = button.AddText(new Info("Difficulty Name", 0, -250, 500, 500), difficulty, 72);
            difficultyText.Text.enableAutoSizing = true;
        }

        return difficultyChoicePanel;
    }
}