﻿using BTD_Mod_Helper.Api.Enums;
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

public class SpikeFactoryArtifact : RogueArtifact {
    public override string DisplayName => "Dart Monkey Training";
    public override string ArtifactSprite => VanillaSprites.SpikeFactory000;

    public override ArtifactLength ArtifactLength => ArtifactLength.Both;
    public override ArtifactRange ArtifactRange => ArtifactRange.Both;
    public override Vector2Int ArtifactMinMax => new Vector2Int(5, 10);

    public override void OnChooseArtifact(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("SpikeFactoryArtifact") != null) { tower.RemoveMutatorsById("SpikeFactoryArtifact"); }
            if (tower.towerModel.baseId == TowerType.SpikeFactory) {
                BehaviorMutator bm = new DamageSupport.MutatorTower(1f, false, "SpikeFactoryArtifact", new BuffIndicatorModel("", "", ""));
                tower.AddMutatorIncludeSubTowers(bm, 9999999);
                BehaviorMutator bm2 = new RateSupportModel.RateSupportMutator(false, "SpikeFactoryArtifact", 0.75f, 0, new BuffIndicatorModel("", "", ""));
                tower.AddMutatorIncludeSubTowers(bm2, 9999999);
            }
        }
    }
    public override void OnPlaceTower(InGame game, Tower tower) {
        BehaviorMutator bm = new DamageSupport.MutatorTower(1f, false, "SpikeFactoryArtifact", new BuffIndicatorModel("", "", ""));
        tower.AddMutatorIncludeSubTowers(bm, 9999999);
        BehaviorMutator bm2 = new RateSupportModel.RateSupportMutator(false, "SpikeFactoryArtifact", 0.75f, 0, new BuffIndicatorModel("", "", ""));
        tower.AddMutatorIncludeSubTowers(bm2, 9999999);
    }

    public override void OnArtifactExpire(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("SpikeFactoryArtifact") != null) { tower.RemoveMutatorsById("SpikeFactoryArtifact"); }
        }
    }

    public override bool CanGetArtifact(InGame game) {
        foreach (Tower tower in game.GetTowers()) {
            if (tower.GetMutator("SpikeFactoryArtifact") != null) { return false; }
            if (tower.towerModel.baseId == TowerType.SpikeFactory) { return true; }
        }
        return false;
    }
}