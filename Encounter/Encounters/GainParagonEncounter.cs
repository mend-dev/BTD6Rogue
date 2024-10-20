namespace BTD6Rogue;

public class GainParagonEncounter : RogueEncounter {
	public override bool CanStartEncounter() {
		if (BTD6Rogue.rogueGame.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Paragon)) { return false; }
		return true;
	}

	public override void StartEncounter() {
		BTD6Rogue.rogueGame.panelManager.AppendPanel("ParagonChoicePanel", this, true);
	}

	public override void EncounterPanelCreated() { }

	public override void ProcessChoice(EncounterChoice choice) {
		if (choice is not ParagonChoice) {
			BTD6Rogue.LogMessage("EncounterChoice instance passed to ProcessChoice from EncounterPanel isn't an instance of ParagonChoice", this.Name, ErrorLevels.Error);
			return;
		}
		ParagonChoice paragonChoice = (ParagonChoice) choice;
		ParagonData paragonData = ParagonUtil.CreateDataFromChoice(paragonChoice);
		BTD6Rogue.rogueGame.towerManager.AddParagonToInventory(paragonData);
		EndEncounter();
	}

	public override void EncounterPanelDestroyed() { }
}
