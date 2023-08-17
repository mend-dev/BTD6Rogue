using BTD_Mod_Helper.Api;
using System.Collections.Generic;

namespace BTD6Rogue;

public abstract class RogueDifficulty : NamedModContent {

    public virtual Dictionary<int, string> GameHintOverrides => new Dictionary<int, string>();
    public virtual float CostModifier => 1.0f;
    public abstract int BloonSendOffset { get; }
    public virtual Dictionary<string, int> BloonSendOffsets => new Dictionary<string, int>();

    public List<string> GetViableBloonIds(int round) {
        List<string> bloonIds = new List<string>();
        round++;

        RogueBloon[] allBloons = BloonUtil.GetAllBloons();

        foreach (RogueBloon bloon in allBloons) {
            if (round >= bloon.MinRound + BloonSendOffset && (round <= bloon.MaxRound + BloonSendOffset || bloon.MaxRound == -1)) {
                bloonIds.Add(bloon.BaseBloonId);
            }

            if (bloon.Regrow && round >= bloon.RegrowMinRound + BloonSendOffset && (round <= bloon.RegrowMaxRound + BloonSendOffset || bloon.MaxRound == -1)) {
                bloonIds.Add(bloon.BaseBloonId + "Regrow");
            }

            if (bloon.Camo && round >= bloon.CamoMinRound + BloonSendOffset && (round <= bloon.CamoMaxRound + BloonSendOffset || bloon.MaxRound == -1)) {
                bloonIds.Add(bloon.BaseBloonId + "Camo");
            }

            if (bloon.Fortified && round >= bloon.FortifiedMinRound + BloonSendOffset && (round <= bloon.FortifiedMaxRound + BloonSendOffset || bloon.MaxRound == -1)) {
                bloonIds.Add(bloon.BaseBloonId + "Fortified");
            }
        }

        return bloonIds;
    }
}
