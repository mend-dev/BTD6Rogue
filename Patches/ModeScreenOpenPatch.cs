using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using Il2CppAssets.Scripts.Unity.UI_New.Main.DifficultySelect;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Components;
using System;
using BTD_Mod_Helper.Api;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;

namespace BTD6Rogue;

[HarmonyPatch(typeof(ModeScreen), nameof(ModeScreen.Open))]
static class ModeScreenOpenPatch {
    [HarmonyPostfix]
    static void Postfix(ModeScreen __instance) {
        if (__instance.easyModes.active == false && __instance.mediumModes.active == false && __instance.hardModes.active == false) {
            GameObject modeObject = __instance.mediumModes.gameObject;
            GameObject modeButtonObject = __instance.gameObject.GetComponentInChildrenByName<Transform>("Standard").gameObject;
            __instance.headerTxt.text = "Rogue";
            __instance.subTxt.text = "";
            __instance.medal.gameObject.SetActive(false);

            GameObject newMode = UnityEngine.Object.Instantiate(modeObject, __instance.transform);
            newMode.DestroyAllChildren();
            newMode.SetActive(true);

            GameObject newButton = UnityEngine.Object.Instantiate(modeButtonObject, newMode.transform);
            newButton.transform.position = new Vector3(720, 0, 0);
            newButton.SetActive(true);


            newButton.name = "BTD6Rogue-Roguemode";
            newButton.gameObject.GetComponentInChildrenByName<Il2Cpp.NK_TextMeshProUGUI>("Mode").localizeKey = "Mode BTD6Rogue-Roguemode";

            ModeButton modeButton = newButton.GetComponent<ModeButton>();
            modeButton.modeType = "BTD6Rogue-Roguemode";
            modeButton.medal.active = false;
            modeButton.Unlock();

            ModHelperPanel panel = __instance.gameObject.AddModHelperPanel(new Info("", 0, 0, 1920, 1080));
            BTD6Rogue.mod.gameSettingsUi = panel.AddComponent<RogueGameSettingsUi>();
            BTD6Rogue.mod.gameSettingsUi.CreateRogueSettingsUi(__instance.gameObject, panel);


        }
    }
}

[HarmonyPatch(typeof(DifficultySelectScreen), nameof(DifficultySelectScreen.Open))]
static class DifficultySelectScreenOpenPatch {
    [HarmonyPrefix]
    static void Prefix(DifficultySelectScreen __instance) {
        ModHelperPanel panel = __instance.gameObject.AddModHelperPanel(new Info("", 0, 0, 500, 500));
        SpriteReference sprite = ModContent.GetSpriteReference<BTD6Rogue>("RogueLogo");
        panel.AddButton(new Info("", -1500, -150, 500), sprite.ToString(), new Action(() => __instance.OpenModeSelectUi("Rogue")));
    }
}
