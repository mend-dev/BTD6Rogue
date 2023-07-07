using System.Collections.Generic;

namespace BTD6Rogue;

public class ImpoppableDifficulty : RogueDifficulty {
    public override string DifficultyName => "Impoppable";
    public override Dictionary<int, string> GameHints => new Dictionary<int, string>() {};

    public override RoundGeneratorBloon RedBloon => new RoundGeneratorBloon("Red", 1, 8, true, 7, true, 14, false, 0);
    public override RoundGeneratorBloon BlueBloon => new RoundGeneratorBloon("Blue", 2, 10, true, 11, true, 18, false, 0);
    public override RoundGeneratorBloon GreenBloon => new RoundGeneratorBloon("Green", 4, 14, true, 12, true, 21, false, 0);
    public override RoundGeneratorBloon YellowBloon => new RoundGeneratorBloon("Yellow", 6, 19, true, 14, true, 22, false, 0);
    public override RoundGeneratorBloon PinkBloon => new RoundGeneratorBloon("Pink", 10, 24, true, 17, true, 24, false, 0);
    public override RoundGeneratorBloon BlackBloon => new RoundGeneratorBloon("Black", 13, 36, true, 22, true, 27, false, 0);
    public override RoundGeneratorBloon WhiteBloon => new RoundGeneratorBloon("White", 14, 37, true, 23, true, 28, false, 0);
    public override RoundGeneratorBloon LeadBloon => new RoundGeneratorBloon("Lead", 22, 999, true, 28, true, 54, true, 42);
    public override RoundGeneratorBloon ZebraBloon => new RoundGeneratorBloon("Zebra", 26, 999, true, 31, true, 35, false, 0);
    public override RoundGeneratorBloon PurpleBloon => new RoundGeneratorBloon("Purple", 28, 999, true, 35, true, 45, false, 0);
    public override RoundGeneratorBloon RainbowBloon => new RoundGeneratorBloon("Rainbow", 30, 999, true, 36, true, 39, false, 0);
    public override RoundGeneratorBloon CeramicBloon => new RoundGeneratorBloon("Ceramic", 32, 999, true, 37, true, 45, true, 43);
    public override RoundGeneratorBloon MoabBloon => new RoundGeneratorBloon("Moab", 34, 999, false, 0, false, 0, true, 44);
    public override RoundGeneratorBloon BfbBloon => new RoundGeneratorBloon("Bfb", 49, 999, false, 0, false, 0, true, 64);
    public override RoundGeneratorBloon ZomgBloon => new RoundGeneratorBloon("Zomg", 69, 999, false, 0, false, 0, true, 84);
    public override RoundGeneratorBloon DdtBloon => new RoundGeneratorBloon("Ddt", 75, 999, false, 0, false, 0, true, 85);
    public override RoundGeneratorBloon BadBloon => new RoundGeneratorBloon("Bad", 90, 999, false, 0, false, 0, true, 100);
}