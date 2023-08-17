using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;

namespace BTD6Rogue;

public class BlackBloonPoppingArtifact : RogueArtifact {
    public override string DisplayName => "Black Bloon Popping";
    public override string ArtifactSprite => VanillaSprites.BlackBloonIcon;

    public override ArtifactLength ArtifactLength => ArtifactLength.Both;
    public override ArtifactRange ArtifactRange => ArtifactRange.Both;
    public override Vector2Int ArtifactMinMax => new Vector2Int(10, 30);

    public override void Register() { }

    public override void OnChooseArtifact(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("BlackBloonPoppingArtifact") != null) { tower.RemoveMutatorsById("BlackBloonPoppingArtifact"); }
            BehaviorMutator bm = new DamageTypeSupport.MutatorTower("BlackBloonPoppingArtifact", false, new BuffIndicatorModel("", "", ""), Il2Cpp.BloonProperties.Black);
            tower.AddMutatorIncludeSubTowers(bm, 9999999);
        }
    }

    public override void OnPlaceTower(InGame game, Tower tower) {
        if (tower.GetMutator("BlackBloonPoppingArtifact") != null) { tower.RemoveMutatorsById("BlackBloonPoppingArtifact"); }
        BehaviorMutator bm = new DamageTypeSupport.MutatorTower("BlackBloonPoppingArtifact", false, new BuffIndicatorModel("", "", ""), Il2Cpp.BloonProperties.Black);
        tower.AddMutatorIncludeSubTowers(bm, 9999999);
    }

    public override void OnArtifactExpire(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("BlackBloonPoppingArtifact") != null) { tower.RemoveMutatorsById("BlackBloonPoppingArtifact"); }
        }
    }
}
