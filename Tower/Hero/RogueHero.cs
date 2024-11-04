using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;

namespace BTD6Rogue;

public abstract class RogueHero : NamedModContent {
	public abstract string BaseHeroId { get; }

	public virtual TowerModel GetBaseHero() {
		return Game.instance.model.GetTowerFromId(BaseHeroId);

        //return Game.instance.model.GetHeroWithNameAndLevel(BaseHeroId, 1);
    }

	public override void Register() {}
}
