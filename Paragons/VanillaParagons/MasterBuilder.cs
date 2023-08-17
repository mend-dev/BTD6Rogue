using Il2CppAssets.Scripts.Models.Towers;

namespace BTD6Rogue;

public class MasterBuilder : RogueParagon {

    public override string DisplayName => "Master Builder";

    public override string BaseTowerId => TowerType.EngineerMonkey;

    public override void Register() { }
}
