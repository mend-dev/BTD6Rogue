using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
    public static readonly ModSettingCategory HeroSettings = new("Hero Settings") { collapsed = true };
    public static readonly ModSettingBool MultipleHeroes = new(true) { category = HeroSettings };
    //public static readonly ModSettingBool HeroXpSplit = new(true) { category = HeroSettings };
    //public static readonly ModSettingBool DuplicateHeroes = new(false) { category = HeroSettings };
    //public static readonly ModSettingInt BaseStartingHeroes = new(1) { category = HeroSettings };
    public static readonly ModSettingInt HeroesStartAtRound = new(40) { category = HeroSettings };
    public static readonly ModSettingInt RoundsPerRandomHero = new(40) { category = HeroSettings };
}