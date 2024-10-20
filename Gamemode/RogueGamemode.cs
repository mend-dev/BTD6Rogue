using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Difficulty;

namespace BTD6Rogue;

public abstract class RogueGamemode : ModGameMode {
	public override string Difficulty => DifficultyType.Medium;
	public override string BaseGameMode => GameModeType.Medium;
	public virtual bool Enabled => false;
	public virtual string Portrait => GetSpriteReference(VanillaSprites.PortraitContainerMilitary).ToString();
	public virtual string Image => GetSpriteReference<BTD6Rogue>("ClassicGamemodeImage").ToString();

	public ModModel gameModeModel = null!;
	public GameModel gameModel = null!;

	public override void ModifyBaseGameModeModel(ModModel gameModeModel) {
		this.gameModeModel = gameModeModel;
	}

	public override void ModifyGameModel(GameModel gameModel) {
		base.ModifyGameModel(gameModel);
		this.gameModel = gameModel;
	}
}
