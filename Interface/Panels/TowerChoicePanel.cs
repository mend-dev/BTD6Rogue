using System;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class TowerChoicePanel : RoguePanel {
	public void ChooseTower(TowerChoice towerChoice) {
		if (!active) { return; }
		active = false;
		encounter.ProcessChoice(towerChoice);
		DestroyPanel();
	}

	public void RerollTowers(TowerChoice[] towerChoices, bool useReroll = true) {
		if (!active) { return; }
		active = false;

		foreach (TowerChoice towerChoice in towerChoices) {
			BTD6Rogue.rogueGame.towerManager.UnlockTowerPath(towerChoice.towerId, Array.IndexOf(towerChoice.towerPaths, towerChoice.towerPaths.Max()));
		}

		if (useReroll) { BTD6Rogue.rogueGame.rerolls--; }
	    BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerChoicePanel", encounter);
		DestroyPanel();
	}

	public override void CreatePanel() {
		ModHelperPanel borderPanel = parent.AddPanel(new Info("Border Panel") { AnchorMin = new(0.225f, 0.25f), AnchorMax = new Vector2(0.775f, 0.75f) }, VanillaSprites.BrownInsertPanelDark);
		ModHelperPanel towerSelectPanel = borderPanel.AddPanel(new Info("Tower Select Panel", InfoPreset.FillParent), VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 20, 40);

		ModHelperText chooseText = towerSelectPanel.AddText(new Info("Tower Amount", InfoPreset.Flex), "Choose a Path", 86);
		ModHelperText infoText = towerSelectPanel.AddText(new Info("Tower Amount", InfoPreset.Flex), "None of these paths will show up again, choose wisely", 52);
		ModHelperPanel towerRow = towerSelectPanel.AddPanel(new Info("MapRow", InfoPreset.Flex) { FlexHeight = 4 }, null, RectTransform.Axis.Horizontal, 50);

		TowerChoice[] towerChoices = TowerUtil.CreateValidTowerChoices(BTD6Rogue.rogueGame);
		if (towerChoices == null) { BTD6Rogue.rogueGame.towerManager.UnlockAllTowers(); towerChoices = TowerUtil.CreateValidTowerChoices(BTD6Rogue.rogueGame); }

		for (int i = 0; i < towerChoices.Length; i++) {
			TowerChoice towerChoice = towerChoices[i];
			BTD6Rogue.rogueGame.towerManager.LockTowerPath(towerChoice.towerId, Array.IndexOf(towerChoice.towerPaths, towerChoice.towerPaths.Max()));

			string buttonSprite = VanillaSprites.TowerContainerPrimary;
			string towerSet = towerChoice.towerModel.GetTowerSet();
			if (towerSet == "Military") {
				buttonSprite = VanillaSprites.TowerContainerMilitary;
			} else if (towerSet == "Magic") {
				buttonSprite = VanillaSprites.TowerContainerMagic;
			} else if (towerSet == "Support") {
				buttonSprite = VanillaSprites.TowerContainerSupport;
			}

			ModHelperButton button = towerRow.AddButton(new Info("Tower Button", InfoPreset.Flex), buttonSprite, new Action(() => ChooseTower(towerChoice)));

			AspectRatioFitter arf = button.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

			ModHelperImage towerImage = button.AddImage(new Info("Image", InfoPreset.FillParent), towerChoice.towerImage.GetGUID());

			ModHelperText towerBaseName = towerImage.AddText(new Info("Tower Base Name", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, towerChoice.towerId, 72, Il2CppTMPro.TextAlignmentOptions.Bottom);
			ModHelperText towerUpgradeName = towerImage.AddText(new Info("Tower Name", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, towerChoice.towerName, 72, Il2CppTMPro.TextAlignmentOptions.Top);
			ModHelperText towerAmount = towerImage.AddText(new Info("Tower Amount", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, towerChoice.towerAmount.ToString(), 96, Il2CppTMPro.TextAlignmentOptions.TopRight);
		}

		if (BTD6Rogue.rogueGame.rerolls > 0) {
			ModHelperButton rerollButton = towerSelectPanel.AddButton(new Info("Reroll Button", InfoPreset.Flex) {}, VanillaSprites.BlueBtnLong, new Action(() => RerollTowers(towerChoices)));
			AspectRatioFitter arf = rerollButton.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
			arf.aspectRatio = 3;
			ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", InfoPreset.FillParent), "Reroll: " + BTD6Rogue.rogueGame.rerolls, 64);
		}

		active = true;
	}
}
