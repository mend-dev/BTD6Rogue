using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BTD6Rogue;

public class RoundGenerator {

    public int randMincrease = 400;
    public int minIncrease = 600;
    public int randEndTime = 450;
    public int minEndTime = 150;

    public string nextBoss = "";

    public List<string> possibleBosses = new List<string>();

    public void SpawnBloonsDelay() {
        Thread.Sleep(25000);
        if ((InGame.instance.bridge.GetCurrentRound() + 1) % 20 == 0) {
            BTD6Rogue.mod.canGainMoney = false;
            Thread t = new Thread(new ThreadStart(SpawnBloons));
            t.Start();
        }
    }

    public void SpawnBloons() {
        string[] possibleBloons = GetValidBloons(InGame.instance.bridge.GetCurrentRound() + 1);
        string bloonId = possibleBloons[new Random().Next(possibleBloons.Length)];
        if (bloonId.ToLower().Contains("moab") || bloonId.ToLower().Contains("bfb") || bloonId.ToLower().Contains("zomg") || bloonId.ToLower().Contains("ddt") || bloonId.ToLower().Contains("bad")) {
            InGame.instance.SpawnBloons(bloonId, 1, 16);
        } else {
            InGame.instance.SpawnBloons(bloonId, 10, 16);
        }

        Thread.Sleep(2000);
        if ((InGame.instance.bridge.GetCurrentRound() + 1) % 20 == 0) {
            Thread t = new Thread(new ThreadStart(SpawnBloons));
            t.Start();
        }
    }

    public RoundModel GetRandomRoundModel(RoundModel baseRoundModel, int round) {
        RoundModel roundModel = baseRoundModel;
        roundModel.ClearBloonGroups();

        int bloonGroups = new Random().Next(4) + 3;
        int mincrease = 0;

        if ((round + 1) % 20 == 0) {
            string bossId = nextBoss;

            if (round + 1 == 20) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.difficulty.DifficultyName + bossId + "1", 1, 0, 0);
            } else if (round + 1 == 40) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.difficulty.DifficultyName + bossId + "2", 1, 0, 0);
            } else if (round + 1 == 60) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.difficulty.DifficultyName + bossId + "3", 1, 0, 0);
            } else if (round + 1 == 80) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.difficulty.DifficultyName + bossId + "4", 1, 0, 0);
            } else if (round + 1 == 100) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.difficulty.DifficultyName + bossId + "5", 1, 0, 0);
            } else if (round + 1 == 120) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.difficulty.DifficultyName + bossId + "6", 1, 0, 0);
            }
        }

        for (int i = 0; i < bloonGroups; i++) {
            int nextIncrease = mincrease + (new Random().Next(randMincrease) + 200);

            string[] possibleBloons = GetValidBloons(round);
            string bloonId = possibleBloons[new Random().Next(possibleBloons.Length)];

            if (BTD6Rogue.mod.modifiers.ContainsKey("CamoInfestation") && !bloonId.Contains("Camo")) {
                BloonModel bloonModel = Game.instance.model.GetBloon(bloonId);
                bloonId = bloonModel.baseId + "Camo";
            }

            if (bloonId.ToLower().Contains("moab") || bloonId.ToLower().Contains("bfb") ||
                bloonId.ToLower().Contains("zomg") || bloonId.ToLower().Contains("ddt") ||
                bloonId.ToLower().Contains("bad")) {

                if (bloonId.ToLower().Contains("moab")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 5) + 1, mincrease, nextIncrease);
                } else if (bloonId.ToLower().Contains("bfb")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 10) + 1, mincrease, nextIncrease);
                } else if (bloonId.ToLower().Contains("zomg")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 20) + 1, mincrease, nextIncrease);
                } else if (bloonId.ToLower().Contains("ddt")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 10) + 1, mincrease, nextIncrease);
                } else if (bloonId.ToLower().Contains("bad")) {
                    roundModel.AddBloonGroup(bloonId, 1, mincrease, nextIncrease);
                }
            } else {
                roundModel.AddBloonGroup(bloonId, new Random().Next(20) + 10, mincrease, nextIncrease);
            }
            mincrease = nextIncrease;
        }

        return roundModel;
    }

    public string[] GetValidBloons(int round) {
        List<string> bloonStrings = new List<string>();

        RogueDifficulty difficulty = BTD6Rogue.mod.difficulty;

        bloonStrings.AddRange(difficulty.RedBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.BlueBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.GreenBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.YellowBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.PinkBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.BlackBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.WhiteBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.LeadBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.ZebraBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.PurpleBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.RainbowBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.CeramicBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.MoabBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.BfbBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.ZomgBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.DdtBloon.GetViableBloonIds(round));
        bloonStrings.AddRange(difficulty.BadBloon.GetViableBloonIds(round));

        return bloonStrings.ToArray();
    }
}