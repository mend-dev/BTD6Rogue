using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public static readonly ModSettingCategory BossSettings = new("Boss Settings") { collapsed = true };
    //public static readonly ModSettingBool Bosses = new(true) { category = BossSettings };
    //public static readonly ModSettingInt BossesStartAtRound = new(20) { category = BossSettings };
    //public static readonly ModSettingInt RoundsPerBoss = new(20) { category = BossSettings };
    //public static readonly ModSettingInt BossesPerBoss = new(1) { category = BossSettings };
    public static readonly ModSettingEnum<BossRandomizationType> BossRandomization = new(BossRandomizationType.RandomAndRemove);
    //public static readonly ModSettingBool ModBosses = new(false) { category = BossSettings };
}

public enum BossRandomizationType {
    RandomAndRemove,
    Random
}
