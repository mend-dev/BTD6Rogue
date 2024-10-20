using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using System;
using UnityEngine;
using Il2CppNewtonsoft.Json;
using Object = Il2CppSystem.Object;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;

namespace BTD6Rogue;

public class SelectMapMenu : ModGameMenu<ExtraSettingsScreen> {

	public override bool OnMenuOpened(Object data) {
		string gameData = JsonConvert.SerializeObject(data).Replace('"', ' ').Trim();

		CommonForegroundHeader.SetText("Select Map");
		RectTransform panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
		GameObject panel = panelTransform.gameObject;
		panel.DestroyAllChildren();

		ModHelperPanel rogueMenu = panel.AddModHelperPanel(
			new Info("RogueInfo") { AnchorMin = new Vector2(0.08f, 0), AnchorMax = new Vector2(0.92f, 1) },
			null, RectTransform.Axis.Vertical, 25, 25);
		
		//ModHelperPanel pagnationBar = rogueMenu.AddPanel
		//	(new Info("PagnationBar", InfoPreset.Flex) { FlexHeight = 1 },
		//	VanillaSprites.BrownInsertPanelDark);

		ModHelperScrollPanel mapGrid = rogueMenu.AddScrollPanel(
			new Info("MapScrollPanel", InfoPreset.Flex) { FlexHeight = 5 },
			RectTransform.Axis.Vertical, null, 50, 40);;
		mapGrid.Mask.showMaskGraphic = false;
		
		int x = 0;
		ModHelperPanel currentRow = null!;

		RogueMap[] maps = MapUtil.GetOrderedRogueMaps();

		foreach (RogueMap map in maps) {
			if (x % 4 == 0) {
				currentRow = mapGrid.ScrollContent.AddPanel(
					new Info("MapRow", 3300, 650) { FlexWidth = 1 },
					null, RectTransform.Axis.Horizontal, 50, 0);
			}

			

			var mapImageBorder = currentRow.AddButton(new Info(map.MapName + "Panel") { Flex = 1 }, VanillaSprites.BrownInsertPanel, new Action(() => {
				Open<SelectDifficultyMenu>(gameData + "," + map.Id);
			}));
			var mapPanel = mapImageBorder.AddPanel(
				new Info(map.MapName) { AnchorMin = new Vector2(0.02f, 0.02f), AnchorMax = new Vector2(0.98f, 0.98f) },
				map.MapImage, RectTransform.Axis.Vertical, 20, 20);

			var test = mapPanel.AddText(
				new Info(map.MapName, InfoPreset.Flex),
				map.MapName, 84, Il2CppTMPro.TextAlignmentOptions.Bottom);
			x += 1;
		}

		return false;
	}
}
