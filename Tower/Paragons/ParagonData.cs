namespace BTD6Rogue;

public class ParagonData(
	string towerId = "",
	int count = 0, bool locked = false) {

	public string towerId = towerId; // Base ID of the Tower Model
	public int count = count; // How many the player has in their inventory
	public bool locked = locked; // If the tower is unable to show up in choices
}
