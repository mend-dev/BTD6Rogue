using System.Collections.Generic;

namespace BTD6Rogue;

public class HardDifficulty : RogueDifficulty {
    public override string DisplayName => "Hard";
    public override Dictionary<int, string> GameHintOverrides => new Dictionary<int, string>();
    public override float CostModifier => 1.15f;
    public override int BloonSendOffset => -3;
    public override Dictionary<string, int> BloonSendOffsets => new Dictionary<string, int>();
	public override string Image => GetSpriteReference<BTD6Rogue>("HardDifficultyImage").ToString();
}