using System.Collections.Generic;

namespace BTD6Rogue;

public class MediumDifficulty : RogueDifficulty {
    public override string DifficultyName => "Medium";
    public override Dictionary<int, string> GameHints => new Dictionary<int, string>() {};

    public override RoundGeneratorBloon RedBloon => new RoundGeneratorBloon("Red", 1, 12, true, 9, true, 16, false, 0);
    public override RoundGeneratorBloon BlueBloon => new RoundGeneratorBloon("Blue", 4, 14, true, 11, true, 18, false, 0);
    public override RoundGeneratorBloon GreenBloon => new RoundGeneratorBloon("Green", 6, 18, true, 14, true, 23, false, 0);
    public override RoundGeneratorBloon YellowBloon => new RoundGeneratorBloon("Yellow", 9, 23, true, 18, true, 26, false, 0);
    public override RoundGeneratorBloon PinkBloon => new RoundGeneratorBloon("Pink", 14, 30, true, 21, true, 28, false, 0);
    public override RoundGeneratorBloon BlackBloon => new RoundGeneratorBloon("Black", 17, 42, true, 26, true, 31, false, 0);
    public override RoundGeneratorBloon WhiteBloon => new RoundGeneratorBloon("White", 18, 43, true, 27, true, 32, false, 0);
    public override RoundGeneratorBloon LeadBloon => new RoundGeneratorBloon("Lead", 26, 999, true, 32, true, 58, true, 46);
    public override RoundGeneratorBloon ZebraBloon => new RoundGeneratorBloon("Zebra", 28, 999, true, 33, true, 37, false, 0);
    public override RoundGeneratorBloon PurpleBloon => new RoundGeneratorBloon("Purple", 30, 999, true, 37, true, 47, false, 0);
    public override RoundGeneratorBloon RainbowBloon => new RoundGeneratorBloon("Rainbow", 32, 999, true, 38, true, 41, false, 0);
    public override RoundGeneratorBloon CeramicBloon => new RoundGeneratorBloon("Ceramic", 36, 999, true, 41, true, 49, true, 47);
    public override RoundGeneratorBloon MoabBloon => new RoundGeneratorBloon("Moab", 40, 999, false, 0, false, 0, true, 50);
    public override RoundGeneratorBloon BfbBloon => new RoundGeneratorBloon("Bfb", 55, 999, false, 0, false, 0, true, 70);
    public override RoundGeneratorBloon ZomgBloon => new RoundGeneratorBloon("Zomg", 75, 999, false, 0, false, 0, true, 90);
    public override RoundGeneratorBloon DdtBloon => new RoundGeneratorBloon("Ddt", 85, 999, false, 0, false, 0, true, 95);
    public override RoundGeneratorBloon BadBloon => new RoundGeneratorBloon("Bad", 100, 999, false, 0, false, 0, true, 110);
}