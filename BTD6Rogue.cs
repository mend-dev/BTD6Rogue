using MelonLoader;
using BTD_Mod_Helper;
using BTD6Rogue;

[assembly: MelonInfo(typeof(BTD6Rogue.BTD6Rogue), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6Rogue;

// Handles the creation of the RogueGame instance and logging
// Outside of this functionality, BTD6Rogue should not be used to keep code organized
public class BTD6Rogue : BloonsTD6Mod {

	// Static instance of BTD6 Rogue, makes it easy to access lol
	public static BTD6Rogue mod = null!;
	public static FileManager fileManager = new FileManager();
	public static PlayerStats playerStats = fileManager.LoadPlayerStats();

	// Static instance of the current game
	// Should only be assigned when starting/loading a game
	// Unassigned when ending/exiting a game
	public static RogueGame rogueGame = null!;

	public override void OnApplicationStart() {
		mod = this; // Only ever assign the static instance of mod in this function, never change it anywhere else
		LogMessage("Successfully Loaded!", "BTD6Rogue", ErrorLevels.Info); // Inform the user that the mod has successfully loaded
	}

	public override void OnApplicationQuit() {
		fileManager.SavePlayerStats(playerStats);
	}

	// Use this static function instead of ModHelper.Msg to keep the logging consistent
	// Info Logs are informational logs that are meant to be read by the end user but are't disrupting the gameplay or the mod
	// Warning Logs are known issues/causes of issues but won't disrupt gameplay or the mod
	// Error Logs are issues that will disrupt gameplay or the mod
	// Critical Logs are issues that cause crashes, extreme bugs, errors, etc
	// Debug is used in development for testing, they should not be sent in release versions
	public static void LogMessage(object message, object caller = null!, ErrorLevels errorLevel = ErrorLevels.Debug) {
		caller ??= "null";

		if (errorLevel == (ErrorLevels) 0 && RogueModSettings.LogInfoMessages) {
			ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Info) " +  caller + ": " + message);
		} else if (errorLevel == (ErrorLevels) 1 && RogueModSettings.LogWarningMessages) {
			ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Warning) " + caller + ": " + message);
		} else if (errorLevel == (ErrorLevels) 2 && RogueModSettings.LogErrorMessages) {
			ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Error) " + caller + ": " + message);
		} else if (errorLevel == (ErrorLevels) 3 && RogueModSettings.LogCriticalMessages) {
			ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Critical) " + caller + ": " + message);
		} else if (errorLevel == (ErrorLevels) 4 && RogueModSettings.LogDebugMessages) {
			ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Debug) " + caller + ": " + message);
		}
	}
}

// Error levels for logging a message with the static LogMessage function
public enum ErrorLevels : int {
	Info = 0,
	Warning = 1,
	Error = 2,
	Critical = 3,
	Debug = 4,
}
