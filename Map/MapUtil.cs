using BTD_Mod_Helper.Api;

namespace BTD6Rogue;

public static class MapUtil {

	// Todo: Figure out btd6 vanilla ordering for this bullshit because it's scuffed
	public static RogueMap[] GetOrderedRogueMaps() {

		RogueMap[] orderedMapList = [
			ModContent.GetContent<MonkeyMeadow>()[0],
			ModContent.GetContent<InTheLoop>()[0],
			ModContent.GetContent<MiddleOfTheRoad>()[0],
			ModContent.GetContent<Tinkerton>()[0],
			ModContent.GetContent<TreeStump>()[0],
			ModContent.GetContent<TownCenter>()[0],
			ModContent.GetContent<OneTwoTree>()[0],
			ModContent.GetContent<Scrapyard>()[0],
			ModContent.GetContent<TheCabin>()[0],
			ModContent.GetContent<Resort>()[0],
			ModContent.GetContent<Skates>()[0],
			ModContent.GetContent<LotusIsland>()[0],
			ModContent.GetContent<CandyFalls>()[0],
			ModContent.GetContent<WinterPark>()[0],
			ModContent.GetContent<Carved>()[0],
			ModContent.GetContent<ParkPath>()[0],
			ModContent.GetContent<AlpineRun>()[0],
			ModContent.GetContent<FrozenOver>()[0],
			ModContent.GetContent<Cubism>()[0],
			ModContent.GetContent<FourCircles>()[0],
			ModContent.GetContent<Hedge>()[0],
			ModContent.GetContent<EndOfTheRoad>()[0],
			ModContent.GetContent<Logs>()[0],

			ModContent.GetContent<LuminousCove>()[0],
			ModContent.GetContent<SulfurSprings>()[0],
			ModContent.GetContent<WaterPark>()[0],
			ModContent.GetContent<Polyphemus>()[0],
			ModContent.GetContent<CoveredGarden>()[0],
			ModContent.GetContent<Quarry>()[0],
			ModContent.GetContent<QuietStreet>()[0],
			ModContent.GetContent<BloonariusPrime>()[0],
			ModContent.GetContent<Balance>()[0],
			ModContent.GetContent<Encrypted>()[0],
			ModContent.GetContent<Bazaar>()[0],
			ModContent.GetContent<AdorasTemple>()[0],
			ModContent.GetContent<SpringSpring>()[0],
			ModContent.GetContent<KartsNDarts>()[0],
			ModContent.GetContent<MoonLanding>()[0],
			ModContent.GetContent<Haunted>()[0],
			ModContent.GetContent<Downstream>()[0],
			ModContent.GetContent<FiringRange>()[0],
			ModContent.GetContent<Cracked>()[0],
			ModContent.GetContent<Streambed>()[0],
			ModContent.GetContent<Chutes>()[0],
			ModContent.GetContent<Rake>()[0],
			ModContent.GetContent<SpiceIslands>()[0],

			ModContent.GetContent<AncientPortal>()[0],
			ModContent.GetContent<CastleRevenge>()[0],
			ModContent.GetContent<DarkPath>()[0],
			ModContent.GetContent<Erosion>()[0],
			ModContent.GetContent<MidnightMansion>()[0],
			ModContent.GetContent<SunkenColumns>()[0],
			ModContent.GetContent<XFactor>()[0],
			ModContent.GetContent<Mesa>()[0],
			ModContent.GetContent<Geared>()[0],
			ModContent.GetContent<Spillway>()[0],
			ModContent.GetContent<Cargo>()[0],
			ModContent.GetContent<PatsPond>()[0],
			ModContent.GetContent<Peninsula>()[0],
			ModContent.GetContent<HighFinance>()[0],
			ModContent.GetContent<AnotherBrick>()[0],
			ModContent.GetContent<OffTheCoast>()[0],
			ModContent.GetContent<Cornfield>()[0],
			ModContent.GetContent<Underground>()[0],

			ModContent.GetContent<GlacialTrail>()[0],
			ModContent.GetContent<DarkDungeons>()[0],
			ModContent.GetContent<Sanctuary>()[0],
			ModContent.GetContent<Ravine>()[0],
			ModContent.GetContent<FloodedValley>()[0],
			ModContent.GetContent<Infernal>()[0],
			ModContent.GetContent<BloodyPuddles>()[0],
			ModContent.GetContent<Workshop>()[0],
			ModContent.GetContent<Quad>()[0],
			ModContent.GetContent<DarkCastle>()[0],
			ModContent.GetContent<MuddyPuddles>()[0],
			ModContent.GetContent<Ouch>()[0],
		];
		
		return orderedMapList;
	}

	public static RogueMap GetMapById(string id) {
		foreach (RogueMap map in ModContent.GetContent<RogueMap>()) {
			if (map.Id == id) { return map; }
		}
		return null!;
	}
}
