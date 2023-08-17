using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using System;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD6Rogue;

public static class ArtifactUtil {

    public static RogueArtifact[] GetThreeArtifacts() {
        List<RogueArtifact> artifacts = new List<RogueArtifact>();

        for (int i = 0; i < 3; i++) {
            artifacts.Add(GetRandomArtifact());
        }

        return artifacts.ToArray();
    }

    public static RogueArtifact GetRandomArtifact() {
        List<RogueArtifact> artifacts = ModContent.GetContent<RogueArtifact>();
        Random random = new Random();
        int artifactId = random.Next(artifacts.Count);

        while (!artifacts[artifactId].CanGetArtifact(InGame.instance)) {
            artifactId = random.Next(artifacts.Count);
        }

        return artifacts[artifactId];
    }
}
