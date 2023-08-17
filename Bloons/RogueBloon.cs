using BTD_Mod_Helper.Api;
using System;

namespace BTD6Rogue;

public abstract class RogueBloon : NamedModContent {

    public abstract string BaseBloonId { get; }

    public virtual int MinRound => -999;
    public virtual int MaxRound => -1;

    public virtual bool Camo => false;
    public virtual int CamoMinRound => 0;
    public virtual int CamoMaxRound => 0;

    public virtual bool Regrow => false;
    public virtual int RegrowMinRound => 0;
    public virtual int RegrowMaxRound => 0;

    public virtual bool Fortified => false;
    public virtual int FortifiedMinRound => 0;
    public virtual int FortifiedMaxRound => 0;

    public virtual int GetBloonAmount(int round) {
        return (new Random(Guid.NewGuid().GetHashCode()).Next(round, round + 5) + 10);
    }

    public override sealed void Register() {}
}