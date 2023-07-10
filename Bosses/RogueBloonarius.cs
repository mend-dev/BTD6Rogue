using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

namespace BTD6Rogue;

public class RogueBloonarius1 : ModBloon {
    public override string BaseBloon => "Bloonarius1";
    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 7500;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 0.75f;
        bloonModel.Speed = 0.75f;
        foreach (SpawnBloonsActionModel sbam in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (sbam.actionId == "StrongSpawn") {
                sbam.bloonType = BloonType.Yellow;
                sbam.spawnCount = 30;
                sbam.spawnDistAhead = 40;
            } else if (sbam.actionId == "WeakSpawn") {
                sbam.bloonType = BloonType.Green;
                sbam.spawnCount = 60;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            } else if (sbam.actionId == "WeakerSpawn") {
                sbam.bloonType = BloonType.Blue;
                sbam.spawnCount = 10;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            }
        }
    }
}

public class RogueBloonarius2 : ModBloon {
    public override string BaseBloon => "Bloonarius1";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 15000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 0.75f;
        bloonModel.Speed = 0.75f;
        foreach (SpawnBloonsActionModel sbam in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (sbam.actionId == "StrongSpawn") {
                sbam.bloonType = BloonType.Zebra;
                sbam.spawnCount = 25;
                sbam.spawnDistAhead = 40;
            } else if (sbam.actionId == "WeakSpawn") {
                sbam.bloonType = BloonType.Pink;
                sbam.spawnCount = 50;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            } else if (sbam.actionId == "WeakerSpawn") {
                sbam.bloonType = BloonType.Yellow;
                sbam.spawnCount = 10;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            }
        }
    }
}

public class RogueBloonarius3 : ModBloon {
    public override string BaseBloon => "Bloonarius2";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 30000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 0.75f;
        bloonModel.Speed = 0.75f;
        foreach (SpawnBloonsActionModel sbam in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (sbam.actionId == "StrongSpawn") {
                sbam.bloonType = BloonType.Rainbow;
                sbam.spawnCount = 20;
                sbam.spawnDistAhead = 40;
            } else if (sbam.actionId == "WeakSpawn") {
                sbam.bloonType = BloonType.Zebra;
                sbam.spawnCount = 50;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            } else if (sbam.actionId == "WeakerSpawn") {
                sbam.bloonType = BloonType.Pink;
                sbam.spawnCount = 10;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            }
        }
    }
}

public class RogueBloonarius4 : ModBloon {
    public override string BaseBloon => "Bloonarius3";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 60000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 0.75f;
        bloonModel.Speed = 0.75f;
        foreach (SpawnBloonsActionModel sbam in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (sbam.actionId == "StrongSpawn") {
                sbam.bloonType = BloonType.Ceramic;
                sbam.spawnCount = 20;
                sbam.spawnDistAhead = 40;
            } else if (sbam.actionId == "WeakSpawn") {
                sbam.bloonType = BloonType.Rainbow;
                sbam.spawnCount = 40;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            } else if (sbam.actionId == "WeakerSpawn") {
                sbam.bloonType = BloonType.Zebra;
                sbam.spawnCount = 10;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            }
        }
    }
}

public class RogueBloonarius5 : ModBloon {
    public override string BaseBloon => "Bloonarius4";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 120000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 0.75f;
        bloonModel.Speed = 0.75f;
        foreach (SpawnBloonsActionModel sbam in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (sbam.actionId == "StrongSpawn") {
                sbam.bloonType = BloonType.Moab;
                sbam.spawnCount = 10;
                sbam.spawnDistAhead = 40;
            } else if (sbam.actionId == "WeakSpawn") {
                sbam.bloonType = BloonType.Ceramic;
                sbam.spawnCount = 20;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            } else if (sbam.actionId == "WeakerSpawn") {
                sbam.bloonType = BloonType.Rainbow;
                sbam.spawnCount = 10;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            }
        }
    }
}

public class RogueBloonarius6: ModBloon {
    public override string BaseBloon => "Bloonarius5";

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.maxHealth = 240000;
        bloonModel.leakDamage = 99999f;
        bloonModel.speed = 0.75f;
        bloonModel.Speed = 0.75f;
        foreach (SpawnBloonsActionModel sbam in bloonModel.GetBehaviors<SpawnBloonsActionModel>()) {
            if (sbam.actionId == "StrongSpawn") {
                sbam.bloonType = BloonType.Bfb;
                sbam.spawnCount = 10;
                sbam.spawnDistAhead = 40;
            } else if (sbam.actionId == "WeakSpawn") {
                sbam.bloonType = BloonType.Moab;
                sbam.spawnCount = 20;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            } else if (sbam.actionId == "WeakerSpawn") {
                sbam.bloonType = BloonType.Ceramic;
                sbam.spawnCount = 10;
                sbam.spawnTrackMax = 0.4f;
                sbam.spawnTrackMin = 0.1f;
            }
        }
    }
}