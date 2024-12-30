using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = Il2CppSystem.Object;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;

namespace BTD6Rogue;


public class SelectGamemodeMenu : ModGameMenu<ExtraSettingsScreen> {

	public override bool OnMenuOpened(Object data) {
		// Remove base ExtraSettingsScreen UI
		CommonForegroundHeader.SetText("Select Gamemode");
		RectTransform panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
		GameObject panel = panelTransform.gameObject;
		panel.DestroyAllChildren();

		ModHelperPanel gamemodesPanel = panel.AddModHelperPanel(
			new Info("RogueInfo") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1) },
			null, RectTransform.Axis.Horizontal, 150, 150);

		List<RogueGamemode> gamemodes = GetContent<RogueGamemode>();
		
		// Make a large image button for each of the RogueGamemodes
		// TODO: Turn this into a horizontal scroll panel
		foreach (RogueGamemode gamemode in gamemodes) {
			ModHelperButton borderPanel = gamemodesPanel.AddButton(new Info("", InfoPreset.Flex),
				VanillaSprites.BrownInsertPanelDark, new Action(() => {
					if (!gamemode.Enabled) {
						PopupScreen.instance.SafelyQueue(screen => {
							screen.ShowOkPopup(gamemode.DisplayName + " is coming soon!");
						});
						return;
					}
					Open<SelectMapMenu>(gamemode.Id);
				}));

			ModHelperPanel gamemodePanel = borderPanel.AddPanel(new Info("") { AnchorMin = new Vector2(0.02f, 0.01f), AnchorMax = new Vector2(0.98f, 0.99f) },
				gamemode.Portrait, RectTransform.Axis.Vertical);

			ModHelperPanel gamemodeImage = gamemodePanel.AddPanel(new Info("", InfoPreset.Flex),
				gamemode.Image, RectTransform.Axis.Vertical, 0, 40);

			ModHelperText gamemodeName = gamemodeImage.AddText(new Info("Name", InfoPreset.Flex) { FlexHeight = 1 },
				gamemode.DisplayName, 128, Il2CppTMPro.TextAlignmentOptions.Top);

			ModHelperText gamemodeDescription = gamemodeImage.AddText(new Info("Description", InfoPreset.Flex) { FlexHeight = 1 }, gamemode.Description, 72,
				Il2CppTMPro.TextAlignmentOptions.Bottom);
		}
		return false;
	}
}