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
public class HeroChoicePanel : RoguePanel {
	public void ChooseHero(HeroChoice heroChoice) {
		if (!active) { return; }
		active = false;
		encounter.ProcessChoice(heroChoice);
		DestroyPanel();
	}

	public void RerollTowers(HeroChoice[] towerChoices, bool useReroll = true) {
		if (!active) { return; }
		active = false;

		foreach (HeroChoice towerChoice in towerChoices) {
			BTD6Rogue.rogueGame.towerManager.UnlockHero(towerChoice.towerId);
		}

		if (useReroll) { BTD6Rogue.rogueGame.rerolls--; }
		BTD6Rogue.rogueGame.panelManager.AppendPanel("HeroChoicePanel", encounter);
		DestroyPanel();
	}

	public override void CreatePanel() {
		ModHelperPanel borderPanel = parent.AddPanel(new Info("Border Panel") { AnchorMin = new(0.225f, 0.25f), AnchorMax = new Vector2(0.775f, 0.75f) }, VanillaSprites.BrownInsertPanelDark);
		ModHelperPanel towerSelectPanel = borderPanel.AddPanel(new Info("Tower Select Panel", InfoPreset.FillParent), VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 20, 40);

		ModHelperText chooseText = towerSelectPanel.AddText(new Info("Tower Amount", InfoPreset.Flex), "Choose a Hero", 86);
		ModHelperText infoText = towerSelectPanel.AddText(new Info("Tower Amount", InfoPreset.Flex), "None of these heroes will show up again, choose wisely", 52);
		ModHelperPanel towerRow = towerSelectPanel.AddPanel(new Info("MapRow", InfoPreset.Flex) { FlexHeight = 4 }, null, RectTransform.Axis.Horizontal, 50);

		HeroChoice[] heroChoices = HeroUtil.CreateValidHeroChoices(BTD6Rogue.rogueGame);
		if (heroChoices == null) { BTD6Rogue.rogueGame.towerManager.UnlockAllHeroes(); heroChoices = HeroUtil.CreateValidHeroChoices(BTD6Rogue.rogueGame); }

		for (int i = 0; i < heroChoices.Length; i++) {
			HeroChoice heroChoice = heroChoices[i];
			BTD6Rogue.rogueGame.towerManager.LockHero(heroChoice.towerId);

			ModHelperButton button = towerRow.AddButton(new Info("Tower Button", InfoPreset.Flex), VanillaSprites.TowerContainerHero, new Action(() => ChooseHero(heroChoice)));

			AspectRatioFitter arf = button.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

			ModHelperImage towerImage = button.AddImage(new Info("Image", InfoPreset.FillParent), heroChoice.towerImage.GetGUID());


			ModHelperText towerUpgradeName = towerImage.AddText(new Info("Tower Name", InfoPreset.FillParent) { AnchorMin = new(0.05f, 0.05f), AnchorMax = new(0.95f, 0.95f) }, heroChoice.towerId, 72, Il2CppTMPro.TextAlignmentOptions.Bottom);
		}

		if (BTD6Rogue.rogueGame.rerolls > 0) {
			ModHelperButton rerollButton = towerSelectPanel.AddButton(new Info("Reroll Button", InfoPreset.Flex) { }, VanillaSprites.BlueBtnLong, new Action(() => RerollTowers(heroChoices)));
			AspectRatioFitter arf = rerollButton.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
			arf.aspectRatio = 3;
			ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", InfoPreset.FillParent), "Reroll: " + BTD6Rogue.rogueGame.rerolls, 64);
		}

		active = true;
	}
}
