using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace POFF.Meet.Domain.PlayModes.Matchdays;

public class Matchday : List<Fixture>
{
    public bool ContainsPlayerIn(Fixture match)
    {
        return this.Any(m => m.Item1 == match.Item1 || m.Item1 == match.Item2 || m.Item2 == match.Item1 || m.Item2 == match.Item2);
    }

    public IEnumerable<Fixture> MatchesWithPlayersFrom(Fixture match)
    {
        return this.Where(m => m.Item1 == match.Item1 || m.Item1 == match.Item2 || m.Item2 == match.Item1 || m.Item2 == match.Item2);
    }
}