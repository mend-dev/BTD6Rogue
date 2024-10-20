using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using System;
using UnityEngine;
using Il2CppNewtonsoft.Json;
using Object = Il2CppSystem.Object;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using System.Collections.Generic;
using UnityEngine.UI;

namespace BTD6Rogue;

public class SelectModifierMenu : ModGameMenu<ExtraSettingsScreen> {
	List<RogueModifier> toggledModifiers = new List<RogueModifier>();

	public override bool OnMenuOpened(Object data) {
		string gameData = JsonConvert.SerializeObject(data).Replace('"', ' ').Trim();

		CommonForegroundHeader.SetText("Select Modifiers");
		RectTransform panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
		GameObject panel = panelTransform.gameObject;
		panel.DestroyAllChildren();


		ModHelperPanel rogueMenu = panel.AddModHelperPanel(
			new Info("RogueInfo") { AnchorMin = new Vector2(0.08f, 0.1f), AnchorMax = new Vector2(0.92f, 0.9f) },
			null, RectTransform.Axis.Vertical, 25, 25);

		rogueMenu.AddText(new Info("", InfoPreset.Flex) { FlexHeight = 1 }, "Modifiers allow you to make the game harder in various ways!", 72);



		int x = 0;
		ModHelperPanel currentRow = null!;
		List<RogueModifier> modifiers = ModContent.GetContent<RogueModifier>();

		foreach (RogueModifier modifier in modifiers) {
			if (x % 6 == 0) {
				currentRow = rogueMenu.AddPanel(
					new Info("ModifierRow", 2000, 400) { FlexWidth = 1, FlexHeight = 2 },
					null, RectTransform.Axis.Horizontal, 60, 60);
			}

			var modifierCheckbox = currentRow.AddCheckbox(
				new Info("Checkbox", InfoPreset.Flex), toggledModifiers.Contains(modifier), VanillaSprites.BlueBtn,
				new Action<bool>((value) => { SetModifier(modifier, value); }));
			AspectRatioFitter arf = modifierCheckbox.AddComponent<AspectRatioFitter>();
			arf.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;

			modifierCheckbox.AddText(new Info("", InfoPreset.FillParent), modifier.DisplayName, 72, Il2CppTMPro.TextAlignmentOptions.Bottom);

			x += 1;
		}

		ModHelperButton playGamemodeButton = rogueMenu.AddButton(new Info("", 400, 200), VanillaSprites.GreenBtn, new Action(() => {
			string modifierIds = "";
			foreach (RogueModifier modifier in toggledModifiers) {
				modifierIds += modifier.Id + "$$";
			}
			Open<PlayRogueMenu>(gameData + "," + modifierIds);
		}));
		playGamemodeButton.AddText(new Info("GamemodeButton", InfoPreset.FillParent), "Play", 72);


		return false;
	}

	public void SetModifier(RogueModifier modifier, bool active) {
		if (active && !toggledModifiers.Contains(modifier)) {
			toggledModifiers.Add(modifier);
		} else if (!active && toggledModifiers.Contains(modifier)) {
			toggledModifiers.Remove(modifier);
		}
	}
}
