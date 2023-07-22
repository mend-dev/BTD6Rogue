using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Unity;
using System;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.RoundEnd))]
static class RoundEndPatch {
    [HarmonyPostfix]
    private static void Postfix(InGame __instance, int completedRound, int highestCompletedRound) {
        if (BTD6Rogue.DisablePatchesInSandbox && __instance.bridge.IsSandboxMode()) { return; }

        //__instance.roundHintTxt.text = BTD6Rogue.mod.difficulty.GameHints[completedRound + 1];
        //__instance.CheckAndShowHintMessage();
        //__instance.roundHintTxt.text = BTD6Rogue.mod.difficulty.GameHints[completedRound + 1];

        // Make rounds randomized
        if (BTD6Rogue.RandomRounds) {
            __instance.GetGameModel().roundSet.rounds[completedRound + 1] = BTD6Rogue.mod.roundGenerator.GetRandomRoundModel(__instance.GetGameModel().roundSet.rounds[completedRound + 1], completedRound + 1);
        }

        // Tower choice every 10 rounds (starting at 5)
        if ((completedRound + 1) % BTD6Rogue.RoundsPerRandomTower == BTD6Rogue.TowersStartAtRound && BTD6Rogue.RandomTowers) {
            __instance.bridge.SetAutoPlay(false);
            TowerChoicePanel.Create(__instance.uiRect, __instance);
        }

        // Hero choice every 40 rounds
        if ((completedRound + 1) % 40 == 0) {
            __instance.bridge.SetAutoPlay(false);
            HeroChoicePanel.Create(__instance.uiRect, __instance);
        }

        
        // Artifact choice every 15 rounds
        //if ((completedRound + 1) % 15 == 0) {
        //    __instance.bridge.SetAutoPlay(false);
        //   ArtifactChoicePanel.Create(__instance.uiRect, __instance);
        //}

        /*
        foreach (string key in BTD6Rogue.mod.modifiers.Keys) {
            BTD6Rogue.mod.modifiers[key]--;
            if (BTD6Rogue.mod.modifiers[key] < 1) { BTD6Rogue.mod.modifiers.Remove(key); }
        }

        List<string> modifierList = new List<string>() {
            "ModifierInfestation", "ModifierEradication",
            "CamoInfestation", "RegrowInfestation", "FortifiedInfestation",
            "CamoEradication", "RegrowEradication", "FortifiedEradication",
            "CamoDetectionTech", "RegrowPoppingTech", "FortificationStrippingTech",
            "HiddenCamos", "HiddenRegrows", "HiddenFortifieds",
            "StrongerRegrows", "WeakerRegrows",
            "QuickerAbilities", "SlowerAbilities",
            "MonkeyAnthem", "BloonsAnthem",
            "ReverseRave",
            "RoughWaves", "StormySkies", "Earthquake",
            "CalmWater", "ClearSkies", "QuietLand",
            "WeakerDarts", "StrongerDarts",
            "WeakerRangs", "StrongerRangs",
            "WeakerBombs", "StrongerBombs",
            "WeakerTacks", "StrongerTacks",
            "WeakerIce", "StrongerIce",
            "WeakerGlue", "StrongerGlue",
            "WeakerSnipers", "StrongerSnipers",
            "WeakerSubs", "StrongerSubs",
            "WeakerBuccaneers", "StrongerBuccaneers",
            "WeakerAces", "StrongerAce",
            "WeakerHelis", "StrongerHelis",
            "WeakerMortars", "StrongerMortars",
            "WeakerGunners", "StrongerGunners",
            "WeakerWizards", "StrongerWizards",
            "WeakerSupers", "StrongerSupers",
            "WeakerNinjas", "StrongerNinjas",
            "WeakerAlchemists", "StrongerAlchemists",
            "WeakerDruids", "StrongerDruids",
            "WeakerFarms", "StrongerFarms",
            "WeakerSpikes", "StrongerSpikes",
            "WeakerVillages", "StrongerVillages",
            "WeakerEngineers", "StrongerEngineers",
            "WeakerBeasts", "StrongerBeasts",
            "StrongerBloons", "WeakerBloons",
            "FasterBloons", "SlowerBloons",
            "BloonInfestation", "BloonEradication",
            "HalfCash", "DoubleCash",
            "GoodDeals", "BadDeals",
            "JungleDrums", "JungleSabotage",
            "PrimaryAnthem", "PrimarySabotage",
            "MilitaryAnthem", "MilitarySabotage",
            "MagicAnthem", "MagicSabotage",
            "SupportAnthem", "SupportSabotage",
            "HeroAnthem", "HeroSabotage",
        };

        // Random modifier every 10 rounds
        if ((completedRound + 1) % 10 == 0) {
            string modifier = modifierList[new Random().Next(modifierList.Count)];
            int rounds = new Random().Next(10) + 1;
            BTD6Rogue.mod.modifiers[modifier] = rounds;
            Game.instance.ShowMessage("New modifier: " + modifier + "! (" + rounds + " rounds remaining)", 20f);
        }*/
    }
}