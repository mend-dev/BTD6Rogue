using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models;

namespace BTD6Rogue;

public class Roguemode : ModGameMode {
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.Medium;

    public override string DisplayName => "BTD6 Rogue";

    public override string Icon => VanillaSprites.BossEliteT5Icon;

    public override void ModifyBaseGameModeModel(ModModel gameModeModel) {
    }
}