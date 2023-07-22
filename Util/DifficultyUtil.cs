namespace BTD6Rogue;

public static class DifficultyUtil {


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
