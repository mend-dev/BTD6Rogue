using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Data.Knowledge.RelicKnowledge;
using Il2CppAssets.Scripts.Models.Rounds;
using System;

namespace BTD6Rogue;

// Abstract class to handle all the data that is needed for Bloons to be used in the Rogue Gamemode
// To Do: allow for custom modifiers instead of just vanilla stuff
public abstract class RogueBloon : NamedModContent {
	public abstract string BaseBloonId { get; } // Base ID of the bloon (only need the Base Bloon, modifiers are handled inside class)

	public virtual int StartRound => -1; // The lowest round number where this bloon can spawn
	public virtual int EndRound => -1; // The highest round number where this bloon can spawn

	public virtual int MinAmount => 1; // Minimum amount of these bloons that can spawn while spawning
	public virtual int MaxAmount => 1; // Maximum amount of these bloons that can spawn while spawning

	public virtual int BloonRbe => 1; // The "Red Bloon Equivalent" of the bloon
	public virtual bool MoabClass => false;

	// Whether or not the modifier exists on the bloon
	// The round it can start spawning it
	// The round it stops spawning it

	public virtual bool Camo => false;
	public virtual int CamoStartRound => 0;
	public virtual int CamoEndRound => 0;

	public virtual bool Regrow => false;
	public virtual int RegrowStartRound => 0;
	public virtual int RegrowEndRound => 0;

	public virtual bool Fortified => false;
	public virtual int FortifiedStartRound => 0;
	public virtual int FortifiedEndRound => 0;

	public virtual BloonGroupModel GenerateBloonGroup(int round, float expectedRbe, float start, float end, bool camo, bool regrow, bool fortified) {
		int bloonAmount = GetBloonAmount(round, expectedRbe, fortified);

		string newBloonId = BaseBloonId;

		if (regrow) { newBloonId += "Regrow"; }
		if (fortified) { newBloonId += "Fortified"; }
		if (camo) { newBloonId += "Camo"; }
		
		BloonGroupModel bgm = new BloonGroupModel(BaseBloonId, newBloonId, start, end, bloonAmount);
		return bgm;
	}

	public virtual int GetBloonRbe(int round, bool fortified) {
		int fortifiedMultiplier = fortified ? 2 : 1;
		float hpMuliplier = MoabClass ? GetHpMultiplier(round) : 1;
		return (int) Math.Ceiling(BloonRbe * fortifiedMultiplier * hpMuliplier);
	}

	public virtual int GetBloonAmount(int round, float expectedRbe, bool fortified) {
		return Math.Min(50, (int) Math.Ceiling(expectedRbe / GetBloonRbe(round, fortified)));
	}

	public virtual int GetGroupRbe(int round, int amount, bool fortified) {
		int baseRbe = GetBloonRbe(round, fortified);
		return baseRbe * amount;
	}

	private float GetHpMultiplier(int round) {
		float r = round;
		float v = 0;

		if (r <= 80) { v = 1;}
		else if (r <= 100) { v = 1.0f + (r - 80) * 0.02f; }
		else if (r <= 150) { v = 1.6f + (r - 101) * 0.02f; }
		else if (r <= 200) { v = 3.0f + (r - 151) * 0.02f; }
		else if (r <= 250) { v = 4.5f + (r - 201) * 0.02f; }
		else { v = 6.0f + (r - 252) * 0.02f; }
		return v;
	}

	public override sealed void Register() { } // Still no idea what this does
}
