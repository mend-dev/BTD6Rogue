using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;

namespace BTD6Rogue;

[HarmonyPatch(typeof(InGame), nameof(InGame.Restart))]
static class RestartGamePatch {
    [HarmonyPostfix]
    private static void Postfix(InGame __instance) {
        if (__instance.bridge.IsSandboxMode()) { return; }
        BTD6Rogue.mod.rogueTowers.Clear();
        foreach (string towerName in TowerUtil.towerNames) { BTD6Rogue.mod.rogueTowers.Add(towerName, new RogueTower()); }
        BTD6Rogue.mod.StartRogueGame(__instance);
    }
}