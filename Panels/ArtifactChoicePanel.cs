using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

[RegisterTypeInIl2Cpp(false)]
public class ArtifactChoicePanel : MonoBehaviour {

    public InGame __instance = null!;
    public string[] heroChoices = new string[3];

    public ArtifactChoicePanel(IntPtr ptr) : base(ptr) { }

    public void ChooseArtifact(string artifact) {
        __instance.bridge.SetAutoPlay(true);
        Destroy(gameObject);
    }

    public static ArtifactChoicePanel Create(RectTransform menu, InGame __instance) {
        ModHelperPanel panel = menu.gameObject.AddModHelperPanel(new Info("ArtifactChoicePanel", 0, 0, 2400, 800),
            VanillaSprites.BrownInsertPanel);
        ArtifactChoicePanel artifactChoicePanel = panel.AddComponent<ArtifactChoicePanel>();
        artifactChoicePanel.__instance = __instance;

        ModHelperPanel inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        return artifactChoicePanel;
    }
}