using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using System;
using BTD_Mod_Helper;

namespace BTD6Rogue;

public static class BossUtil {

    public static string GetBossHint(string boss) {
        List<string> BloonariusHints = new List<string>() {
            "The smell of sludge and algae permeates the air",
            "Swampy mists rise from an unknown presence",
            "Gurgling sounds can be heard echoing loudly",
            "Dampness fills the battlefield, bloons can be seen coated in a slimy sheen"
        };

        List<string> VortexHints = new List<string>() {
            "Strong gusts of wind begin to blow sharply",
            "The foilage around you begins to dance, signaling a storm is brewing",
            "You feel the energy of the air currents begin to pick up",
            "Water nearby ripples, responding to an unseen force from above"
        };

        List<string> LychHints = new List<string>() {
            "A feeling of death surrounds you",
            "Shadows lengthen, the land itself mourning the approach of darkness",
            "An eeire chill fills the air",
            "Whispers can be heard beyond your sight, a sign of dark power"
        };

        List<string> DreadbloonHints = new List<string>() {
            "The ground shakes beneath your feet",
            "The earth trembles, as if uneasy about what's to come",
            "Tremors grow stronger, indicating a strong force burrowing below",
            "Vibrations in the soil can be felt",
            "A symphony of dirt and stone can be heard"
        };

        List<string> PhayzeHints = new List<string>() {
            "The space around you begins to distort",
            "The boundaries time are blurred",
            "The fabric of reality starts shifting",
            "A sudden ripple in the cosmos can be felt"
        };

        switch (boss) {
            case "RogueBloonarius":
                return BloonariusHints[new Random().Next(BloonariusHints.Count)];
            case "RogueVortex":
                return VortexHints[new Random().Next(VortexHints.Count)];
            case "RogueLych":
                return LychHints[new Random().Next(LychHints.Count)];
            case "RogueDreadbloon":
                return DreadbloonHints[new Random().Next(DreadbloonHints.Count)];
            case "RoguePhayze":
                return PhayzeHints[new Random().Next(PhayzeHints.Count)];
        }
        return "Error Message Lol";
    }
}
