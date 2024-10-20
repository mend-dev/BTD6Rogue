using BTD_Mod_Helper.Api;

namespace BTD6Rogue;

// An abstract class for Rogue Encounters
public abstract class RogueEncounter : NamedModContent {
	public abstract bool CanStartEncounter();

	public abstract void StartEncounter();

	public abstract void EncounterPanelCreated();

	public abstract void ProcessChoice(EncounterChoice choice);

	public abstract void EncounterPanelDestroyed();

	public virtual void EndEncounter() {
		BTD6Rogue.rogueGame.encounterManager.EndEncounter();
	}

	public override void Register() {}
}
