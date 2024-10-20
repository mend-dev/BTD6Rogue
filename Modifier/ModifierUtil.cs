using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BTD6Rogue;

public static class ModifierUtil {
	public static List<RogueModifier> ModifiersFromIds(string[] modifierIds) {
		string[] modifierIdsCopy2 = (string[]) modifierIds.Clone();
		List<string> modifierIdsCopy = modifierIdsCopy2.ToList();
		List<RogueModifier> modifiers = new List<RogueModifier>();
		List<RogueModifier> allModifiers = ModContent.GetContent<RogueModifier>();

		foreach (RogueModifier modifier in allModifiers) {
			if (modifierIdsCopy.Contains(modifier.Id)) {
				modifierIdsCopy.Remove(modifier.Id);
				modifiers.Add(modifier);
			}
		}
		return modifiers;
	}

	public static List<string> IdsFromModifiers(RogueModifier[] modifiers) {
		List<string> ids = new List<string>();
		foreach (RogueModifier modifier in modifiers) {
			ids.Add(modifier.Id);
		}
		return ids;
	}

	public static void ResetModModelModifiers(ModModel model) {
		List<RogueModifier> modifiers = ModContent.GetContent<RogueModifier>();

		foreach (RogueModifier modifier in modifiers) {
			modifier.RemoveRogueModifier(model);
		}
	}
}