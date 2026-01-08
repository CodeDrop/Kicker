using System.Collections.Generic;
using System.Linq;

namespace POFF.Meet.Domain.PlayModes;

public class MatchdaysPlayMode : IPlayMode
{
    private int _teamsCount;
    private readonly List<Fixture> _matches = [];
    private readonly List<Matchday> _matchdays = [];

    public string Name => "Match Days";

    public IEnumerable<Fixture> Generate(int teamsCount)
    {
        if (teamsCount % 2 != 0) return [];

        _teamsCount = teamsCount;
        _matches.Clear();
        _matches.AddRange(GenerateMatches());
        _matchdays.Clear();
        _matchdays.AddRange(GenerateMatchdays());
        return MatchIndexPairsOrderdByMatchdays();
    }

    private IEnumerable<Fixture> MatchIndexPairsOrderdByMatchdays()
    {
        foreach (var matchday in _matchdays)
        {
            foreach (var matchIndexPair in matchday)
            {
                yield return matchIndexPair;
            }
        }
    }

    private IEnumerable<Fixture> GenerateMatches()
    {
        for (int i = 1, loopTo = _teamsCount; i <= loopTo; i++)
        {
            for (int j = i + 1, loopTo1 = _teamsCount; j <= loopTo1; j++)
            {
                yield return new Fixture(i - 1, j - 1);
            }
        }
    }

    private IEnumerable<Matchday> GenerateMatchdays()
    {
        int blockSize = _teamsCount / 2;

        for (int i = 0, loopTo = _teamsCount - 2; i <= loopTo; i++)
        {
            yield return GenerateMatchday(blockSize);
        }
    }

    private Matchday GenerateMatchday(int blockSize)
    {
        var matchday = new Matchday();
        while (matchday.Count < blockSize)
        {
            var invalidatedMatches = new List<Fixture>();
            var nextMatch = GetNextMatch(matchday);
            if (nextMatch.Equals(Fixture.Empty))
            {
                nextMatch = _matches.Except(invalidatedMatches).FirstOrDefault();
                if (nextMatch is null)
                    nextMatch = Fixture.Empty;
                invalidatedMatches.AddRange(matchday.MatchesWithPlayersFrom(nextMatch));
                _matches.AddRange(invalidatedMatches);
                matchday.RemoveAll(m => invalidatedMatches.Contains(m));
            }
            matchday.Add(nextMatch);
            _matches.Remove(nextMatch);
        }
        return matchday;
    }

    private Fixture GetNextMatch(Matchday matchday)
    {
        if (_matches.Count == 0) return Fixture.Empty;

        for (int i = 0, loopTo = _matches.Count - 1; i <= loopTo; i++)
        {
            var match = _matches[i];
            if (!matchday.ContainsPlayerIn(match))
            {
                return match;
            }
        }

        return Fixture.Empty;
    }
}