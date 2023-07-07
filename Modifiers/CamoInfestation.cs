using HarmonyLib;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Unity.Bridge;

namespace BTD6Rogue;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.SpawnBloons))]
static class CamoInfestationPatch {
    [HarmonyPrefix]
    private static void Prefix(UnityToSimulation __instance, Il2CppReferenceArray<BloonEmissionModel> emissions, int roundNumber, int emissionIndexOffset) {
        ModHelper.Msg<BTD6Rogue>("spawning bloms!");
    }
}
