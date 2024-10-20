using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD6Rogue;

public class RogueModSettings : ModSettings {

	public static readonly ModSettingCategory LoggingSettings = new("Logging Settings");

	public static readonly ModSettingBool LogInfoMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogWarningMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogErrorMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogCriticalMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogDebugMessages = new(false) { category = LoggingSettings };
}
