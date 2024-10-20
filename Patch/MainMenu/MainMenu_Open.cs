using HarmonyLib;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Components;
using UnityEngine;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2Cpp;
using Il2CppAssets.Scripts.Unity.UI_New.Main.Home;
using BTD_Mod_Helper.Api;
using UnityEngine.UI;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace BTD6Rogue;

// Creates the button to open the menu for playing BTD6Rogue
[HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
internal static class MainMenu_Open {
	[HarmonyPostfix]
	private static void Postfix(MainMenu __instance) {
		GameObject rogueButton = __instance.transform.Cast<RectTransform>().FindChild("BottomButtonGroup").FindChild("Monkeys").gameObject.Duplicate(__instance.transform.GetParent());
		rogueButton.name = "Rogue";
		rogueButton.transform.position = new Vector3(0, 0, 0);
		rogueButton.transform.localPosition = new Vector3(-100, -600, 0);
		rogueButton.RemoveComponent<PipEventChecker>();

		SpriteReference sprite = ModContent.GetSpriteReference<BTD6Rogue>("PlayRogueImage");
		rogueButton.GetComponentInChildrenByName<Image>("Button").SetSprite(sprite.ToString());
		rogueButton.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = $"Rogue";
		rogueButton.GetComponentInChildren<Button>().SetOnClick(() => ModGameMenu.Open<RogueGameMenu>());
	}
}
