using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;

namespace BTD6Rogue;

public static class TowerUtil {

    public static int GetMaxPath(int round) {
        if (round >= 0 && round <= 19) {
            return 2;
        } else if (round >= 20 && round <= 39) {
            return 3;
        } else if (round >= 40 && round <= 59) {
            return 4;
        } else if (round >= 60) {
            return 5;
        } else {
            return 2;
        }
    }

    public static TowerModel[] GetThreeTowers(int maxPath, bool waterMap) {
        List<TowerModel> towerModels = new List<TowerModel>();

        for (int i = 0; i < 3; i++) {
            TowerModel newTower = GetTower(maxPath, waterMap);
            while (towerModels.Contains(newTower)) {
                newTower = GetTower(maxPath, waterMap);
            }
            towerModels.Add(newTower);
        }

        return towerModels.ToArray();
    }

    public static TowerModel GetTower(int maxPath, bool waterMap) {
        Random random = new Random();
        int path = random.Next(3);

        string towerId = GetRandomTowerId(waterMap);

        TowerModel towerModel = Game.instance.model.GetTower(towerId);

        if (path == 0) {
            towerModel = Game.instance.model.GetTower(towerId, maxPath, 0, 0);
        } else if (path == 1) {
            towerModel = Game.instance.model.GetTower(towerId, 0, maxPath, 0);
        } else if (path == 2) {
            towerModel = Game.instance.model.GetTower(towerId, 0, 0, maxPath);
        }

        return towerModel;
    }

    public static string GetRandomTowerId(bool waterMap) {
        if (waterMap) {
            return towerNames[new Random().Next(towerNames.Count)];
        } else {
            string towerName = towerNames[new Random().Next(towerNames.Count)];
            while (towerName == "MonkeyBuccaneer" || towerName == "MonkeySub") {
                towerName = towerNames[new Random().Next(towerNames.Count)];
            }
            return towerName;
        }
    }

    public static TowerModel[] GetHeroes(bool waterMap) {
        List<TowerModel> towerModels = new List<TowerModel>();

        for (int i = 0; i < 3; i++) {
            TowerModel newTower = GetHero();
            while (towerModels.Contains(newTower) || (newTower.baseId == "AdmiralBrickell") && waterMap) {
                newTower = GetHero();
            }
            towerModels.Add(newTower);
        }

        return towerModels.ToArray();
    }

    public static TowerModel GetHero() {
        TowerModel towerModel = Game.instance.model.GetTower(heroNames[new Random().Next(heroNames.Count)]);
        return towerModel;
    }

    public static int GetTowerCount(TowerModel towerModel) {
        Random random = new Random();
        int chance = random.Next(100);

        int baseCount = 0;

        if (towerModel.baseId == "BeastHandler") {
            baseCount += random.Next(3) + 2;
        } else if (towerModel.baseId == "DartMonkey") {
            if (towerModel.GetUpgradeLevel(1) == 4) {
                baseCount += random.Next(3) + 2;
            } else if (towerModel.GetUpgradeLevel(1) == 5) {
                baseCount += random.Next(4) + 3;
            }
        } else if (towerModel.baseId == "MonkeySub") {
            if (towerModel.GetUpgradeLevel(2) == 5) {
                baseCount += random.Next(2) + 2;
            }
        } else if (towerModel.baseId == "MonkeyBuccaneer") {
            if (towerModel.GetUpgradeLevel(2) >= 3) {
                baseCount += random.Next(4) + 3;
            } else if (towerModel.GetUpgradeLevel(0) == 5) {
                baseCount += random.Next(2) + 2;
            }
        } else if (towerModel.baseId == "WizardMonkey") {
            if (towerModel.GetUpgradeLevel(2) == 5) {
                baseCount += random.Next(2) + 1;
            }
        } else if (towerModel.baseId == "NinjaMonkey") {
            if (towerModel.GetUpgradeLevel(1) >= 3) {
                baseCount += random.Next(5) + 3;
            }
        } else if (towerModel.baseId == "Druid") {
            if (towerModel.GetUpgradeLevel(2) >= 4) {
                baseCount += random.Next(3) + 2;
            }
        } else if (towerModel.baseId == "BananaFarm") {
            baseCount += random.Next(2) + 3;
        } else if (towerModel.baseId == "MortarMonkey") {
            if (towerModel.GetUpgradeLevel(1) == 5) {
                baseCount += random.Next(2) + 2;
            }
        } else if (towerModel.baseId == "SniperMonkey") {
            if (towerModel.GetUpgradeLevel(1) >= 4) {
                baseCount += random.Next(3) + 3;
            }
        } else if (towerModel.baseId == "SuperMonkey") {
            if (towerModel.GetUpgradeLevel(0) >= 4) {
                baseCount += random.Next(3) + 2;
            }
        }

        if (chance >= 0 && chance <= 64) {
            return 1 + baseCount;
        } else if (chance >= 65 && chance <= 89) {
            return 2 + baseCount;
        }
        return 3 + baseCount;
    }

    public static readonly List<string> waterMaps = new List<string> {
        "TownCentre",
        "MiddleOfTheRoad",
        "OneTwoTree",
        "TheCabin",
        "Resort",
        "Skates",
        "LotusIsland",
        "CandyFalls",
        "WinterPark",
        "Carved",
        "ParkPath",
        "FrozenOver",
        "InTheLoop",
        "Cubism",
        "FourCircles",
        "EndOfTheRoad",
        "Logs",
        "Polyphemus",
        "CoveredGarden",
        "Quarry",
        "QuietStreet",
        "BloonariusPrime",
        "Balance",
        "Encrypted",
        "Bazaar",
        "AdorasTemple",
        "SpringSpring",
        "Haunted",
        "Downstream",
        "FiringRange",
        "Cracked",
        "Streambed",
        "Chutes",
        "Rake",
        "SpiceIslands",
        "Erosion",
        "SunkenColumns",
        "Spillway",
        "Cargo",
        "PatsPond",
        "Peninsula",
        "HighFinance",
        "AnotherBrick",
        "OffTheCoast",
        "DarkDungeons",
        "Sanctuary",
        "Ravine",
        "FloodedValley",
        "Infernal",
        "BloodyPuddles",
        "Quad",
        "DarkCastle",
        "MuddyPuddles",
        "#ouch",
    };

    public static readonly List<string> towerNames = new List<string> {
        "DartMonkey",
        "BoomerangMonkey",
        "BombShooter",
        "TackShooter",
        "IceMonkey",
        "GlueGunner",
        "SniperMonkey",
        "MonkeySub",
        "MonkeyBuccaneer",
        "MonkeyAce",
        "HeliPilot",
        "MortarMonkey",
        "DartlingGunner",
        "WizardMonkey",
        "SuperMonkey",
        "NinjaMonkey",
        "Alchemist",
        "Druid",
        "BananaFarm",
        "SpikeFactory",
        "MonkeyVillage",
        "EngineerMonkey",
        "BeastHandler",
    };

    public static readonly List<string> heroNames = new List<string> {
        TowerType.Quincy,
        TowerType.Gwendolin,
        TowerType.StrikerJones,
        TowerType.ObynGreenfoot,
        TowerType.Geraldo,
        TowerType.CaptainChurchill,
        TowerType.Benjamin,
        TowerType.Ezili,
        TowerType.PatFusty,
        TowerType.Adora,
        TowerType.AdmiralBrickell,
        TowerType.Etienne,
        TowerType.Sauda,
        TowerType.Psi
    };
}