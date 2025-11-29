using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POFF.Kicker.Model;

public class Matchday : List<MatchIndexPair>
{

    public bool ContainsPlayerIn(MatchIndexPair match)
    {
        return this.Any(m => m.Item1 == match.Item1 || m.Item1 == match.Item2 || m.Item2 == match.Item1 || m.Item2 == match.Item2);
    }

    public IEnumerable<MatchIndexPair> MatchesWithPlayersFrom(MatchIndexPair match)
    {
        return this.Where(m => m.Item1 == match.Item1 || m.Item1 == match.Item2 || m.Item2 == match.Item1 || m.Item2 == match.Item2);
    }
}