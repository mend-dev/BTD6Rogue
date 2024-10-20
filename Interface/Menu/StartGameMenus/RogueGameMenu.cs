using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity.Map;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = Il2CppSystem.Object;

namespace BTD6Rogue;

public class RogueGameMenu : ModGameMenu<ExtraSettingsScreen> {
	int displayedGameHistory = 0;
	List<GameData> gameHistory = BTD6Rogue.fileManager.LoadGameHistory();

	public override bool OnMenuOpened(Object data) {
		CommonForegroundHeader.SetText("BTD6 Rogue");
		gameHistory = BTD6Rogue.fileManager.LoadGameHistory();

		RectTransform panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
		GameObject panel = panelTransform.gameObject;
		panel.DestroyAllChildren();

		ModHelperPanel screenPanel = panel.AddModHelperPanel(
			new Info("ScreenPanel", InfoPreset.FillParent),
			null, RectTransform.Axis.Horizontal, 50, 100);

		CreateGameHistoryPanel(screenPanel);
		CreateMainMenuPanel(screenPanel);
		CreateGameStatsPanel(screenPanel);

		return false;
	}

	private ModHelperPanel CreateGameHistoryPanel(ModHelperPanel parent) {
		ModHelperPanel gameHistoryPanel = parent.AddPanel(
			new Info("GameHistoryBorder", InfoPreset.Flex) { },
			VanillaSprites.BrownInsertPanelDark, RectTransform.Axis.Vertical, 0, 20)
			.AddPanel(
			new Info("gameHistory", InfoPreset.Flex) { },
			VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 20, 20);

		if (gameHistory.Count < 1) {
			gameHistoryPanel.AddText(new Info("", InfoPreset.Flex), "no game history to show D:", 64);
			return gameHistoryPanel;
		}

		if (displayedGameHistory < 0 || displayedGameHistory >  gameHistory.Count - 1) { displayedGameHistory = 0; }


		ReloadGameHistoryInfo(gameHistoryPanel, gameHistory[displayedGameHistory]);
		return gameHistoryPanel;
	}

	private void ReloadGameHistoryInfo(ModHelperPanel gameHistoryPanel, GameData gameData) {
		gameHistoryPanel.gameObject.DestroyAllChildren();


		gameHistoryPanel.AddText(new Info("", InfoPreset.Flex), "Game History", 72);
		RogueGamemode rogueGamemode = GamemodeUtil.GetGamemodeById(gameData.gamemode);
		RogueMap rogueMap = MapUtil.GetMapById(gameData.map);
		RogueDifficulty rogueDifficulty = DifficultyUtil.GetDifficultyById(gameData.difficulty);

		ModHelperPanel mapBackground = gameHistoryPanel.AddPanel(new Info("MapInfo", InfoPreset.Flex) { FlexHeight = 6 }, rogueMap.MapImage, null);
		mapBackground.AddText(new Info("", InfoPreset.FillParent) { AnchorMin = new(0.02f, 0.02f), AnchorMax = new(0.98f, 0.98f) }, rogueGamemode.DisplayName, 72, Il2CppTMPro.TextAlignmentOptions.TopLeft);
		mapBackground.AddText(new Info("", InfoPreset.FillParent) { AnchorMin = new(0.02f, 0.02f), AnchorMax = new(0.98f, 0.98f) }, rogueMap.DisplayName, 72, Il2CppTMPro.TextAlignmentOptions.BottomLeft);
		ModHelperImage difficultyImage = mapBackground.AddImage(new Info("", InfoPreset.FillParent)
		{ AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.55f), Pivot = new(1f, 1f) }, rogueDifficulty.Image);
		AspectRatioFitter arf = difficultyImage.AddComponent<AspectRatioFitter>();
		arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

		gameHistoryPanel.AddText(new Info("", InfoPreset.Flex), "Result: " + gameData.gameState.ToString(), 64);
		gameHistoryPanel.AddText(new Info("", InfoPreset.Flex), "Round: " +  ((int) gameData.round + 1).ToString(), 64);
		gameHistoryPanel.AddText(new Info("", InfoPreset.Flex), "Cash: " + ((int) gameData.cash).ToString(), 64);
		gameHistoryPanel.AddText(new Info("", InfoPreset.Flex), "Lives: " + ((int) gameData.lives).ToString(), 64);


		ModHelperPanel navButtons = gameHistoryPanel.AddPanel(new Info("", InfoPreset.Flex), null, RectTransform.Axis.Horizontal, 25, 0);
		ModHelperButton prevGame = navButtons.AddButton(new Info("PrevButton", InfoPreset.Flex), VanillaSprites.BlueBtnLong,
			new Action(() => {
				displayedGameHistory--;
				if (displayedGameHistory < 0) { displayedGameHistory = gameHistory.Count - 1; }
				ReloadGameHistoryInfo(gameHistoryPanel, gameHistory[displayedGameHistory]);
			}));
		prevGame.AddText(new Info("", InfoPreset.FillParent), "<", 84);

		ModHelperButton nextGame = navButtons.AddButton(new Info("NextButton", InfoPreset.Flex), VanillaSprites.BlueBtnLong,
			new Action(() => {
				displayedGameHistory++;
				if (displayedGameHistory > gameHistory.Count - 1) { displayedGameHistory = 0; }
				ReloadGameHistoryInfo(gameHistoryPanel, gameHistory[displayedGameHistory]);
			}));
		nextGame.AddText(new Info("", InfoPreset.FillParent), ">", 84);
	}

	private ModHelperPanel CreateMainMenuPanel(ModHelperPanel parent) {
		ModHelperPanel mainMenuPanel = parent.AddPanel(
			new Info("MainMenu", InfoPreset.Flex) { },
			null, RectTransform.Axis.Vertical, 50, 50);

		ModHelperPanel loadGameInfo = mainMenuPanel.AddPanel(new Info("LoadGameInfo", InfoPreset.Flex) { FlexHeight = 4 }, null, RectTransform.Axis.Vertical, 50, 10);

		if (FileManager.HasSavedGameData()) {
			GameData saveData = BTD6Rogue.fileManager.LoadGameData();

			RogueGamemode rogueGamemode = GamemodeUtil.GetGamemodeById(saveData.gamemode);
			RogueMap rogueMap = MapUtil.GetMapById(saveData.map);
			RogueDifficulty rogueDifficulty = DifficultyUtil.GetDifficultyById(saveData.difficulty);

			ModHelperPanel mapBackground = loadGameInfo.AddPanel(new Info("MapInfo", InfoPreset.Flex) { FlexHeight = 10 }, rogueMap.MapImage, null);
			mapBackground.AddText(new Info("", InfoPreset.FillParent) { AnchorMin = new(0.02f, 0.02f), AnchorMax = new(0.98f, 0.98f) }, rogueGamemode.DisplayName, 72, Il2CppTMPro.TextAlignmentOptions.TopLeft);
			mapBackground.AddText(new Info("", InfoPreset.FillParent) { AnchorMin = new(0.02f, 0.02f), AnchorMax = new(0.98f, 0.98f) }, rogueMap.DisplayName, 72, Il2CppTMPro.TextAlignmentOptions.BottomLeft);
			ModHelperImage difficultyImage = mapBackground.AddImage(new Info("", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.55f), Pivot = new(1f, 1f) }, rogueDifficulty.Image);
			AspectRatioFitter arf = difficultyImage.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

			loadGameInfo.AddText(new Info("", InfoPreset.Flex), "Round: " + ((int) saveData.round + 1).ToString(), 56);
			loadGameInfo.AddText(new Info("", InfoPreset.Flex), "Cash: " + ((int) saveData.cash).ToString(), 56);
			loadGameInfo.AddText(new Info("", InfoPreset.Flex), "Lives: " + ((int) saveData.lives).ToString(), 56);

			ModHelperButton loadButton = mainMenuPanel.AddButton(new Info("LoadGameButton", InfoPreset.Flex), VanillaSprites.BlueBtnLong, new Action(() => {
				RogueGame.LoadGame();
			}));
			loadButton.AddText(new Info("", InfoPreset.FillParent), "Load Game", 64);
		} else {
			ModHelperButton loadButton = mainMenuPanel.AddButton(new Info("LoadGameButton", InfoPreset.Flex), VanillaSprites.BlueBtnLong, new Action(() => {}));
			loadButton.Button.enabled = false;
			loadButton.AddText(new Info("", InfoPreset.FillParent), "Load Game", 64);
		}


		ModHelperButton newButton = mainMenuPanel.AddButton(new Info("NewGameButton", InfoPreset.Flex), VanillaSprites.BlueBtnLong, new Action(() => {
			Open<SelectGamemodeMenu>();
		}));
		newButton.AddText(new Info("", InfoPreset.FillParent), "New Game", 64);
		return mainMenuPanel;
	}

	private ModHelperPanel CreateGameStatsPanel(ModHelperPanel parent) {
		ModHelperPanel gameStatsPanel = parent.AddPanel(
			new Info("GameStatsBorder", InfoPreset.Flex) { },
			VanillaSprites.BrownInsertPanelDark, RectTransform.Axis.Vertical, 0, 20)
			.AddPanel(
			new Info("GameStats", InfoPreset.Flex) { },
			VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 20, 20);

		gameStatsPanel.AddText(new Info("", InfoPreset.Flex), "COMING SOON", 64);
		return gameStatsPanel;
	}
}
