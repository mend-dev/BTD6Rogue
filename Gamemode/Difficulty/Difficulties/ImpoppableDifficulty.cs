using System.Collections.Generic;

namespace BTD6Rogue;

public class ImpoppableDifficulty : RogueDifficulty {
    public override string DisplayName => "Impoppable";
    public override Dictionary<int, string> GameHintOverrides => new Dictionary<int, string>();
    public override float CostModifier => 1.3f;
    public override int BloonSendOffset => -6;
    public override Dictionary<string, int> BloonSendOffsets => new Dictionary<string, int>();
	public override string Image => GetSpriteReference<BTD6Rogue>("ImpoppableDifficultyImage").ToString();
}