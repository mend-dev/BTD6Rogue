using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Unity.Player;

namespace BTD6Rogue;

public class NoMonkeyKnowledgeModifier : RogueModifier {
	public override string DisplayName => "No Monkey Knowledge";
	public override string Description => "";
	public override string Image => GetSpriteReference<BTD6Rogue>("ClassicModeImage").ToString();

	public override void ApplyRogueModifier(ModModel model) {
		model.RemoveMutator<DisableMonkeyKnowledgeModModel>();
		model.AddMutator(new DisableMonkeyKnowledgeModModel("_"));
		Btd6Player player = Il2CppAssets.Scripts.Unity.Game.Player;
		player.Data.knowledgeDisabled = true;
	}

	public override void RemoveRogueModifier(ModModel model) {
		model.RemoveMutator<DisableMonkeyKnowledgeModModel>();
		Btd6Player player = Il2CppAssets.Scripts.Unity.Game.Player;
		player.Data.knowledgeDisabled = false;
	}
}
