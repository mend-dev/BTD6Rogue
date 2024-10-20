using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using HarmonyLib;

namespace BTD6Rogue;

// thanks doombubbles for the code :thumbs_up:
[HarmonyPatch(typeof(UpgradeObject), nameof(UpgradeObject.UpdateVisuals))]
internal static class UpgradeObject_UpdateVisuals {
    [HarmonyPrefix]
    private static bool Prefix(UpgradeObject __instance, int path, bool upgradeClicked) {
        if (__instance.towerSelectionMenu.IsUpgradePathClosed(path)) { __instance.upgradeButton.SetUpgradeModel(null); }
        __instance.CheckLocked();
        var maxTier = __instance.CheckBlockedPath();
        var maxTierRestricted = __instance.CheckRestrictedPath();
        __instance.SetTier(__instance.tier, maxTier, maxTierRestricted);
        __instance.currentUpgrade.UpdateVisuals();
        __instance.upgradeButton.UpdateVisuals(path, upgradeClicked);
        return false;
    }
}