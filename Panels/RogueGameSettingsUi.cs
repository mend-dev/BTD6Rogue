using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class RogueGameSettingsUi : MonoBehaviour {

    List<ModHelperButton> difficultyButtons = new List<ModHelperButton>();
    List<ModHelperCheckbox> towerSetCheckBoxes = new List<ModHelperCheckbox>();
    List<ModHelperCheckbox> bossCheckboxes = new List<ModHelperCheckbox>();

    ModHelperCheckbox continuesCheckbox = null!;
    ModHelperCheckbox livesCheckbox = null!;
    ModHelperCheckbox incomeCheckbox = null!;
    ModHelperCheckbox monkeyKnowledgeCheckbox = null!;
    ModHelperCheckbox powersCheckbox = null!;
    ModHelperCheckbox sellingCheckbox = null!;
    ModHelperCheckbox alternateRoundsCheckbox = null!;

    public string selectedDifficulty = "";
    public List<string> gameModifiers = new List<string>();

    public void SetDifficulty(string difficultyName) {
        RogueDifficulty difficulty = DifficultyUtil.GetDifficulty(difficultyName);

        foreach (ModGameMode gamemode in ModContent.GetContent<ModGameMode>()) {
            if (gamemode.Name.Contains("Roguemode")) {
                Roguemode game = (Roguemode)gamemode;
                game.ChangeCostModifier(difficulty.CostModifier);
            }
        }

        foreach (ModHelperButton button in difficultyButtons) {
            button.Image.SetSprite(Game.instance.CreateSpriteReference(VanillaSprites.RedBtn));
            if (button.initialInfo.Name == difficultyName) {
                button.Image.SetSprite(Game.instance.CreateSpriteReference(VanillaSprites.GreenBtn));
            }
        }

        selectedDifficulty = difficultyName;
    }

    public void SetTowerSets(bool active, string towerSet) {
        if (active) {
            BTD6Rogue.mod.availableTowerSets.Add(towerSet);
        } else {
            BTD6Rogue.mod.availableTowerSets.Remove(towerSet);
        }

        foreach (ModGameMode gamemode in ModContent.GetContent<ModGameMode>()) {
            if (gamemode.Name.Contains("Roguemode")) {
                Roguemode game = (Roguemode)gamemode;
                game.ChangeTowerSet(!active, towerSet);
            }
        }
    }

    public void SetBosses(bool active, string boss) {
        if (active) {
            BTD6Rogue.mod.availableBosses.Add(boss);
        } else {
            BTD6Rogue.mod.availableBosses.Remove(boss);
        }
    }

    public void SetModifiers(bool active, string modifier) {
        if (active) {
            gameModifiers.Add(modifier);
        } else {
            gameModifiers.Remove(modifier);
        }

        foreach (ModGameMode gamemode in ModContent.GetContent<ModGameMode>()) {
            if (gamemode.Name.Contains("Roguemode")) {
                Roguemode game = (Roguemode)gamemode;

                if (modifier == "Continues") {
                    game.SetContinuesEnabled(active);
                } else if (modifier == "Lives") {
                    game.SetLivesEnabled(active);
                } else if (modifier == "Income") {
                    game.SetIncomeEnabled(active);
                } else if (modifier == "Monkey Knowledge") {
                    game.SetMonkeyKnoweldgeEnabled(active);
                } else if (modifier == "Powers") {
                    game.SetPowersEnabled(active);
                } else if (modifier == "Selling") {
                    game.SetSellingEnabled(active);
                }
            }
        }
    }

    public void CreateRogueSettingsUi(GameObject gameObject, ModHelperPanel panel) {

        RogueDifficulty[] difficulties = DifficultyUtil.GetAllDifficultues();
        string[] difficultyIcons = new string[5] {
            VanillaSprites.Red,
            VanillaSprites.Pink,
            VanillaSprites.Rainbow,
            VanillaSprites.MOABIcon,
            VanillaSprites.BADIcon,
        };

        for (int i = 0; i < difficulties.Length; i++) {
            RogueDifficulty difficulty = difficulties[i];
            ModHelperButton button = panel.AddButton(new Info(difficulty.DisplayName, i * 450 - 900, 1000, 400), VanillaSprites.RedBtn, new Action(() => SetDifficulty(difficulty.DisplayName)));
            difficultyButtons.Add(button);
            ModHelperImage image = button.AddImage(new Info("Difficulty Icon", 0, 0, 350), difficultyIcons[Array.IndexOf(difficulties, difficulty)]);
            ModHelperText difficultyText = button.AddText(new Info("Difficulty Name", 0, -250, 500, 500), difficulty.DisplayName, 72);
            difficultyText.Text.enableAutoSizing = true;
        }
        SetDifficulty("Medium");


        string[] towerSets = TowerUtil.GetAllTowerSets();
        BTD6Rogue.mod.availableTowerSets.Clear();
        for (int i = 0; i < towerSets.Length; i++) {
            string towerSet = towerSets[i];

            UnityAction<bool> action = new Action<bool>((j) => {
                SetTowerSets(j, towerSet);
            });

            ModHelperCheckbox checkbox = panel.AddCheckbox(new Info("", i * 400 - 800, 500, 300), true, VanillaSprites.YellowBtn, action);
            checkbox.AddText(new Info("", 0, -100, 300), towerSet);
            towerSetCheckBoxes.Add(checkbox);
        }

        string[] bosses = new string[5] { "RogueBloonarius", "RogueVortex", "RogueLych", "RogueDreadbloon", "RoguePhayze" };
        BTD6Rogue.mod.availableBosses.Clear();
        for (int i = 0; i < bosses.Length; i++) {
            string boss = bosses[i];

            UnityAction<bool> action = new Action<bool>((j) => {
                SetBosses(j, boss);
            });

            ModHelperCheckbox checkbox = panel.AddCheckbox(new Info("", i * 400 - 800, 100, 300), true, VanillaSprites.YellowBtn, action);
            checkbox.AddText(new Info("", 0, -100, 300), boss);
            bossCheckboxes.Add(checkbox);
        }

        continuesCheckbox = panel.AddCheckbox(new Info("", 900, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Continues"); }));
        continuesCheckbox.AddText(new Info("", 0, -100, 200), "Continues");
        livesCheckbox = panel.AddCheckbox(new Info("", 600, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Lives"); }));
        livesCheckbox.AddText(new Info("", 0, -100, 200), "Lives");
        incomeCheckbox = panel.AddCheckbox(new Info("", 300, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Income"); }));
        incomeCheckbox.AddText(new Info("", 0, -100, 200), "Income");
        monkeyKnowledgeCheckbox = panel.AddCheckbox(new Info("", 0, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Monkey Knowledge"); }));
        monkeyKnowledgeCheckbox.AddText(new Info("", 0, -100, 200), "Monkey Knowledge");
        powersCheckbox = panel.AddCheckbox(new Info("", -300, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Powers"); }));
        powersCheckbox.AddText(new Info("", 0, -100, 200), "Powers");
        sellingCheckbox = panel.AddCheckbox(new Info("", -600, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Selling"); }));
        sellingCheckbox.AddText(new Info("", 0, -100, 200), "Selling");
        alternateRoundsCheckbox = panel.AddCheckbox(new Info("", -900, -300, 200), true, VanillaSprites.BlueBtn, new Action<bool>((j) => { SetModifiers(j, "Alternate Rounds"); }));
        alternateRoundsCheckbox.AddText(new Info("", 0, -100, 200), "Alternate Rounds");

        gameModifiers.Add("Continues");
        gameModifiers.Add("Lives");
        gameModifiers.Add("Income");
        gameModifiers.Add("Monkey Knowledge");
        gameModifiers.Add("Powers");
        gameModifiers.Add("Selling");
        gameModifiers.Add("Alternate Rounds");
    }
}
