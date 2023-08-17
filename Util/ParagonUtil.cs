using System.Collections.Generic;
using System;
using BTD_Mod_Helper.Api;

namespace BTD6Rogue;

public static class ParagonUtil {

    public static RogueParagon[] GetThreeParagons() {
        List<RogueParagon> paragons = new List<RogueParagon>();

        for (int i = 0; i < 3; i++) {
            RogueParagon paragon = GetRandomParagon();
            while (paragons.Contains(paragon)) {
                paragon = GetRandomParagon();
            }
            paragons.Add(paragon);
        }

        return paragons.ToArray();
    }

    public static RogueParagon GetRandomParagon() {
        Random random = new Random();

        RogueParagon[] paragons = GetAllParagons();
        RogueParagon paragon = paragons[random.Next(paragons.Length)];

        return paragon;
    }

    public static RogueParagon[] GetAllParagons() {
        List<RogueParagon> paragons = ModContent.GetContent<RogueParagon>();
        return paragons.ToArray();
    }
}