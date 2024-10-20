using Il2CppAssets.Scripts.Models.Towers;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace BTD6Rogue;

public class TowerChoice(
	string towerId = "", string towerName = "", int towerAmount = 0, int[] towerPaths = null!,
	RogueTower rogueTower = null!,
	SpriteReference towerImage = null!, TowerModel towerModel = null!
	)
	: EncounterChoice {

	public string towerId = towerId;

	public string towerName = towerName;

	public int towerAmount = towerAmount;
	public int[] towerPaths = towerPaths ?? [0, 0, 0];

	public RogueTower rogueTower = rogueTower;

	public SpriteReference towerImage = towerImage;
	public TowerModel towerModel = towerModel;
}
