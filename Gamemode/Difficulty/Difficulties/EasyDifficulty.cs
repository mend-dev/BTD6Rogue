using System.Collections.Generic;

namespace BTD6Rogue;

public class EasyDifficulty : RogueDifficulty {
    public override string DisplayName => "Easy";
    public override Dictionary<int, string> GameHintOverrides => new Dictionary<int, string>();
    public override float CostModifier => 0.85f;
    public override int BloonSendOffset => 3;
    public override Dictionary<string, int> BloonSendOffsets => new Dictionary<string, int>();
	public override string Image => GetSpriteReference<BTD6Rogue>("EasyDifficultyImage").ToString();
}