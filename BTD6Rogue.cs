using MelonLoader;
using BTD_Mod_Helper;
using BTD6Rogue;

[assembly: MelonInfo(typeof(BTD6Rogue.BTD6Rogue), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD6Rogue;

public partial class BTD6Rogue : BloonsTD6Mod {
}