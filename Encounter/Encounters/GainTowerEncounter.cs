
namespace BTD6Rogue;

public class GainTowerEncounter : RogueEncounter {
	public override bool CanStartEncounter() {
		return true;
	}

	public override void StartEncounter() {
		BTD6Rogue.rogueGame.panelManager.AppendPanel("TowerChoicePanel", this, true);
	}

	public override void EncounterPanelCreated() { }

	public override void ProcessChoice(EncounterChoice choice) {
		if (choice is not TowerChoice) {
			BTD6Rogue.LogMessage("EncounterChoice instance passed to ProcessChoice from EncounterPanel isn't an instance of TowerChoice", this.Name, ErrorLevels.Error);
			return;
		}
		TowerChoice towerChoice = (TowerChoice) choice;
		TowerData towerData = TowerUtil.CreateDataFromChoice(towerChoice);
		BTD6Rogue.rogueGame.towerManager.AddTowerToInventory(towerData);
		EndEncounter();
	}

	public override void EncounterPanelDestroyed() { }
}
