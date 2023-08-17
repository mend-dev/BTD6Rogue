using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;

namespace BTD6Rogue;

public abstract class RogueHero : NamedModContent {
    public abstract string BaseHeroId { get; }

    public TowerModel GetBaseTower() {
        return Game.instance.model.GetTower(BaseHeroId);
    }
}

public class HeroGameData {

    public bool SelectedHero = false;
}
