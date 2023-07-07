using System.Collections.Generic;

namespace BTD6Rogue;

public abstract class RogueDifficulty {

    public abstract string DifficultyName { get; }

    public abstract Dictionary<int, string> GameHints { get; }

    public abstract RoundGeneratorBloon RedBloon { get; }
    public abstract RoundGeneratorBloon BlueBloon { get; }
    public abstract RoundGeneratorBloon GreenBloon { get; }
    public abstract RoundGeneratorBloon YellowBloon { get; }
    public abstract RoundGeneratorBloon PinkBloon { get; }
    public abstract RoundGeneratorBloon BlackBloon { get; }
    public abstract RoundGeneratorBloon WhiteBloon { get; }
    public abstract RoundGeneratorBloon LeadBloon { get; }
    public abstract RoundGeneratorBloon ZebraBloon { get; }
    public abstract RoundGeneratorBloon PurpleBloon { get; }
    public abstract RoundGeneratorBloon RainbowBloon { get; }
    public abstract RoundGeneratorBloon CeramicBloon { get; }
    public abstract RoundGeneratorBloon MoabBloon { get; }
    public abstract RoundGeneratorBloon BfbBloon { get; }
    public abstract RoundGeneratorBloon ZomgBloon { get; }
    public abstract RoundGeneratorBloon DdtBloon { get; }
    public abstract RoundGeneratorBloon BadBloon { get; }
}

public class RoundGeneratorBloon {

    public string baseBloonId;
    public int baseBloonMin;
    public int baseBloonMax;
    public bool regrow;
    public int regrowMin;
    public bool camo;
    public int camoMin;
    public bool fortified;
    public int fortifiedMin;

    public RoundGeneratorBloon(string baseBloonId, int baseBloonMin, int baseBloonMax, bool regrow, int regrowMin, bool camo, int camoMin, bool fortified, int fortifiedMin) {
        this.baseBloonId = baseBloonId;
        this.baseBloonMin = baseBloonMin;
        this.baseBloonMax = baseBloonMax;
        this.regrow = regrow;
        this.regrowMin = regrowMin;
        this.camo = camo;
        this.camoMin = camoMin;
        this.fortified = fortified;
        this.fortifiedMin = fortifiedMin;
    }

    public List<string> GetViableBloonIds(int round) {
        List<string> bloonIds = new List<string>();
        round++;

        if (round >= baseBloonMin && round <= baseBloonMax) {
            bloonIds.Add(baseBloonId);
            if (regrow && round >= regrowMin) { bloonIds.Add(baseBloonId + "Regrow"); }
            if (camo && round >= camoMin) { bloonIds.Add(baseBloonId + "Camo"); }
            if (fortified && round >= fortifiedMin) { bloonIds.Add(baseBloonId + "Fortified"); }
        }

        return bloonIds;
    }
}
