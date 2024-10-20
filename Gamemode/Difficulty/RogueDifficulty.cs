using BTD_Mod_Helper.Api;
using System;
using System.Collections.Generic;

namespace BTD6Rogue;

public abstract class RogueDifficulty : NamedModContent {

	public virtual Dictionary<int, string> GameHintOverrides => new Dictionary<int, string>();
	public virtual float CostModifier => 1.0f;
	public abstract int BloonSendOffset { get; }
	public virtual Dictionary<string, int> BloonSendOffsets => new Dictionary<string, int>();
	public virtual string Image => GetSpriteReference<BTD6Rogue>("MediumDifficultyImage").ToString();

	public List<Tuple<RogueBloon, List<string>>> GetSendableRogueBloons(int round, int maxRbe) {
		// Make a list of Tuples where Item1 is a RogueBloon and Item2 is a list of modifiers the bloon can have at a given round
		List<Tuple<RogueBloon, List<string>>> bloons = new List<Tuple<RogueBloon, List<string>>>();
		RogueBloon[] allBloons = BloonUtil.GetAllBloons();

		int adjustedRound = round + 1; // In code round is 1 less than displayed (index at 0 things) but in the data it's at display value so, need to adjust it

		foreach (RogueBloon bloon in allBloons) {
			if (bloon.GetBloonRbe(round, false) > maxRbe) { continue; }

			Tuple<RogueBloon, List<string>> bloonData = new(bloon, []);
			if (adjustedRound >= bloon.StartRound + BloonSendOffset && (adjustedRound <= bloon.EndRound + BloonSendOffset || bloon.EndRound == -1)) {
				bloonData.Item2.Add("None");
			}

			if (bloon.Regrow && adjustedRound >= bloon.RegrowStartRound + BloonSendOffset && (adjustedRound <= bloon.RegrowEndRound + BloonSendOffset || bloon.EndRound == -1)) {
				bloonData.Item2.Add("Regrow");
			}

			if (bloon.Camo && adjustedRound >= bloon.CamoStartRound + BloonSendOffset && (adjustedRound <= bloon.CamoEndRound + BloonSendOffset || bloon.EndRound == -1)) {
				bloonData.Item2.Add("Camo");
			}

			if (bloon.Fortified && adjustedRound >= bloon.FortifiedStartRound + BloonSendOffset && (adjustedRound <= bloon.FortifiedEndRound + BloonSendOffset || bloon.EndRound == -1)) {
				if (bloon.GetBloonRbe(round, true) < maxRbe) { bloonData.Item2.Add("Fortified"); }
			}

			if (bloonData.Item2.Count > 0) { bloons.Add(bloonData); }
		}

		return bloons;
	}

	public override void Register() { }
}
