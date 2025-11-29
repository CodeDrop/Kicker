using System.Collections.Generic;

namespace POFF.Kicker.MatchGenerators;

public interface IMatchGenerator
{
    IEnumerable<MatchIndexPair> Generate();
}