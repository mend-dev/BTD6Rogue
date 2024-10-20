using Il2CppAssets.Scripts.Models.Towers;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace BTD6Rogue;

public class HeroChoice(
	string towerId = "", int towerAmount = 1,
	RogueHero rogueTower = null!,
	SpriteReference towerImage = null!, TowerModel towerModel = null!
	)
	: EncounterChoice {

	public string towerId = towerId;
	public int towerAmount = towerAmount;

	public RogueHero rogueTower = rogueTower;

	public SpriteReference towerImage = towerImage;
	public TowerModel towerModel = towerModel;
}
