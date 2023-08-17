using System.Collections.Generic;

namespace BTD6Rogue;

public class RogueGame {

    // Rounds
    public RoundGenerator roundGenerator = new RoundGenerator();

    // UI
    public PanelManager panelManager = new PanelManager();
    public bool uiOpen = false; // Used in StartRoundPatch to stop player from starting a round if a ui is open

    // Game Datas
    public Dictionary<string, ModifierGameData> activeModifiers = new Dictionary<string, ModifierGameData>(); // Game data concerning modifers
    public Dictionary<string, ArtifactGameData> activeArtifacts = new Dictionary<string, ArtifactGameData>(); // Game data concerning artifacts
    public Dictionary<string, TowerGameData> towerData = new Dictionary<string, TowerGameData>(); // Game data concerning towers
    public Dictionary<string, HeroGameData> heroData = new Dictionary<string, HeroGameData>(); // Game data concerning heroes
    public Dictionary<string, ParagonGameData> paragonData = new Dictionary<string, ParagonGameData>(); // Game data concerning paragon upgrades
    // Consumables
    // Events

    // Bosses
    public List<string> availableBosses = new List<string>(); // All available bosses after game settings are locked in (generally will stay static)
    public List<string> bossBag = new List<string>(); // Available bosses at any given moment in a game
    public bool bagRandomization = false; // Whether or not to take out bosses from "bossBag" after being spawned, then reset when empty
    public string nextBoss = ""; // The next boss is decided after the previous boss, so we need to store this seperately

    // Difficulty
    public string difficulty = ""; // Difficulty name of the current game (In base rogue, Poppable, Easy, Medium, Hard, Impoppable)

    public List<string> availableTowerSets = new List<string>(); // The available tower sets in the game

    // Other
    public int rerolls = 0; // Keeps track of shared rerolls between all choices (Towers, Heroes, Paragons, Artifacts)
    public bool canGainMoney = true; // This is for the bloons that spawn infinitely as a boss is on screen (so you can't stall and infinitely farm)
    public float previousIncrease = 0; // Previous increase of Hero XP (see: HeroAddXpPatch)

    public bool continues = true;
    public bool lives = true;
    public bool income = true;
    public bool monkeyKnowledge = true;
    public bool powers = true;
    public bool selling = true;
    public bool alternateRounds = true;
}
