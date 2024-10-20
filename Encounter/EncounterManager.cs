using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace BTD6Rogue;

public class EncounterManager(InGame game) {
	private InGame game = game;
	public List<RogueEncounter> encounterQueue = new List<RogueEncounter>();
	public RogueEncounter currentEncounter = null!;

	public void AddEncounter(RogueEncounter encounter) {
		if (!encounter.CanStartEncounter()) { return; }
		encounterQueue.Add(encounter);
		CheckEncounterQueue();
	}

	public void StartEncounter(RogueEncounter encounter) {
		encounter.StartEncounter();
		game.bridge.SetAutoPlay(false);
	}

	public void CheckEncounterQueue() {
		if (encounterQueue.Count < 1) {
			game.bridge.SetAutoPlay(true);
			return;
		}
		if (currentEncounter != null) { return; }

		currentEncounter = encounterQueue[0];
		encounterQueue.RemoveAt(0);
		StartEncounter(currentEncounter);
	}

	public void EndEncounter() {
		currentEncounter = null!;
		CheckEncounterQueue();
	}
}
