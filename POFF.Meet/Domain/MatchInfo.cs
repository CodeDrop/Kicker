using System;
using POFF.Meet.Domain;

namespace POFF.Meet;

public class MatchInfo
{
    public MatchInfo(Match match)
    {
        // Check parameters
        if (match is null)
            throw new ArgumentNullException("match");

        // Initializes members
        Match = match;
        Team1Name = match.Team1.Name;
        Team2Name = match.Team2.Name;
        ResultSummary = match.Result.ToString();
    }

    internal Match Match { get; }

    public string Team1Name { get; }

    public string Team2Name { get; }

    public string ResultSummary { get; }
}