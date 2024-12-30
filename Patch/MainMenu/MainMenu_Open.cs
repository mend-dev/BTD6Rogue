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
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Data.Quests;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Data.Quests.UI;
using System.Linq;
using System.Collections.Generic;
using Il2CppNinjaKiwi.Common;

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

		// Code for custom dialogue pop ups using the base QuestUI and related systems (will use in future)
		/*
		LocalizationManager lm = LocalizationManager.Instance;

		lm.textTable["DialogueScoopsTaleIQuest1UI1"] = "Mend is super cool and awesome";

		CommonForegroundScreen instance = CommonForegroundScreen.instance;
		BTD6Rogue.LogMessage("COUNT: " + Game.instance.questTrackerManager.QuestData.quests.Count);
		QuestDetails test = Game.instance.questTrackerManager.QuestData.quests[31];
		DialogueTaskIntroduction taskIntro = null!;
		TaskData td = test.GetTaskDataForImport(0, 0);
		td.TryGetTaskDialogue(out taskIntro);
		instance.TryRunAnimatedDialogueSequence(taskIntro);
		
		List<string> localkeys = Il2CppNinjaKiwi.Common.LocalizationManager.Instance.GetTextTable().Keys().ToList();
		for (int i = 0; i < localkeys.Count; i++) {
			BTD6Rogue.LogMessage(localkeys[i]);
		}*/
	}
}
