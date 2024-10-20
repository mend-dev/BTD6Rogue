using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using UnityEngine;
using System;
using Il2CppNewtonsoft.Json;
using Object = Il2CppSystem.Object;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New;
using UnityEngine.UI;

namespace BTD6Rogue;

public class PlayRogueMenu : ModGameMenu<ExtraSettingsScreen> {

	public override bool OnMenuOpened(Object data) {
		string[] gameData = JsonConvert.SerializeObject(data).Replace('"', ' ').Trim().Split(",");
		RogueGamemode gamemode = GamemodeUtil.GetGamemodeById(gameData[0]);
		RogueMap map = MapUtil.GetMapById(gameData[1]);
		RogueDifficulty difficulty = DifficultyUtil.GetDifficultyById(gameData[2]);
		RogueModifier[] modifiers = ModifierUtil.ModifiersFromIds(gameData[3].Split("$$")).ToArray();

		CommonForegroundHeader.SetText("Ready?");

		RectTransform panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
		GameObject panel = panelTransform.gameObject;
		panel.DestroyAllChildren();

		ModHelperPanel screenPanel = panel.AddModHelperPanel(
			new Info("ScreenPanel", InfoPreset.FillParent) { AnchorMin = new(0.1f, 0.1f), AnchorMax = new(0.9f, 0.9f) },
			null, RectTransform.Axis.Horizontal, 50);


		ModHelperPanel borderPanel = screenPanel.AddPanel(new Info("", InfoPreset.Flex),
			VanillaSprites.BrownInsertPanelDark);
		ModHelperPanel gamemodePanel = borderPanel.AddPanel(new Info("") { AnchorMin = new Vector2(0.02f, 0.01f), AnchorMax = new Vector2(0.98f, 0.99f) },
			gamemode.Portrait, RectTransform.Axis.Vertical);
		ModHelperPanel gamemodeImage = gamemodePanel.AddPanel(new Info("", InfoPreset.Flex),
			gamemode.Image, RectTransform.Axis.Vertical, 0, 40);
		ModHelperText gamemodeName = gamemodeImage.AddText(new Info("Name", InfoPreset.Flex) { FlexHeight = 1 },
			gamemode.DisplayName, 128, Il2CppTMPro.TextAlignmentOptions.Top);

		ModHelperPanel middleSection = screenPanel.AddPanel(new Info("MapBorder", InfoPreset.Flex), null, RectTransform.Axis.Vertical, 50, 0);
		
		ModHelperPanel mapBorder = middleSection.AddPanel(new Info("MapBorder", InfoPreset.Flex), VanillaSprites.BrownInsertPanelDark, RectTransform.Axis.Horizontal, 20, 25);
		ModHelperPanel mapBackground = mapBorder.AddPanel(new Info("MapInfo", InfoPreset.Flex), map.MapImage, RectTransform.Axis.Horizontal);
		mapBackground.AddText(new Info("", InfoPreset.Flex), map.DisplayName, 96, Il2CppTMPro.TextAlignmentOptions.Bottom);

		ModHelperPanel difficultyImage = middleSection.AddPanel(new Info("", InfoPreset.Flex), difficulty.Image, RectTransform.Axis.Horizontal, 0, 0);
		difficultyImage.AddText(new Info("", InfoPreset.Flex), difficulty.DisplayName, 96, Il2CppTMPro.TextAlignmentOptions.Bottom);
		AspectRatioFitter arf = difficultyImage.AddComponent<AspectRatioFitter>();
		arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

		ModHelperPanel gameInfoBorder = screenPanel.AddPanel(new Info("GameInfoBorder", InfoPreset.Flex), VanillaSprites.BrownInsertPanelDark, RectTransform.Axis.Vertical, 20, 25);
		ModHelperPanel gameInfo = gameInfoBorder.AddPanel(new Info("GameInfo", InfoPreset.Flex), VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 20, 25);

		// Gamemode
		//ModHelperPanel gamemodeInfo = screenPanel.AddPanel(new Info("GamemodeInfo", InfoPreset.Flex), null, RectTransform.Axis.Horizontal);
		//gamemodeInfo.AddImage()
		//gamemodeInfo.AddText(new Info("", InfoPreset.Flex), gamemode, 64);

		// Map
		//gamemodeInfo.AddImage()
		//mapInfo.AddText(new Info("", InfoPreset.Flex), map.DisplayName, 64);

		// Difficulty
		//ModHelperPanel difficultyInfo = screenPanel.AddPanel(new Info("DifficultyInfo", InfoPreset.Flex), null, RectTransform.Axis.Horizontal);
		//gamemodeInfo.AddImage()
		//difficultyInfo.AddText(new Info("", InfoPreset.Flex), difficulty, 64);

		// Modifiers

		if (modifiers.Length > 0) {
			gameInfo.AddText(new Info("", InfoPreset.Flex), "Modifiers", 96);
		}
		foreach (RogueModifier modifier in modifiers) {
			gameInfo.AddText(new Info("", InfoPreset.Flex), modifier.DisplayName, 64);
		}

		ModHelperButton playGamemodeButton = gameInfo.AddButton(new Info("", 400, 200), VanillaSprites.GreenBtn, new Action(() => {
			BTD6Rogue.rogueGame = new RogueGame(
				gamemode, map, difficulty, modifiers
				);
			BTD6Rogue.rogueGame.NewGame();
		}));
		playGamemodeButton.AddText(new Info("GamemodeButton", InfoPreset.FillParent), "Play", 72);

		return false;
	}
}
