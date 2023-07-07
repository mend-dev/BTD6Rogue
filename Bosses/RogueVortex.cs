using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppNewtonsoft.Json;

namespace BTD6Rogue;

public class RogueVortex1 : ModBloon {
    public override string BaseBloon => "Vortex1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 12500;
    }
}

public class RogueVortex2 : ModBloon {
    public override string BaseBloon => "Vortex1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 25000;
    }
}

public class RogueVortex3 : ModBloon {
    public override string BaseBloon => "Vortex2";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 50000;
    }
}

public class RogueVortex4 : ModBloon {
    public override string BaseBloon => "Vortex3";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 100000;
    }
}

public class RogueVortex5 : ModBloon {
    public override string BaseBloon => "Vortex4";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 200000;
    }
}

public class RogueVortex6 : ModBloon {
    public override string BaseBloon => "Vortex5";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 400000;
    }
}