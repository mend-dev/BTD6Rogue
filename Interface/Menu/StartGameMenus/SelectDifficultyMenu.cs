using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data.Skins;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppNewtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.UI;
using Object = Il2CppSystem.Object;

namespace BTD6Rogue;

public class SelectDifficultyMenu : ModGameMenu<ExtraSettingsScreen> {

	public override bool OnMenuOpened(Object data) {
		string gameData = JsonConvert.SerializeObject(data).Replace('"', ' ').Trim();

		CommonForegroundHeader.SetText("Select Difficulty");

		RectTransform panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
		GameObject panel = panelTransform.gameObject;
		panel.DestroyAllChildren();

		ModHelperPanel screenPanel = panel.AddModHelperPanel(
			new Info("ScreenPanel", InfoPreset.FillParent),
			null, RectTransform.Axis.Vertical, 0, 0);

		screenPanel.AddText(new Info("", InfoPreset.Flex) {}, "Difficulty controls the cost of towers and upgrades\nand the strength of bloons and bosses", 72);

		ModHelperPanel difficultiesPanel = screenPanel.AddPanel(
			new Info("RogueInfo", InfoPreset.Flex) { AnchorMin = new Vector2(0.05f, 0.25f), AnchorMax = new Vector2(0.95f, 0.75f), FlexHeight = 10 },
			null, RectTransform.Axis.Horizontal, 150, 60);
		RogueDifficulty[] difficulties = DifficultyUtil.GetOrderedRogueDifficulties();

		foreach (RogueDifficulty difficulty in difficulties) {



			var difficultyButton = difficultiesPanel.AddButton(new Info(difficulty.Name) { FlexWidth = 1 }, difficulty.Image, new Action(() => {
				Open<SelectModifierMenu>(gameData + "," + difficulty.Id);
			}));
			AspectRatioFitter arf = difficultyButton.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;


			difficultyButton.AddText(
				new Info(difficulty.Name, InfoPreset.FillParent),
				difficulty.DisplayName, 96, Il2CppTMPro.TextAlignmentOptions.Bottom);
		}

		return false;
	}
}
