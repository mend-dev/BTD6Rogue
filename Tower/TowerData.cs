namespace BTD6Rogue;

// Represents the Data of a Tower in the context of a Rogue Game
// Tracks what Tower the Data represents (baseId, baseRogueTower)
// Which tiers are available (limitTiers) and how many tiers the tower has in each given path (maxTiers, this serves to handle towers that don't have functionality of all 5 tiers in all 3 paths)
// Which paths are available (limitPaths) and how many paths the tower has out of 3 (hasPaths, again same as maxTiers, handles towers without paths)
// How many of the towers the player has (count)
// Whether or not the tower can show up in choices (locked)
public class TowerData(
	string baseId = "",
	int[] limitTiers = null!, int[] hasTiers = null!,
	bool[] limitPaths = null!, bool[] hasPaths = null!,
	int count = 0, bool locked = false) {
	public string baseId = baseId; // Base ID of the Tower Model
	public int[] limitTiers = limitTiers ?? [2, 2, 2]; // Limited tier of each path when upgrading in game
	public int[] hasTiers = hasTiers ?? [5, 5, 5]; // Max tier of each path in the base Tower Model
	public bool[] limitPaths = limitPaths ?? [false, false, false]; // Whether or not the path is locked out from showing up in a TowerChoicePanel
	public bool[] hasPaths = hasPaths ?? [true, true, true];  // Whether or not the base Tower Model even has that path
	public int count = count; // How many the player has in their inventory
	public bool locked = locked; // If the tower is unable to show up in choices
}

// TODO: move to separate file
// Tags given to each tower that are used in conjunction with other mechanics to allow for a more unique roguelike experience
// Every upgrade with a tag will be added onto the tags already given to the tower
public enum TowerTag {
	Single, // Deals high damage in small areas
	Multi, // Deals low damage in large areas
	Buff, // Buffs towers
	Slow, // Slows bloons
	Money, // Generates money
	Camo, // Has camo detection
	Lead, // Has lead popping
	Black, // Has black popping
	White, // Has white popping
	Purple, // Has purple popping
	Ceramic, // Has ceramic popping
	Frozen, // Has frozen popping
	Paragon, // Has a paragon upgrade
	Primary, // Primary tower or buffs Primary towers
	Military, // Military tower or buffs Military towers
	Magic, // Magic tower or buffs Magic towers
	Support, // Support tower or buffs Support towers
	Water, // Placed in water
	Land, // Placed on land
	Normal, // Deals normal damage
	Acid, // Deals acid damage
	Fire, // Deals fire damage
	Plasma, // Deals plasma damage
	Explosion, // Deals explosion damage
	Shatter, // Deals shatter damage
	Glacier, // Deals glacier damage
	Energy, // Deals energy damage
	Sharp, // Deals sharp damage
	Cold, // Deals cold damage
	Passive, // Doesn't deal damage
}
