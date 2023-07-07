using System.Collections.Generic;

namespace BTD6Rogue;

public class EasyDifficulty : RogueDifficulty {
    public override string DifficultyName => "Easy";
    public override Dictionary<int, string> GameHints => new Dictionary<int, string>() {};

    public override RoundGeneratorBloon RedBloon => new RoundGeneratorBloon("Red", 1, 14, true, 10, true, 17, false, 0);
    public override RoundGeneratorBloon BlueBloon => new RoundGeneratorBloon("Blue", 5, 16, true, 12, true, 19, false, 0);
    public override RoundGeneratorBloon GreenBloon => new RoundGeneratorBloon("Green", 7, 20, true, 15, true, 24, false, 0);
    public override RoundGeneratorBloon YellowBloon => new RoundGeneratorBloon("Yellow", 11, 25, true, 20, true, 28, false, 0);
    public override RoundGeneratorBloon PinkBloon => new RoundGeneratorBloon("Pink", 16, 33, true, 23, true, 30, false, 0);
    public override RoundGeneratorBloon BlackBloon => new RoundGeneratorBloon("Black", 19, 45, true, 28, true, 33, false, 0);
    public override RoundGeneratorBloon WhiteBloon => new RoundGeneratorBloon("White", 20, 46, true, 29, true, 34, false, 0);
    public override RoundGeneratorBloon LeadBloon => new RoundGeneratorBloon("Lead", 28, 999, true, 34, true, 60, true, 48);
    public override RoundGeneratorBloon ZebraBloon => new RoundGeneratorBloon("Zebra", 29, 999, true, 34, true, 38, false, 0);
    public override RoundGeneratorBloon PurpleBloon => new RoundGeneratorBloon("Purple", 31, 999, true, 38, true, 48, false, 0);
    public override RoundGeneratorBloon RainbowBloon => new RoundGeneratorBloon("Rainbow", 33, 999, true, 39, true, 42, false, 0);
    public override RoundGeneratorBloon CeramicBloon => new RoundGeneratorBloon("Ceramic", 38, 999, true, 43, true, 51, true, 49);
    public override RoundGeneratorBloon MoabBloon => new RoundGeneratorBloon("Moab", 43, 999, false, 0, false, 0, true, 53);
    public override RoundGeneratorBloon BfbBloon => new RoundGeneratorBloon("Bfb", 58, 999, false, 0, false, 0, true, 73);
    public override RoundGeneratorBloon ZomgBloon => new RoundGeneratorBloon("Zomg", 78, 999, false, 0, false, 0, true, 93);
    public override RoundGeneratorBloon DdtBloon => new RoundGeneratorBloon("Ddt", 90, 999, false, 0, false, 0, true, 100);
    public override RoundGeneratorBloon BadBloon => new RoundGeneratorBloon("Bad", 105, 999, false, 0, false, 0, true, 115);
}