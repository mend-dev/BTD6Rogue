using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Data.MapSets;

namespace BTD6Rogue;

public abstract class RogueMap : NamedModContent {

	public abstract string InternalName { get; } // Name of the map used for loading the game
	public abstract string MapName { get; } // Display name for the map

	public abstract string MapImage { get; } // Vanilla Sprite string that points to the image of the map

	public abstract MapDifficulty GameDifficulty { get; }
	public abstract int RogueDifficulty { get; }

	public abstract bool Water { get; }

	// In RBS
	public abstract float[] TrackLengths { get; }
	// 0 = regularly split among other paths
	// 1 = moab only paths
	public abstract int[] TrackTypes { get; }

	public override void Register() {}
}
