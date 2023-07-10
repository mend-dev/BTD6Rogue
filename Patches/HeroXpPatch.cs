using HarmonyLib;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity.Bridge;

namespace BTD6Rogue;


[HarmonyPatch(typeof(Hero), nameof(Hero.AddXp))]
static class AddHeroXpPatch {

    [HarmonyPostfix]
    private static void Postfix(Hero __instance, float amount) {
        if (BTD6Rogue.mod.previousIncrease == amount) { return; }

        int heroCount = 0;

        foreach (TowerToSimulation tts in InGame.instance.bridge.GetAllTowers()) {
            if (tts.GetTower().towerModel.towerSet == Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero) {
                heroCount++;
            }
        }

        float xpIncrease = (heroCount * amount) - amount;
        BTD6Rogue.mod.previousIncrease = xpIncrease;

        __instance.AddXp(xpIncrease);
    }
}