using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

// Modifiers are changes to the game that are applied when a game is loaded
// Things like limiting TowerSets or the CHIMPS modifiers
public abstract class RogueModifier : NamedModContent {
	public virtual string Image => GetSpriteReference<BTD6Rogue>("ClassicGamemodeImage").ToString();

	public abstract void ApplyRogueModifier(ModModel model);
	public abstract void RemoveRogueModifier(ModModel model);

	public virtual void GameStarted(RogueGame rogueGame, InGame game) {
		rogueGame.towerManager.DisableTowerSet(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Support);
	}

	public override void Register() {}
}