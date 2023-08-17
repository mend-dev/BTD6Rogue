using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public static readonly ModSettingCategory RoundSettings = new("Round Settings") { collapsed = true };
    public static readonly ModSettingBool RandomRounds = new(true) { category = RoundSettings };
}