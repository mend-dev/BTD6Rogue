using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;

namespace BTD6Rogue;

public abstract class RogueParagon : NamedModContent {

    public abstract string BaseTowerId { get; }

    public TowerModel GetParagonTowerModel() {
        TowerModel paragon = Game.instance.model.GetParagonTower(BaseTowerId);
        return paragon;
    }
}

public class ParagonGameData {

}
