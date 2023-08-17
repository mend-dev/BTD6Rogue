using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using System;

namespace BTD6Rogue;

public static class HeroUtil {

    public static RogueHero[] GetThreeHeroes() {
        List<RogueHero> heroes = new List<RogueHero>();

        for (int i = 0; i < 3; i++) {
            RogueHero hero = GetRandomHero();
            while (heroes.Contains(hero) || IsLockedHero(hero.BaseHeroId)) {
                hero = GetRandomHero();
            }
            heroes.Add(hero);
        }

        return heroes.ToArray();
    }

    public static bool IsLockedHero(string heroId) {
        return BTD6Rogue.mod.currentGame.heroData[heroId].SelectedHero;
    }

    public static RogueHero GetRandomHero() {
        Random random = new Random();

        RogueHero[] heroes = GetAllHeroes();
        RogueHero hero = heroes[random.Next(heroes.Length)];

        return hero;
    }

    public static RogueHero[] GetAllHeroes() {
        List<RogueHero> heroes = ModContent.GetContent<RogueHero>();
        return heroes.ToArray();
    }
}
