using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
internal static class TowerSelectionMenu_IsUpgradePathClosed {
    [HarmonyPostfix]
    private static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result)
    {
        if (!InGame.instance.GetGameModel().gameMode.Contains("BTD6Rogue-")) { return; }

        if (BTD6Rogue.rogueGame is null) { return; }

        if (__instance.selectedTower == null) { return; }

        Tower tower = __instance.selectedTower.tower;
        if (tower.towerModel.IsHero()) { return; }

        if (tower.GetUpgrade(path) == null) { return; }

        if (tower.GetUpgrade(path).tier >= BTD6Rogue.rogueGame.towerManager.towers[tower.towerModel.baseId].limitTiers[path]) {
            __result = true;
        } else {
            __result = false;
        }
    }
}
