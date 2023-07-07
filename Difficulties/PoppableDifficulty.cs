using System.Collections.Generic;

namespace BTD6Rogue;

public class PoppableDifficulty : RogueDifficulty {
    public override string DifficultyName => "Poppable";
    public override Dictionary<int, string> GameHints => new Dictionary<int, string>() {};

    public override RoundGeneratorBloon RedBloon => new RoundGeneratorBloon("Red", 1, 16, true, 11, true, 18, false, 0);
    public override RoundGeneratorBloon BlueBloon => new RoundGeneratorBloon("Blue", 6, 18, true, 13, true, 20, false, 0);
    public override RoundGeneratorBloon GreenBloon => new RoundGeneratorBloon("Green", 8, 22, true, 16, true, 25, false, 0);
    public override RoundGeneratorBloon YellowBloon => new RoundGeneratorBloon("Yellow", 12, 27, true, 22, true, 30, false, 0);
    public override RoundGeneratorBloon PinkBloon => new RoundGeneratorBloon("Pink", 18, 36, true, 25, true, 32, false, 0);
    public override RoundGeneratorBloon BlackBloon => new RoundGeneratorBloon("Black", 21, 48, true, 30, true, 35, false, 0);
    public override RoundGeneratorBloon WhiteBloon => new RoundGeneratorBloon("White", 22, 49, true, 31, true, 36, false, 0);
    public override RoundGeneratorBloon LeadBloon => new RoundGeneratorBloon("Lead", 29, 999, true, 36, true, 62, true, 50);
    public override RoundGeneratorBloon ZebraBloon => new RoundGeneratorBloon("Zebra", 30, 999, true, 35, true, 39, false, 0);
    public override RoundGeneratorBloon PurpleBloon => new RoundGeneratorBloon("Purple", 32, 999, true, 39, true, 49, false, 0);
    public override RoundGeneratorBloon RainbowBloon => new RoundGeneratorBloon("Rainbow", 34, 999, true, 40, true, 43, false, 0);
    public override RoundGeneratorBloon CeramicBloon => new RoundGeneratorBloon("Ceramic", 40, 999, true, 45, true, 53, true, 51);
    public override RoundGeneratorBloon MoabBloon => new RoundGeneratorBloon("Moab", 46, 999, false, 0, false, 0, true, 56);
    public override RoundGeneratorBloon BfbBloon => new RoundGeneratorBloon("Bfb", 61, 999, false, 0, false, 0, true, 76);
    public override RoundGeneratorBloon ZomgBloon => new RoundGeneratorBloon("Zomg", 81, 999, false, 0, false, 0, true, 96);
    public override RoundGeneratorBloon DdtBloon => new RoundGeneratorBloon("Ddt", 93, 999, false, 0, false, 0, true, 105);
    public override RoundGeneratorBloon BadBloon => new RoundGeneratorBloon("Bad", 110, 999, false, 0, false, 0, true, 120);
}