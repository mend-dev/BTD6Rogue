using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using UnityEngine;

namespace BTD6Rogue;

public class PanelManager {

    public List<PanelQueueObject> panelQueue = new List<PanelQueueObject>();
    public bool isPanelOpen = false;

    public void AddPanelToQueue(RectTransform rect, InGame game, string panelName) {
        panelQueue.Add(new PanelQueueObject(rect, game, panelName));
        CheckPanelQueue();
    }

    public void CheckPanelQueue() {
        if (panelQueue.Count > 0 && !isPanelOpen) {
            isPanelOpen = true;
            InGame.instance.bridge.SetAutoPlay(false);
            PanelQueueObject panelData = panelQueue[0];
            panelQueue.RemoveAt(0);

            ModHelperPanel panel = panelData.rect.gameObject.AddModHelperPanel(new Info("Panel"),
                VanillaSprites.BrownInsertPanel);

            if (panelData.panelName == "ArtifactChoicePanel") {
                panel.AddComponent<ArtifactChoicePanel>();
                panel.SetInfo(new Info("Panel", 0, 0, 2400, 800));
            } else if (panelData.panelName == "HeroChoicePanel") {
                panel.AddComponent<HeroChoicePanel>();
                panel.SetInfo(new Info("Panel", 0, 0, 2400, 800));
            } else if (panelData.panelName == "InitialHeroChoicePanel") {
                panel.AddComponent<InitialHeroChoicePanel>();
                panel.SetInfo(new Info("Panel", 0, 0, 1920, 1080));
            } else if (panelData.panelName == "InitialTowerChoicePanel") {
                panel.AddComponent<InitialTowerChoicePanel>();
                panel.SetInfo(new Info("Panel", 0, 0, 1600, 1080));
            } else if (panelData.panelName == "ParagonChoicePanel") {
                panel.AddComponent<ParagonChoicePanel>();
                panel.SetInfo(new Info("Panel", 0, 0, 2400, 1000));
            } else if (panelData.panelName == "TowerChoicePanel") {
                panel.AddComponent<TowerChoicePanel>();
                panel.SetInfo(new Info("Panel", 0, 0, 2400, 1250));
            }

            RoguePanel panelComponent = panel.GetComponent<RoguePanel>();

            panelComponent.rect = panelData.rect;
            panelComponent.game = panelData.game;
            panelComponent.panel = panel;
            panelComponent.CreatePanel();
        } else if (panelQueue.Count == 0 && !isPanelOpen) {
            InGame.instance.bridge.SetAutoPlay(true);
        }
    }
}

public class PanelQueueObject {
    public RectTransform rect;
    public InGame game;
    public string panelName;

    public PanelQueueObject(RectTransform rect, InGame game, string panelName) {
        this.rect = rect;
        this.game = game;
        this.panelName = panelName;
    }
}
