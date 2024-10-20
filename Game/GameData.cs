using System;
using System.Collections.Generic;

namespace BTD6Rogue;

// Stores relevant data for saving and loading an active run
// In addition to saving data for the Game History
public class GameData {
	public GameState gameState = GameState.Created;

	public string gameId = Guid.NewGuid().ToString();

	public string gamemode = "";
	public string map = "";
	public string difficulty = "";
	public string[] modifiers = [];

	public int round = 0;
	public double cash = 0;
	public float lives = 0;
	public int rerolls = 0;

	public string[] bossBag = [];
	public string nextBoss = "";

	public Dictionary<string, TowerData> towers = new Dictionary<string, TowerData>();
	public Dictionary<string, HeroData> heroes = new Dictionary<string, HeroData>();
	public Dictionary<string, ParagonData> paragons = new Dictionary<string, ParagonData>();
}

public enum GameState {
	Created, // The game save was just created and the player is loading into the game
	Loaded, // The game save is actively loaded and being played
	Saved, // The game save is unloaded and not being played
	Lost, // The game is finished and the player lost
	Won, // The game is finished and the player won
}
