namespace BTD6Rogue;

public class HeroData(
	string baseId = "",
	int count = 0, bool locked = false) {

	public string baseId = baseId; // Base ID of the Tower Model
	public int count = count; // How many the player has in their inventory
	public bool locked = locked; // If the tower is unable to show up in choices
}
