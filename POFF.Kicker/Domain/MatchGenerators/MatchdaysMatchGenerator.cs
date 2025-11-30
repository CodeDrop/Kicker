using System.Collections.Generic;
using System.Linq;

namespace POFF.Kicker.Domain.MatchGenerators;


public class MatchdaysMatchGenerator : IMatchGenerator
{
    private readonly int _teamsCount;
    private readonly List<MatchIndexPair> _matches = [];
    private readonly List<Matchday> _matchdays = [];

    public MatchdaysMatchGenerator(int teamsCount = 10)
    {
        _teamsCount = teamsCount;
    }

    public IEnumerable<MatchIndexPair> Generate()
    {
        _matches.Clear();
        _matches.AddRange(GenerateMatches());
        _matchdays.Clear();
        _matchdays.AddRange(GenerateMatchdays());
        return MatchIndexPairsOrderdByMatchdays();
    }

    private IEnumerable<MatchIndexPair> MatchIndexPairsOrderdByMatchdays()
    {
        foreach (var matchday in _matchdays)
        {
            foreach (var matchIndexPair in matchday)
                yield return matchIndexPair;
        }
    }

    private IEnumerable<MatchIndexPair> GenerateMatches()
    {
        for (int i = 1, loopTo = _teamsCount; i <= loopTo; i++)
        {
            for (int j = i + 1, loopTo1 = _teamsCount; j <= loopTo1; j++)
                yield return new MatchIndexPair(i, j);
        }
    }

    private IEnumerable<Matchday> GenerateMatchdays()
    {
        int blockSize = _teamsCount / 2;

        for (int i = 0, loopTo = _teamsCount - 2; i <= loopTo; i++)
            yield return GenerateMatchday(blockSize);
    }

    private Matchday GenerateMatchday(int blockSize)
    {
        var matchday = new Matchday();
        while (matchday.Count < blockSize)
        {
            var invalidatedMatches = new List<MatchIndexPair>();
            var nextMatch = GetNextMatch(matchday);
            if (nextMatch.Equals(MatchIndexPair.Empty))
            {
                nextMatch = _matches.Except(invalidatedMatches).FirstOrDefault();
                if (nextMatch is null)
                    nextMatch = MatchIndexPair.Empty;
                invalidatedMatches.AddRange(matchday.MatchesWithPlayersFrom(nextMatch));
                _matches.AddRange(invalidatedMatches);
                matchday.RemoveAll(m => invalidatedMatches.Contains(m));
            }
            matchday.Add(nextMatch);
            _matches.Remove(nextMatch);
        }
        return matchday;
    }

    private MatchIndexPair GetNextMatch(Matchday matchday)
    {
        if (_matches.Count == 0)
            return MatchIndexPair.Empty;

        for (int i = 0, loopTo = _matches.Count - 1; i <= loopTo; i++)
        {
            var match = _matches[i];
            if (!matchday.ContainsPlayerIn(match))
            {
                return match;
            }
        }

        return MatchIndexPair.Empty;
    }
}