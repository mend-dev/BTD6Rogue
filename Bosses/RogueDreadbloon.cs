using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppNewtonsoft.Json;

namespace BTD6Rogue;

public class RogueDreadbloon1 : ModBloon {
    public override string BaseBloon => "Dreadbloon1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 500;
        foreach (GenerateArmourActionModel gaam in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            gaam.amount = 500;
        }

        foreach (DamageReductionModel drm in bloonModel.GetBehaviors<DamageReductionModel>()) {
            drm.amount = 0.5f;
        }

        foreach (SpawnBloonsUntilArmourBreaksActionModel sbuabam in bloonModel.GetBehaviors<SpawnBloonsUntilArmourBreaksActionModel>()) {
            sbuabam.bloonType = "BTD6Rogue-RogueRockBloon1";
            //sbuabam.initialSpawnPackSize = 5;
            //sbuabam.timeBetweenSpawns = 10;
        }
    }
}

public class RogueDreadbloon2 : ModBloon {
    public override string BaseBloon => "Dreadbloon1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 1000;
        foreach (GenerateArmourActionModel gaam in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            gaam.amount = 1000;
        }
    }
}

public class RogueDreadbloon3 : ModBloon {
    public override string BaseBloon => "Dreadbloon2";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 2000;
        foreach (GenerateArmourActionModel gaam in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            gaam.amount = 2000;
        }
    }
}

public class RogueDreadbloon4 : ModBloon {
    public override string BaseBloon => "Dreadbloon3";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 4000;
        foreach (GenerateArmourActionModel gaam in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            gaam.amount = 4000;
        }
    }
}

public class RogueDreadbloon5 : ModBloon {
    public override string BaseBloon => "Dreadbloon4";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 8000;
        foreach (GenerateArmourActionModel gaam in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            gaam.amount = 8000;
        }
    }
}

public class RogueDreadbloon6 : ModBloon {
    public override string BaseBloon => "Dreadbloon5";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 16000;
        foreach (GenerateArmourActionModel gaam in bloonModel.GetBehaviors<GenerateArmourActionModel>()) {
            gaam.amount = 16000;
        }
    }
}

public class RogueRockBloon1 : ModBloon {
    public override string BaseBloon => "DreadRockBloonStandard1";
    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 30;
    }
}