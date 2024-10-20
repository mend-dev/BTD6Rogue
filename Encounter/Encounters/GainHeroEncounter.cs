
namespace BTD6Rogue;

public class GainHeroEncounter : RogueEncounter {
	public override bool CanStartEncounter() {
		if (BTD6Rogue.rogueGame.towerManager.disabledTowerSets.Contains(Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero)) { return false; }
		return true;
	}

	public override void StartEncounter() {
		BTD6Rogue.rogueGame.panelManager.AppendPanel("HeroChoicePanel", this, true);
	}

	public override void EncounterPanelCreated() { }

	public override void ProcessChoice(EncounterChoice choice) {
		if (choice is not HeroChoice) {
			BTD6Rogue.LogMessage("EncounterChoice instance passed to ProcessChoice from EncounterPanel isn't an instance of HeroChoice", this.Name, ErrorLevels.Error);
			return;
		}
		HeroChoice heroChoice = (HeroChoice) choice;
		HeroData heroData = HeroUtil.CreateDataFromChoice(heroChoice);
		BTD6Rogue.rogueGame.towerManager.AddHeroToInventory(heroData);
		EndEncounter();
	}

	public override void EncounterPanelDestroyed() {}
}
