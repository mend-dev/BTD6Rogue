using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;

namespace BTD6Rogue;

public class BoomerangMonkeyArtifact : RogueArtifact {
    public override string DisplayName => "Boomerang Monkey Training";
    public override string ArtifactSprite => VanillaSprites.BoomerangMonkey000;

    public override ArtifactLength ArtifactLength => ArtifactLength.Both;
    public override ArtifactRange ArtifactRange => ArtifactRange.Both;
    public override Vector2Int ArtifactMinMax => new Vector2Int(5, 10);

    public override void OnChooseArtifact(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("BoomerangMonkeyArtifact") != null) { tower.RemoveMutatorsById("BoomerangMonkeyArtifact"); }
            if (tower.towerModel.baseId == TowerType.BoomerangMonkey) {
                BehaviorMutator bm = new DamageSupport.MutatorTower(1f, false, "BoomerangMonkeyArtifact", new BuffIndicatorModel("", "", ""));
                tower.AddMutatorIncludeSubTowers(bm, 9999999);
                BehaviorMutator bm2 = new RateSupportModel.RateSupportMutator(false, "BoomerangMonkeyArtifact", 0.75f, 0, new BuffIndicatorModel("", "", ""));
                tower.AddMutatorIncludeSubTowers(bm2, 9999999);
            }
        }
    }
    public override void OnPlaceTower(InGame game, Tower tower) {
        BehaviorMutator bm = new DamageSupport.MutatorTower(1f, false, "BoomerangMonkeyArtifact", new BuffIndicatorModel("", "", ""));
        tower.AddMutatorIncludeSubTowers(bm, 9999999);
        BehaviorMutator bm2 = new RateSupportModel.RateSupportMutator(false, "BoomerangMonkeyArtifact", 0.75f, 0, new BuffIndicatorModel("", "", ""));
        tower.AddMutatorIncludeSubTowers(bm2, 9999999);
    }

    public override void OnArtifactExpire(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("BoomerangMonkeyArtifact") != null) { tower.RemoveMutatorsById("BoomerangMonkeyArtifact"); }
        }
    }

    public override bool CanGetArtifact(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("BoomerangMonkeyArtifact") != null) { return false; }
            if (tower.towerModel.baseId == TowerType.BoomerangMonkey) { return true; }
        }
        return false;
    }
}