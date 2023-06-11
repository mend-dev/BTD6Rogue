using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Rounds;
using System;
using System.Collections.Generic;

namespace BTD6Rogue;

public class RoundGenerator {

    public int randMincrease = 400;
    public int minIncrease = 600;
    public int randEndTime = 450;
    public int minEndTime = 150;

    public RoundModel GetRandomRoundModel(RoundModel baseRoundModel, int round) {
        RoundModel roundModel = baseRoundModel;
        roundModel.ClearBloonGroups();

        int bloonGroups = new Random().Next(4) + 3;
        int mincrease = 0;

        for (int i = 0; i < bloonGroups; i++) {
            int nextIncrease = mincrease + (new Random().Next(randMincrease) + 200);

            string[] possibleBloons = GetValidBloons(round);
            string bloonId = possibleBloons[new Random().Next(possibleBloons.Length)];
            if (bloonId.ToLower().Contains("moab") || bloonId.ToLower().Contains("bfb") ||
                bloonId.ToLower().Contains("zomg") || bloonId.ToLower().Contains("ddt") ||
                bloonId.ToLower().Contains("bad")) {
                roundModel.AddBloonGroup(bloonId, new Random().Next(round / 20) + 1, mincrease, nextIncrease);
            } else {
                roundModel.AddBloonGroup(bloonId, new Random().Next(20) + 10, mincrease, nextIncrease);
            }
            mincrease = nextIncrease;
        }

        return roundModel;
    }

    public string[] GetValidBloons(int round) {
        round++;
        List<string> bloonStrings = new List<string>();

        if (round >= 1 && round <= 8) {
            bloonStrings.Add(BloonType.Red);
            if (round >= 8) { bloonStrings.Add(BloonType.RedCamo); }
            if (round >= 6) { bloonStrings.Add(BloonType.RedRegrow); }
        }
        if (round >= 2 && round <= 12) {
            bloonStrings.Add(BloonType.Blue);
            if (round >= 11) { bloonStrings.Add(BloonType.BlueCamo); }
            if (round >= 9) { bloonStrings.Add(BloonType.BlueRegrow); }
        }
        if (round >= 4 && round <= 18) {
            bloonStrings.Add(BloonType.Green);
            if (round >= 13) { bloonStrings.Add(BloonType.GreenCamo); }
            if (round >= 11) { bloonStrings.Add(BloonType.GreenRegrow); }
        }
        if (round >= 6 && round <= 22) {
            bloonStrings.Add(BloonType.Yellow);
            if (round >= 15) { bloonStrings.Add(BloonType.YellowCamo); }
            if (round >= 13) { bloonStrings.Add(BloonType.YellowRegrow); }
        }
        if (round >= 8 && round <= 27) {
            bloonStrings.Add(BloonType.Pink);
            if (round >= 16) { bloonStrings.Add(BloonType.PinkCamo); }
            if (round >= 14) { bloonStrings.Add(BloonType.PinkRegrow); }
        }
        if (round >= 11 && round <= 32) {
            bloonStrings.Add(BloonType.Black);
            if (round >= 19) { bloonStrings.Add(BloonType.BlackCamo); }
            if (round >= 17) { bloonStrings.Add(BloonType.BlackRegrow); }
        }
        if (round >= 14 && round <= 33) {
            bloonStrings.Add(BloonType.White);
            if (round >= 20) { bloonStrings.Add(BloonType.WhiteCamo); }
            if (round >= 18) { bloonStrings.Add(BloonType.WhiteRegrow); }
        }
        if (round >= 18) {
            bloonStrings.Add(BloonType.Lead);
            if (round >= 38) { bloonStrings.Add(BloonType.LeadCamo); }
            if (round >= 28) { bloonStrings.Add(BloonType.LeadRegrow); }
            if (round >= 44) { bloonStrings.Add(BloonType.LeadFortified); }
        }
        if (round >= 22) {
            bloonStrings.Add(BloonType.Zebra);
            if (round >= 29) { bloonStrings.Add(BloonType.ZebraCamo); }
            if (round >= 26) { bloonStrings.Add(BloonType.ZebraRegrow); }
        }
        if (round >= 25) {
            bloonStrings.Add(BloonType.Purple);
            if (round >= 37) { bloonStrings.Add(BloonType.PurpleCamo); }
            if (round >= 33) { bloonStrings.Add(BloonType.PurpleRegrow); }
        }
        if (round >= 28) {
            bloonStrings.Add(BloonType.Rainbow);
            if (round >= 44) { bloonStrings.Add(BloonType.RainbowCamo); }
            if (round >= 41) { bloonStrings.Add(BloonType.RainbowRegrow); }
        }
        if (round >= 32) {
            bloonStrings.Add(BloonType.Ceramic);
            if (round >= 48) { bloonStrings.Add(BloonType.CeramicCamo); }
            if (round >= 46) { bloonStrings.Add(BloonType.CeramicRegrow); }
            if (round >= 52) { bloonStrings.Add(BloonType.CeramicFortified); }
        }
        if (round >= 40) {
            bloonStrings.Add(BloonType.Moab);
            if (round >= 45) { bloonStrings.Add(BloonType.MoabFortified); }
        }
        if (round >= 55) {
            bloonStrings.Add(BloonType.Bfb);
            if (round >= 60) { bloonStrings.Add(BloonType.BfbFortified); }
        }
        if (round >= 70) {
            bloonStrings.Add(BloonType.Zomg);
            if (round >= 75) { bloonStrings.Add(BloonType.ZomgFortified); }
        }
        if (round >= 85) {
            bloonStrings.Add(BloonType.DdtCamo);
            if (round >= 90) { bloonStrings.Add(BloonType.DdtFortifiedCamo); }
        }
        if (round >= 100) {
            bloonStrings.Add(BloonType.Bad);
            if (round >= 105) { bloonStrings.Add(BloonType.BadFortified); }
        }

        return bloonStrings.ToArray();
    }
}