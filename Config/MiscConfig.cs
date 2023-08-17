using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    //public static readonly ModSettingHotkey FasterForwardHotkey = new(KeyCode.F1);
    public static readonly ModSettingBool DisablePatchesInSandbox = new(true);

    public static readonly ModSettingCategory LoggingSettings = new("Logging Settings") { collapsed = true };
    public static readonly ModSettingBool LogInfoMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogDebugMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogWarningMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogErrorMessages = new(true) { category = LoggingSettings };
    public static readonly ModSettingBool LogCriticalMessages = new(true) { category = LoggingSettings };
}