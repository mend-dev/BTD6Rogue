using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;

namespace BTD6Rogue;

public class RoguePanel : MonoBehaviour {

    public RectTransform rect;
    public InGame game;
    public ModHelperPanel panel;

    public virtual void CreatePanel() {
    
    }

    public virtual void DestroyPanel() {
        BTD6Rogue.mod.currentGame.panelManager.isPanelOpen = false;
        BTD6Rogue.mod.currentGame.panelManager.CheckPanelQueue();
        Destroy(gameObject);
    }
}