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
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public MatchStatus Status { get; set; }
    public Result Result { get; set; }

    public override string ToString()
    {
        return string.Format("Spiel {0}: {1} vs. {2}", Number, Team1.Name, Team2.Name);
    }

    public new bool Equals(object obj)
    {
        var otherMatch = (Match)obj;
        if ((otherMatch.Team1.Name ?? "") != (Team1.Name ?? "") && (otherMatch.Team1.Name ?? "") != (Team2.Name ?? ""))
            return false;
        if ((otherMatch.Team2.Name ?? "") != (Team1.Name ?? "") && (otherMatch.Team2.Name ?? "") != (Team2.Name ?? ""))
            return false;

        return true;
    }
}