using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace BTD6Rogue;

[HarmonyPatch(typeof(Tower), nameof(Tower.OnUpgraded))]
static class TowerUpgradePatch {
    [HarmonyPostfix]
    private static void Postix(Tower __instance) {
        if (__instance.towerModel.IsHero()) { return; }
        if (__instance.GetUpgrade(0) != null && __instance.GetUpgrade(0).tier >= BTD6Rogue.mod.rogueTowers[__instance.towerModel.baseId].maxTopPath) { __instance.GetUpgrade(0).cost = 9999999; }
        if (__instance.GetUpgrade(1) != null && __instance.GetUpgrade(1).tier >= BTD6Rogue.mod.rogueTowers[__instance.towerModel.baseId].maxMidPath) { __instance.GetUpgrade(1).cost = 9999999; }
        if (__instance.GetUpgrade(2) != null && __instance.GetUpgrade(2).tier >= BTD6Rogue.mod.rogueTowers[__instance.towerModel.baseId].maxBotPath) { __instance.GetUpgrade(2).cost = 9999999; }
    }
}