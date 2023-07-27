using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using System.Collections.Generic;
using System;
using BTD_Mod_Helper.Extensions;

namespace BTD6Rogue;

public static class ParagonUtil {

    public static TowerModel[] GetThreeParagons() {
        List<TowerModel> towerModels = new List<TowerModel>();

        for (int i = 0; i < 3; i++) {
            TowerModel newTower = GetParagon();
            //swhile (towerModels.Contains(newTower)) {
            //    newTower = GetParagon();
            //}
            towerModels.Add(newTower);
        }

        return towerModels.ToArray();
    }

    public static TowerModel GetParagon() {
        Random random = new Random();

        string[] towerIds = new string[] { TowerType.DartMonkey, TowerType.BoomerangMonkey, TowerType.MonkeyAce, TowerType.MonkeyBuccaneer,
            TowerType.NinjaMonkey, TowerType.WizardMonkey, TowerType.EngineerMonkey };

        string towerId = towerIds[random.Next(towerIds.Length)];

        
        TowerModel towerModel = Game.instance.model.GetParagonTower(towerId);
        return towerModel;
    }
}