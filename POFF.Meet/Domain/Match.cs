using System;
using System.Diagnostics;

namespace POFF.Meet.Domain;

[Serializable()]
[DebuggerDisplay("Match N°{Number}: {Team1} - {Team2}")]
public class Match
{
    internal Match()
    {
        // required for serialization
    }

    public Match(int number, Team team1, Team team2)
    {
        Number = number;
        Team1 = team1;
        Team2 = team2;
        Result = new Result();
    }

    public int Number { get; set; }
    public int Section { get; set; } = 0;
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public MatchStatus Status { get; set; }
    public Result Result { get; set; }

    public new bool Equals(object obj)
    {
        var otherMatch = (Match)obj;
        if (otherMatch.Team1.Equals(Team1) && otherMatch.Team2.Equals(Team2))
            return true;
        if (otherMatch.Team1.Equals(Team2) && otherMatch.Team2.Equals(Team1))
            return true;

        return false;
    }
}