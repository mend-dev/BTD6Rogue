using System.Collections.Generic;

namespace BTD6Rogue;

public class PoppableDifficulty : RogueDifficulty {
    public override string DisplayName => "Poppable";
    public override Dictionary<int, string> GameHintOverrides => new Dictionary<int, string>();
    public override float CostModifier => 0.7f;
    public override int BloonSendOffset => 6;
    public override Dictionary<string, int> BloonSendOffsets => new Dictionary<string, int>();


    public override void Register() {}
}