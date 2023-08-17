using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Collections.Generic;

namespace BTD6Rogue;

public class BloonRush : RogueArtifact {
    public override string DisplayName => "Bloon Rush";
    public override string ArtifactSprite => VanillaSprites.Rainbow;

    public override ArtifactLength ArtifactLength => ArtifactLength.Once;

    public override ArtifactRange ArtifactRange => ArtifactRange.Local;

    public override void Register() {}

    public override void OnChooseArtifact(InGame game) {
        int round = game.bridge.GetCurrentRound();
        List<BloonEmissionModel> bmes = new List<BloonEmissionModel>();
        for (int i = 0; i < 50; i++) {
            BloonEmissionModel bme = new BloonEmissionModel("", i * 10);
            if (round > 0 && round < 19) {
                bme.bloon = BloonType.PinkRegrow;
            } else if (round > 19 && round < 39) {
                bme.bloon = BloonType.ZebraRegrow;
            } else if (round > 39 && round < 59) {
                bme.bloon = BloonType.RainbowRegrow;
            } else if (round > 59 && round < 79) {
                bme.bloon = BloonType.MoabFortified;
            } else if (round > 79 && round < 99) {
                bme.bloon = BloonType.BfbFortified;
            } else if (round > 99 && round < 119) {
                bme.bloon = BloonType.DdtFortifiedCamo;
            } else if (round > 119) {
                bme.bloon = BloonType.BadFortified;
            }
            bmes.Add(bme);
        }
        game.bridge.SpawnBloons(bmes.ToIl2CppReferenceArray(), 0, 0);
    }
}