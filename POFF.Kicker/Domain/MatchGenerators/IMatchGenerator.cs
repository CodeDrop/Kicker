using System.Collections.Generic;

namespace POFF.Kicker.Domain.MatchGenerators;

public interface IMatchGenerator
{
    IEnumerable<MatchIndexPair> Generate();
}