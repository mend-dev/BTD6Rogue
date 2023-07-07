using System.Collections.Generic;

namespace BTD6Rogue;

public class HardDifficulty : RogueDifficulty {
    public override string DifficultyName => "Hard";
    public override Dictionary<int, string> GameHints => new Dictionary<int, string>() {};

    public override RoundGeneratorBloon RedBloon => new RoundGeneratorBloon("Red", 1, 10, true, 8, true, 15, false, 0);
    public override RoundGeneratorBloon BlueBloon => new RoundGeneratorBloon("Blue", 3, 12, true, 10, true, 17, false, 0);
    public override RoundGeneratorBloon GreenBloon => new RoundGeneratorBloon("Green", 5, 16, true, 13, true, 22, false, 0);
    public override RoundGeneratorBloon YellowBloon => new RoundGeneratorBloon("Yellow", 7, 21, true, 16, true, 24, false, 0);
    public override RoundGeneratorBloon PinkBloon => new RoundGeneratorBloon("Pink", 12, 27, true, 19, true, 26, false, 0);
    public override RoundGeneratorBloon BlackBloon => new RoundGeneratorBloon("Black", 15, 39, true, 24, true, 29, false, 0);
    public override RoundGeneratorBloon WhiteBloon => new RoundGeneratorBloon("White", 16, 40, true, 25, true, 30, false, 0);
    public override RoundGeneratorBloon LeadBloon => new RoundGeneratorBloon("Lead", 23, 999, true, 30, true, 56, true, 44);
    public override RoundGeneratorBloon ZebraBloon => new RoundGeneratorBloon("Zebra", 27, 999, true, 32, true, 36, false, 0);
    public override RoundGeneratorBloon PurpleBloon => new RoundGeneratorBloon("Purple", 29, 999, true, 36, true, 46, false, 0);
    public override RoundGeneratorBloon RainbowBloon => new RoundGeneratorBloon("Rainbow", 31, 999, true, 37, true, 40, false, 0);
    public override RoundGeneratorBloon CeramicBloon => new RoundGeneratorBloon("Ceramic", 34, 999, true, 39, true, 47, true, 45);
    public override RoundGeneratorBloon MoabBloon => new RoundGeneratorBloon("Moab", 37, 999, false, 0, false, 0, true, 47);
    public override RoundGeneratorBloon BfbBloon => new RoundGeneratorBloon("Bfb", 52, 999, false, 0, false, 0, true, 67);
    public override RoundGeneratorBloon ZomgBloon => new RoundGeneratorBloon("Zomg", 72, 999, false, 0, false, 0, true, 87);
    public override RoundGeneratorBloon DdtBloon => new RoundGeneratorBloon("Ddt", 90, 999, false, 0, false, 0, true, 90);
    public override RoundGeneratorBloon BadBloon => new RoundGeneratorBloon("Bad", 95, 999, false, 0, false, 0, true, 105);
}