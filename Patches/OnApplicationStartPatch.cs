using BTD_Mod_Helper;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public static BTD6Rogue mod = null!;

    public override void OnApplicationStart() {
        mod = this;
        LogMessage("Loaded", 0);
    }

    public static void LogMessage(object message, int errorLevel = 1) {
        if (errorLevel == 0 && LogInfoMessages) {
            ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Info): " + message);
        } else if (errorLevel == 1 && LogDebugMessages) {
            ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Debug): " + message);
        } else if (errorLevel == 2 && LogWarningMessages) {
            ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Warning): " + message);
        } else if (errorLevel == 3 && LogErrorMessages) {
            ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Error): " + message);
        } else if (errorLevel == 4 && LogCriticalMessages) {
            ModHelper.Msg<BTD6Rogue>("[BTD6Rogue-v" + ModHelperData.Version + "] (Critical): " + message);
        }
    }
}

public enum ErrorLevels {
    Info = 0,
    Debug = 1,
    Warning = 2,
    Error = 3,
    Critical = 4,
}
