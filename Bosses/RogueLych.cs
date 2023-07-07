using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppNewtonsoft.Json;

namespace BTD6Rogue;

public class RogueLych1 : ModBloon {
    public override string BaseBloon => "Lych1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 12500;
    }
}

public class RogueLych2 : ModBloon {
    public override string BaseBloon => "Lych1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 25000;
    }
}

public class RogueLych3 : ModBloon {
    public override string BaseBloon => "Lych2";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 50000;
    }
}

public class RogueLych4 : ModBloon {
    public override string BaseBloon => "Lych3";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 100000;
    }
}

public class RogueLych5 : ModBloon {
    public override string BaseBloon => "Lych4";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 200000;
    }
}

public class RogueLych6 : ModBloon {
    public override string BaseBloon => "Lych5";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 400000;
    }
}