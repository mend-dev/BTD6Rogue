using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {

    public void StartRogueGame(InGame game) {
        if (game.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; } // Check if user is in the right gamemode
        currentGame = new RogueGame();

        currentGame.difficulty = gameSettingsUi.selectedDifficulty;
        currentGame.availableTowerSets = availableTowerSets;
        currentGame.availableBosses = availableBosses;
        currentGame.bossBag = availableBosses;

        currentGame.continues = gameSettingsUi.gameModifiers.Contains("Continues");
        currentGame.lives = gameSettingsUi.gameModifiers.Contains("Lives");
        currentGame.income = gameSettingsUi.gameModifiers.Contains("Income");
        currentGame.monkeyKnowledge = gameSettingsUi.gameModifiers.Contains("Monkey Knowledge");
        currentGame.powers = gameSettingsUi.gameModifiers.Contains("Powers");
        currentGame.selling = gameSettingsUi.gameModifiers.Contains("Selling");
        currentGame.alternateRounds = gameSettingsUi.gameModifiers.Contains("Alternate Rounds");


        foreach (string towerSet in availableTowerSets) {
            LogMessage("TowerSet: " + towerSet);
        }



        // Get the Tower Inventory
        TowerInventory towerInventory = game.GetTowerInventory();
        Il2CppSystem.Collections.Generic.Dictionary<string, int> towerMaxes = towerInventory.GetTowerInventoryMaxes();

        // Set up Tower Data
        // Set up Hero Data
        // Set up Paragon Data
        // Set up Boss Data
        // Set up Bloon Data
        // Set up Artifact Data
        // Set up Modifier Data

        // Set up Tower Data
        foreach (RogueTower rogueTower in TowerUtil.GetAllTowers()) {
            TowerModel towerModel = rogueTower.GetBaseTower();
            string baseId = rogueTower.BaseTower;

            if (towerMaxes.ContainsKey(baseId)) {
                towerMaxes[baseId] = 0;
            } else {
                towerMaxes.Add(baseId, 0);
            }

            if (!availableTowerSets.Contains(towerModel.GetTowerSet())) { continue; }

            if (currentGame.towerData.ContainsKey(baseId)) {
                currentGame.towerData[baseId] = new TowerGameData();
            } else {
                currentGame.towerData.Add(baseId, new TowerGameData());
            }

            currentGame.towerData[baseId].baseTowerModel = towerModel;
            currentGame.towerData[baseId].baseRogueTower = rogueTower;
            currentGame.towerData[baseId].baseId = baseId;

            for (int i = 0; i < 3; i++) {
                for (int j = 1; j < 6; j++) {
                    if (towerModel.GetUpgrade(i, j) != null) {
                        currentGame.towerData[baseId].noPaths = false;
                        currentGame.towerData[baseId].hasPaths[i] = true;
                        currentGame.towerData[baseId].maxPaths[i] = j;
                    }
                }
            }
        }

        foreach (RogueHero rogueHero in HeroUtil.GetAllHeroes()) {
            TowerModel towerModel = rogueHero.GetBaseTower();
            string baseId = rogueHero.BaseHeroId;

            if (towerMaxes.ContainsKey(baseId)) {
                towerMaxes[baseId] = 0;
            } else {
                towerMaxes.Add(baseId, 0);
            }

            if (currentGame.heroData.ContainsKey(baseId)) {
                currentGame.heroData[baseId] = new HeroGameData();
            } else {
                currentGame.heroData.Add(baseId, new HeroGameData());
            }
        }

        foreach (RogueParagon rogueParaon in ParagonUtil.GetAllParagons()) { }


        towerInventory.towerMaxes = towerMaxes;
        game.bridge.OnTowerInventoryChangedSim(true);

        game.bridge.SetEndRound(119);
        game.bridge.SetRound(0);

        if (RandomRounds) {
            InGame.instance.GetGameModel().roundSet.rounds[0] = currentGame.roundGenerator.GetRandomRoundModel(InGame.instance.GetGameModel().roundSet.rounds[0], 0);
        }

        currentGame.panelManager.AddPanelToQueue(game.uiRect, game, nameof(InitialHeroChoicePanel));
        currentGame.panelManager.AddPanelToQueue(game.uiRect, game, nameof(InitialTowerChoicePanel));
    }
}

