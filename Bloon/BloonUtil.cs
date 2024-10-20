using BTD_Mod_Helper.Api;

namespace BTD6Rogue;

public static class BloonUtil {

    public static RogueBloon[] GetAllBloons() {
        return ModContent.GetContent<RogueBloon>().ToArray();
    }
}