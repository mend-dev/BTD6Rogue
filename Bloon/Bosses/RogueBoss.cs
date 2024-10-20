using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;

namespace BTD6Rogue;

public abstract class RogueBoss : NamedModContent {
	public abstract string BossName { get; }
	public virtual bool IsBoss => true;

	public abstract void AdjustBloonModel(BloonModel bloonModel, int tier, bool elite);
	public abstract void AdjustBloon(Bloon bloon, int tier, bool elite);

	public override void Register() {}
}
