using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using MelonLoader;
using UnityEngine;
using System.Collections.Generic;
using BTD6Rogue.Artifacts;

namespace BTD6Rogue.Interface.Panels;

[RegisterTypeInIl2Cpp(false)]
public class ArtifactChoicePanel : RoguePanel
{

    public RogueArtifact[] artifacts = new RogueArtifact[3];
    public ArtifactGameData[] artifactGameDatas = new ArtifactGameData[3];

    public void ChooseArtifact(RogueArtifact artifact)
    {
        artifact.OnChooseArtifact(game);
        if (artifact.ArtifactLength != ArtifactLength.Once)
        {
            if (!BTD6Rogue.mod.currentGame.activeArtifacts.ContainsKey(artifact.Name))
            {
                BTD6Rogue.mod.currentGame.activeArtifacts.Add(artifact.Name, artifactGameDatas[Array.IndexOf(artifacts, artifact)]);
            }
            else
            {
                BTD6Rogue.mod.currentGame.activeArtifacts.Remove(artifact.Name);
                BTD6Rogue.mod.currentGame.activeArtifacts.Add(artifact.Name, artifactGameDatas[Array.IndexOf(artifacts, artifact)]);
            }
        }
        DestroyPanel();
    }

    public void RerollArtifacts()
    {
        BTD6Rogue.mod.currentGame.rerolls--;
        BTD6Rogue.mod.currentGame.panelManager.AddPanelToQueue(rect, game, nameof(ArtifactChoicePanel));
        DestroyPanel();
    }

    public override void CreatePanel()
    {
        ModHelperPanel inset = panel.AddPanel(new Info("InnerPanel") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = -50 },
            VanillaSprites.BrownInsertPanelDark);

        artifacts = ArtifactUtil.GetThreeArtifacts();

        for (int i = 0; i < artifacts.Length; i++)
        {
            artifactGameDatas[i] = new ArtifactGameData(artifacts[i]);
        }

        List<int> xPos = new List<int>() { -800, 0, 800 };

        for (int i = 0; i < artifacts.Length; i++)
        {
            ArtifactGameData currentArtfact = artifactGameDatas[i];
            ModHelperButton towerButton = inset.AddButton(new Info("Artifact Button", xPos[i], 0, 650), VanillaSprites.GreenBtn, new Action(() => ChooseArtifact(currentArtfact.baseArtifact)));
            towerButton.AddImage(new Info("Image") { AnchorMin = new Vector2(0, 0), AnchorMax = new Vector2(1, 1), Size = 50 }, currentArtfact.baseArtifact.ArtifactSprite);
            ModHelperText towerName = towerButton.AddText(new Info("Artifact Name", 0, -225, 650, 76), currentArtfact.baseArtifact.DisplayName, 64);
            towerName.Text.enableAutoSizing = true;

            ModHelperText artifactLength = towerButton.AddText(new Info("Artifact Range", 150, 250, 650, 76), currentArtfact.artifactRange.ToString(), 64);
            ModHelperText artifactRange = towerButton.AddText(new Info("Artifact Length", -150, 250, 650, 76), currentArtfact.artifactLength.ToString(), 64);
            ModHelperText artifactTimer = towerButton.AddText(new Info("Artifact Timer", 0, 250, 650, 76), currentArtfact.timer.ToString(), 64);
        }

        if (BTD6Rogue.mod.currentGame.rerolls > 0)
        {
            ModHelperButton rerollButton = inset.AddButton(new Info("Reroll Button", 0, -500, 400, 200), VanillaSprites.BlueBtn, new Action(() => RerollArtifacts()));
            ModHelperText towerName = rerollButton.AddText(new Info("Tower Name", 0, 0, 650, 76), "Reroll: " + BTD6Rogue.mod.currentGame.rerolls, 64);
        }
    }
}