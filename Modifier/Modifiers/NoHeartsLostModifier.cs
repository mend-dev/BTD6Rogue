using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;

namespace BTD6Rogue;

public class NoHeartsLostModifier : RogueModifier {
	public override string DisplayName => "No Lives Lost";
	public override string Description => "";
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {
		model.RemoveMutator<MaxHealthModModel>();
		model.AddMutator(new MaxHealthModModel("", 1, 0, 1));

		model.RemoveMutator<StartingHealthModModel>();
		model.AddMutator(new StartingHealthModModel("", 0, 1));
	}

	public override void RemoveRogueModifier(ModModel model) {
		model.RemoveMutator<MaxHealthModModel>();
		model.RemoveMutator<StartingHealthModModel>();
	}
}
