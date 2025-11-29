using System.Collections.Generic;

namespace POFF.Kicker.Model
{
    public interface IMatchGenerator
    {
        IEnumerable<MatchIndexPair> Generate();
    }
}