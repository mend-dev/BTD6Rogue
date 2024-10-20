using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace BTD6Rogue;

public class PanelManager {

	public List<Tuple<string, RogueEncounter>> panelQueue = new List<Tuple<string, RogueEncounter>>();
	public bool isPanelOpen = false;

	// Add a menu to the end of the Queue
	public void AppendPanel(string panelName, RogueEncounter encounter, bool checkQueue = false) {
		panelQueue.Add(new (panelName, encounter));
		if (checkQueue) { CheckQueue(); }
	}

	// Add a menu to the start of the queue
	public void PrependPanel(string panelName, RogueEncounter encounter, bool checkQueue = false) {
		panelQueue.Insert(0, new (panelName, encounter));
		if (checkQueue) { CheckQueue(); }
	}

	Action<string, LogType> logHandler = delegate(string s, LogType lt) { };

	// Check the menu queue, if it contains anything
	// spawn the corrosponding Menu and remove it from the Queue
	public void CheckQueue() {
		if (panelQueue.Count < 1) { return; }

		string panelName = panelQueue[0].Item1;
		RogueEncounter panelEncounter = panelQueue[0].Item2;
		panelQueue.RemoveAt(0);

		ModHelperPanel panel = InGame.instance.uiRect.gameObject.AddModHelperPanel(new Info(panelName, InfoPreset.FillParent), null);

		switch (panelName) {
			case "TowerSelectPanel":
				panel.AddComponent<TowerSelectPanel>();
				break;
			case "HeroSelectPanel":
				panel.AddComponent<HeroSelectPanel>();
				break;
			case "TowerChoicePanel":
				panel.AddComponent<TowerChoicePanel>();
				break;
			case "HeroChoicePanel":
				panel.AddComponent<HeroChoicePanel>();
				break;
			case "ParagonChoicePanel":
				panel.AddComponent<ParagonChoicePanel>();
				break;
		}
		RoguePanel roguePanel = panel.GetComponent<RoguePanel>();

		roguePanel.SetupPanel(InGame.instance, InGame.instance.uiRect, panel, panelEncounter);
		roguePanel.CreatePanel();
		isPanelOpen = true;

		// Use UniverseLib to add component from string name
		/*Assembly universeLibAssembly = Assembly.LoadFile(Path.Combine(Path.GetTempPath(), "BTD6Rogue.Resources.Library.UniverseLib.IL2CPP.Interop.dll"));
		Type universe = universeLibAssembly.GetType("UniverseLib.Universe");

		MethodInfo universeInit = universe.GetMethods().Where(x => x.Name == "Init").FirstOrDefault();
		universeInit.Invoke(null, [null, logHandler]);


		Type reflectionUtility = universeLibAssembly.GetType("UniverseLib.ReflectionUtility");
		MethodInfo reflectionUtilityGetTypeByName = reflectionUtility.GetMethod("GetTypeByName", BindingFlags.Static | BindingFlags.Public)!;
		object typeFromName = reflectionUtilityGetTypeByName.Invoke(null, ["BTD6Rogue." + panelName])!;

		Type runtimeHelper = universeLibAssembly.GetType("UniverseLib.RuntimeHelper");
		MethodInfo runtimeHelperAddComponent = runtimeHelper.GetMethod("AddComponent", BindingFlags.Static | BindingFlags.Public)!;

		if (typeFromName is Type type) {
			MethodInfo genenricAddComponent = runtimeHelperAddComponent.MakeGenericMethod(typeof(Component));
			genenricAddComponent.Invoke(null, [panel.gameObject, type]);
		}
		RoguePanel roguePanel = panel.GetComponent<RoguePanel>();

		roguePanel.SetupPanel(InGame.instance, InGame.instance.uiRect, panel, panelEncounter);
		roguePanel.CreatePanel();
		isPanelOpen = true;*/
	}
}
