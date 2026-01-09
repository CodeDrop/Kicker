using System.Collections.Generic;
using System.Linq;

namespace POFF.Meet.Domain.PlayModes;

public class MatchdaysPlayMode : IPlayMode
{
    public string Name => "Match Days";

    public IEnumerable<Fixture> Generate(int teamsCount)
    {
        // Only even number of teams except 6 can be distributed in matchdays
        if (teamsCount % 2 != 0 || teamsCount == 6) return [];

        var matchdays = GenerateMatchdays(teamsCount);

        return MatchIndexPairsOrderdByMatchdays(matchdays);
    }

    private static IEnumerable<Fixture> MatchIndexPairsOrderdByMatchdays(IEnumerable<Matchday> matchdays)
    {
        foreach (var matchday in matchdays)
        {
            foreach (var fixture in matchday)
            {
                yield return fixture;
            }
        }
    }

    private static IEnumerable<Matchday> GenerateMatchdays(int teamsCount)
    {
        var matches = new List<Fixture>(GenerateMatches(teamsCount));
        int matchCountPerMatchDay = teamsCount / 2;

        for (int i = 0, loopTo = teamsCount - 2; i <= loopTo; i++)
        {
            yield return GenerateMatchday(matches, matchCountPerMatchDay);
        }
    }

    private static IEnumerable<Fixture> GenerateMatches(int teamsCount)
    {
        for (int i = 1, loopTo = teamsCount; i <= loopTo; i++)
        {
            for (int j = i + 1, loopTo1 = teamsCount; j <= loopTo1; j++)
            {
                yield return new Fixture(i - 1, j - 1);
            }
        }
    }

    private static Matchday GenerateMatchday(List<Fixture> matches, int matchCountPerMatchDay)
    {
        var matchday = new Matchday();
        while (matchday.Count < matchCountPerMatchDay)
        {
            var invalidatedMatches = new List<Fixture>();
            var nextMatch = GetNextMatch(matches, matchday);
            if (nextMatch.Equals(Fixture.Empty))
            {
                nextMatch = matches.Except(invalidatedMatches).FirstOrDefault() ?? Fixture.Empty;
                invalidatedMatches.AddRange(matchday.MatchesWithPlayersFrom(nextMatch));
                matches.AddRange(invalidatedMatches);
                matchday.RemoveAll(m => invalidatedMatches.Contains(m));
            }
            matchday.Add(nextMatch);
            matches.Remove(nextMatch);
        }
        return matchday;
    }

    private static Fixture GetNextMatch(List<Fixture> matches, Matchday matchday)
    {
        if (matches.Count == 0) return Fixture.Empty;

        for (int i = 0, loopTo = matches.Count - 1; i <= loopTo; i++)
        {
            var match = matches[i];
            if (!matchday.ContainsPlayerIn(match))
            {
                return match;
            }
        }

        return Fixture.Empty;
    }
}