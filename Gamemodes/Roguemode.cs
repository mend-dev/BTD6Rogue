using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace BTD6Rogue;

public class Roguemode : ModGameMode {
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.Medium;

    public override string DisplayName => "Roguelike";

    public override string Icon => VanillaSprites.BossEliteT5Icon;

    public ModModel baseGameModeModel { get; set; }
    public GameModel baseGameModel { get; set; }

    public override void ModifyBaseGameModeModel(ModModel gameModeModel) {
        baseGameModeModel = gameModeModel;
    }
    public override void ModifyGameModel(GameModel gameModel) { baseGameModel = gameModel; }

    public void SetContinuesEnabled(bool enabled) { baseGameModeModel.SetContinuesEnabled(enabled); }
    public void SetLivesEnabled(bool enabled) {
        if (enabled) {
            baseGameModeModel.SetMaxHealth(100);
            baseGameModeModel.SetStartingHealth(100);
        } else {
            baseGameModeModel.SetMaxHealth(1);
            baseGameModeModel.SetStartingHealth(1);
        }
    }
    public void SetIncomeEnabled(bool enabled) { baseGameModeModel.SetIncomeEnabled(enabled); }
    public void SetMonkeyKnoweldgeEnabled(bool enabled) { baseGameModeModel.SetMkEnabled(enabled); }
    public void SetPowersEnabled(bool enabled) { baseGameModeModel.SetPowersEnabled(enabled); }
    public void SetSellingEnabled(bool enabled) { baseGameModeModel.SetSellingEnabled(enabled); }

    public void ChangeCostModifier(float modifier) {
        if (!baseGameModeModel.HasMutator<GlobalCostModModel>()) {
            baseGameModeModel.AddMutator(new GlobalCostModModel("costMultiplier", 1f, false));
        }
        baseGameModeModel.GetMutator<GlobalCostModModel>().multiplier = modifier;
    }

    public void ChangeTowerSet(bool locked, string towerSet) {
        switch (towerSet) {
            case "Primary":
                baseGameModeModel.LockTowerSet(TowerSet.Primary, locked);
                break;
            case "Military":
                baseGameModeModel.LockTowerSet(TowerSet.Military, locked);
                break;
            case "Magic":
                baseGameModeModel.LockTowerSet(TowerSet.Magic, locked);
                break;
            case "Support":
                baseGameModeModel.LockTowerSet(TowerSet.Support, locked);
                break;
        }
    }
}