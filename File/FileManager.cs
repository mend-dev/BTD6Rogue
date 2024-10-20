using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace BTD6Rogue;

// can probably change this to be better lmao
// will do later :D
public class FileManager {
	public static string sandboxRoot => Application.persistentDataPath + "/";

	public static readonly JsonSerializerSettings settings = new() {
		Formatting = Formatting.Indented,
		TypeNameHandling = TypeNameHandling.Objects,
	};

	public List<GameData> LoadGameHistory() {
		List<GameData> gameHistory = new List<GameData>();
		string historyPath = sandboxRoot + "BTD6Rogue/history";
		Directory.CreateDirectory(historyPath);
		IEnumerable<FileInfo> files = new DirectoryInfo(historyPath).GetFiles().OrderBy(f => f.CreationTime).TakeLast(10);
		foreach (FileInfo fileInfo in files) {
			string file = FileIOHelper.LoadFile(fileInfo.FullName);
			if (file == null) { continue; }
			GameData gameData = JsonConvert.DeserializeObject<GameData>(file, settings)!;
			if (gameData == null) { continue; }
			gameHistory.Insert(0, gameData);
		}
		return gameHistory;
	}

	public GameData CreateGameData() {
		GameData gameData = new GameData();
		SaveGameData(gameData);
		return gameData;
	}

	public GameData SaveGameData(GameData gameData) {
		string file = JsonConvert.SerializeObject(gameData, settings);
		FileIOHelper.SaveFile("BTD6Rogue/gamedata.txt", file);
		return gameData;
	}

	public GameData LoadGameData() {
		string file = FileIOHelper.LoadFile("BTD6Rogue/gamedata.txt");
		if (file == null) { return CreateGameData(); }
		GameData gameData = JsonConvert.DeserializeObject<GameData>(file, settings)!;
		if (gameData == null) { return null!; }
		return gameData;
	}

	public GameData ArchiveGameData(GameData gameData) {
		string file = JsonConvert.SerializeObject(gameData, settings);
		FileIOHelper.SaveFile("BTD6Rogue/history/" + gameData.gameId + ".txt", file);
		return gameData;
	}

	public void DeleteGameData() {
		string path = Path.Combine(sandboxRoot, "BTD6Rogue/gamedata.txt");
		File.Delete(path);
	}

	public static bool HasSavedGameData() {
		return FileIOHelper.LoadFile("BTD6Rogue/gamedata.txt") != null;
	}

	public PlayerStats CreatePlayerStats() {
		PlayerStats playerStats = new PlayerStats();
		SavePlayerStats(playerStats);
		return playerStats;
	}

	public PlayerStats SavePlayerStats(PlayerStats stats) {
		string file = JsonConvert.SerializeObject(stats, settings);
		FileIOHelper.SaveFile("BTD6Rogue/stats.txt", file);
		return stats;
	}

	public PlayerStats LoadPlayerStats() {
		string file = FileIOHelper.LoadFile("BTD6Rogue/stats.txt");
		if (file == null) { return CreatePlayerStats(); }
		PlayerStats playerStats = JsonConvert.DeserializeObject<PlayerStats>(file, settings)!;
		if (playerStats == null) { return null!; }
		return playerStats;
	}
}
