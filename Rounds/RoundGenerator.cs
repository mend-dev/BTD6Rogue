using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

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
            BTD6Rogue.mod.currentGame.canGainMoney = false;
            Thread t = new Thread(new ThreadStart(SpawnBloons));
            t.Start();
        }
    }

    public void SpawnBloons() {
        string[] possibleBloons = DifficultyUtil.GetDifficulty(BTD6Rogue.mod.currentGame.difficulty).GetViableBloonIds(InGame.instance.bridge.GetCurrentRound() + 1).ToArray();
        string bloonId = possibleBloons[new Random().Next(possibleBloons.Length)];
        if (bloonId.ToLower().Contains("moab") || bloonId.ToLower().Contains("bfb") || bloonId.ToLower().Contains("zomg") || bloonId.ToLower().Contains("ddt") || bloonId.ToLower().Contains("bad")) {
            if (!bloonId.ToLower().Contains("bad")) {
                InGame.instance.SpawnBloons(bloonId, 1, 16);
            }
        } else {
            InGame.instance.SpawnBloons(bloonId, 10, 16);
        }

        //if (InGame.instance == null) { return; }
        //if (InGame.instance.bridge == null) { return; }
        //if (InGame.instance.bridge.GetCurrentRound() == null) { return; }

        Thread.Sleep(4000);
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
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.currentGame.difficulty + bossId + "1", 1, 0, 0);
            } else if (round + 1 == 40) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.currentGame.difficulty + bossId + "2", 1, 0, 0);
            } else if (round + 1 == 60) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.currentGame.difficulty + bossId + "3", 1, 0, 0);
            } else if (round + 1 == 80) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.currentGame.difficulty + bossId + "4", 1, 0, 0);
            } else if (round + 1 == 100) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.currentGame.difficulty + bossId + "5", 1, 0, 0);
            } else if (round + 1 == 120) {
                roundModel.AddBloonGroup("BTD6Rogue-" + BTD6Rogue.mod.currentGame.difficulty + bossId + "6", 1, 0, 0);
            }
        }

        for (int i = 0; i < bloonGroups; i++) {
            int nextIncrease = mincrease + (new Random().Next(randMincrease) + 200);

            string difficultyName = BTD6Rogue.mod.currentGame.difficulty;
            RogueDifficulty currentDifficulty = DifficultyUtil.GetDifficulty(difficultyName);
            List<string> bloonIds = currentDifficulty.GetViableBloonIds(round);
            string[] possibleBloons = bloonIds.ToArray();
            string bloonId = possibleBloons[new Random(Guid.NewGuid().GetHashCode()).Next(possibleBloons.Length)];

            if (bloonId.ToLower().Contains("moab") || bloonId.ToLower().Contains("bfb") ||
                bloonId.ToLower().Contains("zomg") || bloonId.ToLower().Contains("ddt") ||
                bloonId.ToLower().Contains("bad")) {

                if (bloonId.ToLower().Contains("moab")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 20) + 1, mincrease, nextIncrease);
                } else if (bloonId.ToLower().Contains("bfb")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 40) + 1, mincrease, nextIncrease);
                } else if (bloonId.ToLower().Contains("zomg")) {
                    roundModel.AddBloonGroup(bloonId, new Random().Next(round / 80) + 1, mincrease, nextIncrease);
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
}