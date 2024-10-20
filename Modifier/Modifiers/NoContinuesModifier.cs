using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class NoContinuesModifier : RogueModifier {
	public override string DisplayName => "No Continues";
	public override string Description => "";
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {
		model.RemoveMutator<DisableContinueModModel>();
		model.AddMutator(new DisableContinueModModel("_"));
	}

	public override void RemoveRogueModifier(ModModel model) { model.RemoveMutator<DisableContinueModModel>(); }
}
