using Il2CppAssets.Scripts.Models.Towers;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace BTD6Rogue;

public class ParagonChoice(
	string towerId = "",
	RogueParagon rogueParagon = null!,
	SpriteReference towerImage = null!, TowerModel towerModel = null!
	)
	: EncounterChoice {

	public string towerId = towerId;

	public RogueParagon rogueParagon = rogueParagon;

	public SpriteReference towerImage = towerImage;
	public TowerModel towerModel = towerModel;
}
