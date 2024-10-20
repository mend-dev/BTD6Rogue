using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data.Quests;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.SimulationBehaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.QuestDialogueSystems;
using System.Linq;

namespace BTD6Rogue;

// Class that handles all of the interaction of BTD6 Rogue Mechanics
public class RogueGame {

	public InGame game = null!;

	public RogueGamemode gamemode = null!;
	public RogueMap map = null!;
	public RogueDifficulty difficulty = null!;
	public RogueModifier[] modifiers = null!;

	public EncounterManager encounterManager = null!;
	public PanelManager panelManager = null!;
	public RoundManager roundManager = null!;
	public TowerManager towerManager = null!;

	public int rerolls = 0;

	public GameData gameData = null!;

	public RogueGame(RogueGamemode gamemode, RogueMap map, RogueDifficulty difficulty, RogueModifier[] modifiers) {
		this.gamemode = gamemode;
		this.map = map;
		this.difficulty = difficulty;
		this.modifiers = modifiers;
	}

	public void NewGame() {
		gameData = new GameData();
		gameData.gamemode = gamemode.Id;
		gameData.map = map.Id;
		gameData.difficulty = difficulty.Id;
		gameData.modifiers = ModifierUtil.IdsFromModifiers(modifiers).ToArray();
		StartGame();
	}

	public static void LoadGame() {
		GameData saveData = BTD6Rogue.fileManager.LoadGameData();

		if (saveData == null) { return; }

		RogueGamemode gamemode = GamemodeUtil.GetGamemodeById(saveData.gamemode);
		RogueMap map = MapUtil.GetMapById(saveData.map);
		RogueDifficulty difficulty = DifficultyUtil.GetDifficultyById(saveData.difficulty);
		RogueModifier[] modifiers = ModifierUtil.ModifiersFromIds(saveData.modifiers).ToArray();

		Btd6Player player = Il2CppAssets.Scripts.Unity.Game.Player;

		MapSaveDataModel mapSaveDataModel;
		bool hasSavedMap = player.Data.GetSavedMap(map.InternalName, out mapSaveDataModel);
		if (!hasSavedMap || mapSaveDataModel == null) { return; }

		RogueGame rogueGame = new RogueGame(gamemode, map, difficulty, modifiers);
		rogueGame.gameData = saveData;
		BTD6Rogue.rogueGame = rogueGame;
		rogueGame.StartGame(mapSaveDataModel);
	}

	public void RestartGame() {
		gameData = new GameData();
		gameData.gamemode = gamemode.Id;
		gameData.map = map.Id;
		gameData.difficulty = difficulty.Id;
		gameData.modifiers = ModifierUtil.IdsFromModifiers(modifiers).ToArray();
		GameStarted(game);
	}

	public void SaveGame() {
		gameData.round = game.bridge.GetCurrentRound();
		gameData.cash = game.bridge.GetCash();
		gameData.lives = game.bridge.GetHealth();
		gameData.towers = towerManager.towers;
		gameData.heroes = towerManager.heroes;
		gameData.paragons = towerManager.paragons;
		gameData.rerolls = rerolls;
		gameData.bossBag = roundManager.bossBag.ToArray();
		gameData.modifiers = ModifierUtil.IdsFromModifiers(modifiers).ToArray();
		gameData.nextBoss = roundManager.nextBoss;
		BTD6Rogue.fileManager.SaveGameData(gameData);
	}

	public void EndGame() {
		BTD6Rogue.fileManager.ArchiveGameData(gameData);
		BTD6Rogue.fileManager.DeleteGameData();
	}

	// Call function to load into a game after creating a RogueGame instance
    public void StartGame(MapSaveDataModel mapSaveData = null!) {
		InGameData.Editable.selectedMode = gamemode.Id;
		InGameData.Editable.selectedMap = map.InternalName;
		InGameData.Editable.selectedDifficulty = DifficultyType.Medium;

		ModifierUtil.ResetModModelModifiers(gamemode.gameModeModel);
		foreach (RogueModifier modifier in modifiers) {
			modifier.ApplyRogueModifier(gamemode.gameModeModel);
		}
		gamemode.gameModeModel.AddMutator(new GlobalCostModModel("", difficulty.CostModifier));
		
		UI.instance.LoadGame(mapSaveData: mapSaveData);
	}

	public void GameLoaded(InGame game) {
		if (!GamemodeUtil.IsRogueGamemode(game.GetGameModel().gameMode)) { return; }
		this.game = game;

		encounterManager = new EncounterManager(game);
		panelManager = new PanelManager();
		towerManager = new TowerManager(game);
		roundManager = new RoundManager(game);

		roundManager.bossBag = gameData.bossBag.ToList();
		roundManager.nextBoss = gameData.nextBoss;

		foreach (RogueModifier modifier in modifiers) {
			modifier.GameStarted(this, game);
		}

		if (!map.Water) { towerManager.DisableWaterTowers(); }

		towerManager.ClearTowerInventory();

		towerManager.towers = gameData.towers;
		towerManager.heroes = gameData.heroes;
		towerManager.paragons = gameData.paragons;
		towerManager.UpdateInventory();

		rerolls = gameData.rerolls;

		game.bridge.SetEndRound(119);
	}

	// Automatically called after loading into a game (after StartGame()) was called
	public void GameStarted(InGame game) {
		if (!GamemodeUtil.IsRogueGamemode(game.GetGameModel().gameMode)) { return; }
		this.game = game;


		encounterManager = new EncounterManager(game);
		panelManager = new PanelManager();
		towerManager = new TowerManager(game);
		roundManager = new RoundManager(game);

		foreach (RogueModifier modifier in modifiers) {
			modifier.GameStarted(this, game);
		}

		if (!map.Water) { towerManager.DisableWaterTowers(); }

		towerManager.ClearTowerInventory();
		encounterManager.AddEncounter(ModContent.GetContent<GameStartEncounter>()[0]);

		game.bridge.SetEndRound(119);
		game.bridge.SetRound(0);

		rerolls = 3;
		roundManager.GenerateRound(0, true);
		roundManager.GenerateBossBag();
	}
}
