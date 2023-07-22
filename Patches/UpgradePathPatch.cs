using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace BTD6Rogue;

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
static class UpgradePathPatch {
    [HarmonyPostfix]
    private static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result) {
        if (__instance.selectedTower == null) { return; }
        if (BTD6Rogue.DisablePatchesInSandbox && InGame.instance.bridge.IsSandboxMode()) { return; }

        Tower tower = __instance.selectedTower.tower;
        if (tower.towerModel.IsHero()) { return; }

        if (path == 0) {
            if (tower.GetUpgrade(path) != null && tower.GetUpgrade(path).tier >= BTD6Rogue.mod.rogueTowers[tower.towerModel.baseId].limitPaths[0]) { __result = true; } else if (tower.GetUpgrade(path) != null) { __result = false; }
        } else if (path == 1) {
            if (tower.GetUpgrade(path) != null && tower.GetUpgrade(path).tier >= BTD6Rogue.mod.rogueTowers[tower.towerModel.baseId].limitPaths[1]) { __result = true; } else if (tower.GetUpgrade(path) != null) { __result = false; }
        } else if (path == 2) {
            if (tower.GetUpgrade(path) != null && tower.GetUpgrade(path).tier >= BTD6Rogue.mod.rogueTowers[tower.towerModel.baseId].limitPaths[2]) { __result = true; } else if (tower.GetUpgrade(path) != null) { __result = false; }
        }
    }
}