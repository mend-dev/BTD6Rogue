using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;

namespace BTD6Rogue;

public class RogueVortex1 : ModBloon {
    public override string BaseBloon => "Vortex1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 6000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 2f;
        bloonModel.Speed = 2f;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>()) {
            model.radius = 40f;
            model.stunDuration = 10f;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>()) {
            model.distance = -150f;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>()) {
            model.radius = 40f;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>()) {
            model.lifespan = 5f;
            model.innerRadius = 60f;
            model.outerRadius = 70f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 30f;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>()) {
            model.speedBoost = 1.5f;
            model.debuffInRadius = 30f;
        }
    }
}

public class RogueVortex2 : ModBloon {
    public override string BaseBloon => "Vortex1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 12000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 2.1f;
        bloonModel.Speed = 2.1f;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>()) {
            model.radius = 45f;
            model.stunDuration = 12f;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>()) {
            model.distance = -140f;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>()) {
            model.radius = 43f;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>()) {
            model.lifespan = 6f;
            model.innerRadius = 60f;
            model.outerRadius = 70f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 25f;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>()) {
            model.speedBoost = 1.6f;
            model.debuffInRadius = 32f;
        }
    }
}

public class RogueVortex3 : ModBloon {
    public override string BaseBloon => "Vortex2";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 24000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 2.2f;
        bloonModel.Speed = 2.2f;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>()) {
            model.radius = 50f;
            model.stunDuration = 14f;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>()) {
            model.distance = -130f;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>()) {
            model.radius = 45f;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>()) {
            model.lifespan = 7f;
            model.innerRadius = 60f;
            model.outerRadius = 75f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 20f;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>()) {
            model.speedBoost = 1.7f;
            model.debuffInRadius = 34f;
        }
    }
}

public class RogueVortex4 : ModBloon {
    public override string BaseBloon => "Vortex3";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 48000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 2.3f;
        bloonModel.Speed = 2.3f;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>()) {
            model.radius = 55f;
            model.stunDuration = 16f;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>()) {
            model.distance = -120f;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>()) {
            model.radius = 47f;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>()) {
            model.lifespan = 8f;
            model.innerRadius = 60f;
            model.outerRadius = 75f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 15f;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>()) {
            model.speedBoost = 1.8f;
            model.debuffInRadius = 36f;
        }
    }
}

public class RogueVortex5 : ModBloon {
    public override string BaseBloon => "Vortex4";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 96000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 2.4f;
        bloonModel.Speed = 2.4f;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>()) {
            model.radius = 60f;
            model.stunDuration = 18f;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>()) {
            model.distance = -110f;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>()) {
            model.radius = 50f;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>()) {
            model.lifespan = 9f;
            model.innerRadius = 60f;
            model.outerRadius = 80f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 10f;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>()) {
            model.speedBoost = 1.9f;
            model.debuffInRadius = 38f;
        }
    }
}

public class RogueVortex6 : ModBloon {
    public override string BaseBloon => "Vortex5";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 192000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 2.5f;
        bloonModel.Speed = 2.5f;

        foreach (StunTowersInRadiusActionModel model in bloonModel.GetBehaviors<StunTowersInRadiusActionModel>()) {
            model.radius = 60f;
            model.stunDuration = 20f;
        }

        foreach (SetSpeedPercentActionModel model in bloonModel.GetBehaviors<SetSpeedPercentActionModel>()) {
            model.distance = -100f;
        }

        foreach (DestroyProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<DestroyProjectilesInRadiusActionModel>()) {
            model.radius = 50f;
        }

        foreach (ReflectProjectilesInRadiusActionModel model in bloonModel.GetBehaviors<ReflectProjectilesInRadiusActionModel>()) {
            model.lifespan = 10f;
            model.innerRadius = 60f;
            model.outerRadius = 80f;
        }

        foreach (TimeTriggerModel model in bloonModel.GetBehaviors<TimeTriggerModel>()) {
            model.interval = 5f;
        }

        foreach (BuffBloonSpeedModel model in bloonModel.GetBehaviors<BuffBloonSpeedModel>()) {
            model.speedBoost = 2f;
            model.debuffInRadius = 40f;
        }
    }
}