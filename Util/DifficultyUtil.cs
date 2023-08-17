using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using System.Linq;

namespace BTD6Rogue;

public static class DifficultyUtil {

    public static RogueDifficulty GetDifficulty(string difficultyName) {
        List<RogueDifficulty> difficulties = ModContent.GetContent<RogueDifficulty>();

        foreach (RogueDifficulty difficulty in difficulties) {
            if (difficultyName == difficulty.DisplayName) {
                return difficulty;
            }
        }
        return null;
    }

    public static RogueDifficulty[] GetAllDifficultues() {
        List<RogueDifficulty> difficulties = ModContent.GetContent<RogueDifficulty>();
        List<RogueDifficulty> newDifficulties = new List<RogueDifficulty>();

        foreach (RogueDifficulty difficulty in difficulties) { if (difficulty.Name.Contains("Poppable")) { newDifficulties.Add(difficulty); } }
        foreach (RogueDifficulty difficulty in difficulties) { if (difficulty.Name.Contains("Easy")) { newDifficulties.Add(difficulty); } }
        foreach (RogueDifficulty difficulty in difficulties) { if (difficulty.Name.Contains("Medium")) { newDifficulties.Add(difficulty); } }
        foreach (RogueDifficulty difficulty in difficulties) { if (difficulty.Name.Contains("Hard")) { newDifficulties.Add(difficulty); } }
        foreach (RogueDifficulty difficulty in difficulties) { if (difficulty.Name.Contains("Impoppable")) { newDifficulties.Add(difficulty); } }


        return newDifficulties.ToArray();
    }

    public static int GetStartingTowerCount(string mapDifficulty, string gameDifficulty) {
        int startingTowers = BTD6Rogue.BaseStartingTowers;

        if (mapDifficulty == "Beginner") {
            startingTowers += BTD6Rogue.AdditionalBeginnerMapStartingTowers;
        } else if (mapDifficulty == "Intermediate") {
            startingTowers += BTD6Rogue.AdditionalIntermediateMapStartingTowers;
        } else if (mapDifficulty == "Advanced") {
            startingTowers += BTD6Rogue.AdditionalAdvancedMapStartingTowers;
        } else if (mapDifficulty == "Expert") {
            startingTowers += BTD6Rogue.AdditionalExpertMapStartingTowers;
        }

        if (gameDifficulty == "Poppable") {
            startingTowers += BTD6Rogue.AdditionalPoppableStartingTowers;
        } else if (gameDifficulty == "Easy") {
            startingTowers += BTD6Rogue.AdditionalEasyStartingTowers;
        } else if (gameDifficulty == "Medium") {
            startingTowers += BTD6Rogue.AdditionalMediumStartingTowers;
        } else if (gameDifficulty == "Hard") {
            startingTowers += BTD6Rogue.AdditionalHardStartingTowers;
        } else if (gameDifficulty == "Impoppable") {
            startingTowers += BTD6Rogue.AdditionalImpoppableStartingTowers;
        }

        return startingTowers;
    }
}
