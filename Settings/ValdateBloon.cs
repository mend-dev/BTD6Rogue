using Il2CppAssets.Scripts.Unity;

namespace BTD6Rogue
{
    public class BloonValidation
    {
        public void ValidateRogueBloon(RogueBloon bloon)
        {
            string?[] arr = [bloon.BaseBloonId, null, null, null, null, null, null, null]; //
            string[] brr = ["", "Camo", "Fortified", "FortifiedCamo", "Regrow", "RegrowCamo", "RegrowFortified", "RegrowFortifiedCamo"]; //Suffixes

            if (bloon.Camo) { arr[1] = bloon.BaseBloonId + brr[1]; }
            if (bloon.Fortified) { arr[2] = bloon.BaseBloonId + brr[2]; }
            if (bloon.Camo && bloon.Fortified) { arr[3] = bloon.BaseBloonId + brr[3]; }
            if (bloon.Regrow) { arr[4] = bloon.BaseBloonId + brr[4]; }
            if (bloon.Regrow && bloon.Camo) { arr[5] = bloon.BaseBloonId + brr[5]; }
            if (bloon.Regrow && bloon.Fortified) { arr[6] = bloon.BaseBloonId + brr[6]; }
            if (bloon.Regrow && bloon.Fortified && bloon.Camo) { arr[7] = bloon.BaseBloonId + brr[7]; }

            foreach (var j in arr) //Nullable string array
            {
                if (j is null) { continue; }
                bool found = false;
                foreach (var i in Game.instance.model.bloons) // Il2CppReferenceArray<BloonModel>
                { 
                    if (i.id == j)
                    {
                        found = true;
                        break; // Exit loop when a match is found
                    }
                }
                if (!found)
                {
                    BTD6Rogue.LogMessage($"The {j} Bloon was not found. It may cause a crash ingame.", this, ErrorLevels.Warning);
                }
            }
        }

        public void ValidateAllRogueBloons()
        {
            foreach (var rogueBloon in BloonUtil.GetAllBloons())
            {
                ValidateRogueBloon(rogueBloon);
            }
        }
    }
}
