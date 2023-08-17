using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;

namespace BTD6Rogue;

public abstract class RogueArtifact : NamedModContent {

    public override string DisplayName => "Unnamed Artifact";
    public virtual string ArtifactSprite => "";

    public virtual ArtifactLength ArtifactLength => ArtifactLength.Both;
    public virtual ArtifactRange ArtifactRange => ArtifactRange.Both;
    public virtual Vector2Int ArtifactMinMax => new Vector2Int(5, 10);

    public virtual void OnChooseArtifact(InGame game) { }
    public virtual void OnPlaceTower(InGame game, Tower tower) { }
    public virtual void OnRoundStart(InGame game) { }
    public virtual void OnRoundEnd(InGame game) { }
    public virtual void OnArtifactExpire(InGame game) { }
    public virtual bool CanGetArtifact(InGame game) { return true; }

    public override void Register() {}
}

public enum ArtifactLength {
    Once,
    Temp,
    Perm,
    Both
}

public enum ArtifactRange {
    Local,
    Global,
    Both
}

public class ArtifactGameData {
    public RogueArtifact baseArtifact;
    public ArtifactLength artifactLength;
    public ArtifactRange artifactRange;
    public int timer;

    public ArtifactGameData(RogueArtifact baseArtifact) {
        this.baseArtifact = baseArtifact;

        if (baseArtifact.ArtifactLength == ArtifactLength.Both) {
            if (new System.Random().Next(2) == 0) {
                artifactLength = ArtifactLength.Temp;
            } else {
                artifactLength = ArtifactLength.Perm;
            }
        } else {
            artifactLength = baseArtifact.ArtifactLength;
        }

        if (artifactLength == ArtifactLength.Temp) {
            if (baseArtifact.ArtifactMinMax.x == 0 && baseArtifact.ArtifactMinMax.y == 0) {
                timer = new System.Random().Next(5, 16);
            } else {
                timer = new System.Random().Next(baseArtifact.ArtifactMinMax.x, baseArtifact.ArtifactMinMax.y);
            }
        } else {
            timer = -1;
        }

        if (baseArtifact.ArtifactRange == ArtifactRange.Both) {
            if (new System.Random().Next(2) == 0) {
                artifactRange = ArtifactRange.Local;
            } else {
                artifactRange = ArtifactRange.Global;
            }
        } else {
            artifactLength = baseArtifact.ArtifactLength;
        }
    }
}
