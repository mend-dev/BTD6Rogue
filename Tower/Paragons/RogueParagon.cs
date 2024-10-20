using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;

namespace BTD6Rogue;

// Abstract implementation for paragons to be used within a BTD6Rogue game
// Every paragon needs an equivalent RogueParagon to function properly
public abstract class RogueParagon : NamedModContent {
    public abstract string BaseTowerId { get; } // Id for the Paragon Tower itself

	public TowerModel GetBaseParagon() {
		TowerModel paragon = Game.instance.model.GetParagonTower(BaseTowerId);
		return paragon;
	}

	public TowerModel GetBaseTower() {
		TowerModel tower = Game.instance.model.GetTowerModel(BaseTowerId);
		return tower;
	}

	public override void Register() {}
}
