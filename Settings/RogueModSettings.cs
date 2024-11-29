using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;

namespace BTD6Rogue;

public class RogueModSettings : ModSettings {

	public static readonly ModSettingCategory LoggingSettings = new("Logging Settings");

	public static readonly ModSettingBool LogInfoMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogWarningMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogErrorMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogCriticalMessages = new(true) { category = LoggingSettings };
	public static readonly ModSettingBool LogDebugMessages = new(false) { category = LoggingSettings };


    private static readonly ModSettingButton BloonValidationButton = new()
    {
        displayName = "Validate All RogueBloons",
        description =
            "Validates each RogueBloon to ensure it references existing Bloons in the GameModel. Logs warnings if invalid references are found. This is unnecessary if no new RogueBloons are being added by external mods.",
        action = () =>
        {
            BloonValidation v = new();
            v.ValidateAllRogueBloons();
            PopupScreen.instance.SafelyQueue(screen =>
            screen.ShowOkPopup($"Finished validating RogueBloons. Check the logs."));
        },
        buttonText = "Validate",
        category = "Modding"
    };
}
