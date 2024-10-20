using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class HeroSelectPanel : RoguePanel {

	public void ChooseHero(HeroChoice heroChoice) {
		if (!active) { return; }
		active = false;
		encounter.ProcessChoice(heroChoice);
		DestroyPanel();
	}

	public override void CreatePanel() {
		ModHelperPanel borderPanel = parent.AddPanel(new Info("Border Panel") { AnchorMin = new (0.225f, 0.275f), AnchorMax = new Vector2(0.775f, 0.725f) }, VanillaSprites.BrownInsertPanelDark);
		ModHelperPanel towerSelectPanel = borderPanel.AddPanel(new Info("Tower Select Panel", InfoPreset.FillParent), VanillaSprites.BrownInsertPanel, RectTransform.Axis.Vertical, 50, 50);

		HeroChoice[] heroChoices = HeroUtil.GetHeroesChoiceData(BTD6Rogue.rogueGame);

		int gridWidth = 6;

		ModHelperPanel currentRow = null!;

		for (int i = 0; i < heroChoices.Length; i++) {
			if (i % gridWidth == 0) {
				currentRow = towerSelectPanel.AddPanel(new Info("MapRow", InfoPreset.Flex), null, RectTransform.Axis.Horizontal, 50);
			}
			HeroChoice heroChoice = heroChoices[i];
			ModHelperButton button = currentRow.AddButton(new Info("Tower Button", InfoPreset.Flex), VanillaSprites.YellowBtn, new Action(() => ChooseHero(heroChoice)));
			AspectRatioFitter arf = button.gameObject.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
			button.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, heroChoice.towerImage.GetGUID());
		}
		active = true;
	}
}
