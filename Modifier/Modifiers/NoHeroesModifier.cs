using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

public class NoHeroesModifier : RogueModifier {
	public override string DisplayName => "No Heroes";
	public override string Description => "";
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {
		model.RemoveMutator<LockTowerSetModModel>("LockHeroes");
		model.AddMutator(new LockTowerSetModModel("LockHeroes", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
	}

	public override void RemoveRogueModifier(ModModel model) { model.RemoveMutator<LockTowerSetModModel>("LockHeroes"); }

	public override void GameStarted(RogueGame rogueGame, InGame game) {
		rogueGame.towerManager.DisableTowerSet(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero);
	}
}
