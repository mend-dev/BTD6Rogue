using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
static class IsUpgradePathClosedPatch {
    [HarmonyPostfix]
    private static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result) {
        if (__instance.selectedTower == null) { return; }
        if (BTD6Rogue.DisablePatchesInSandbox && InGame.instance.bridge.IsSandboxMode()) { return; }
        if (InGame.instance.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return; }

        Tower tower = __instance.selectedTower.tower;
        if (tower.towerModel.IsHero()) { return; }

        if (tower.GetUpgrade(path) == null) { return; }

        if (tower.GetUpgrade(path).tier >= BTD6Rogue.mod.currentGame.towerData[tower.towerModel.baseId].limitPaths[path]) { __result = true; } else { __result = false; }
    }
}

// thanks doombubbles for the code :thumbs_up:
[HarmonyPatch(typeof(UpgradeObject), nameof(UpgradeObject.UpdateVisuals))]
internal static class UpgradeVisualsPatch {
    [HarmonyPrefix]
    private static bool Prefix(UpgradeObject __instance, int path, bool upgradeClicked) {
        if (InGame.instance.GetGameModel().gameMode != "BTD6Rogue-Roguemode") { return true; }
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