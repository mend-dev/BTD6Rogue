using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using UnityEngine;

namespace BTD6Rogue;

// Abstract class for Rogue Menus
// Rogue Menus are UI MonoBehaviors that are spawned within a BloonsRogue game
// Spawning is handled in MenuManager using the Append/Prepend functions

[RegisterTypeInIl2Cpp()]
public class RoguePanel : MonoBehaviour {

	public InGame game;
	public RectTransform rect;
	public ModHelperPanel parent;
	public RogueEncounter encounter;

	protected bool active = false; // Keep track of when logic can be run in the panel, handle state in panel

	public void SetupPanel(InGame game, RectTransform rect, ModHelperPanel parent, RogueEncounter encounter) {
		this.game = game;
		this.rect = rect;
		this.parent = parent;
		this.encounter = encounter;
	}

	public virtual void CreatePanel() {}

	public virtual void DestroyPanel() {
		BTD6Rogue.rogueGame.panelManager.isPanelOpen = false;
		BTD6Rogue.rogueGame.panelManager.CheckQueue();
		Destroy(gameObject);
	}
}
