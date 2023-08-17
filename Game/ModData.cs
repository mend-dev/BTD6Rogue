using BTD_Mod_Helper;
using System.Collections.Generic;

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {

    public RogueGameSettingsUi gameSettingsUi = null!;
    public RogueGame currentGame = null!;

    public List<string> availableBosses = new List<string>();
    public List<string> availableTowerSets = new List<string>();
}
