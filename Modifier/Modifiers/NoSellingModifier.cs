using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class NoSellingModifier : RogueModifier {
	public override string DisplayName => "No Selling";
	public override string Description => "";
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {
		model.RemoveMutator<DisableSellTowerModModel>();
		model.AddMutator(new DisableSellTowerModModel("_"));
	}

	public override void RemoveRogueModifier(ModModel model) { model.RemoveMutator<DisableSellTowerModModel>(); }
}
