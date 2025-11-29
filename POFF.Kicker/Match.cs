using System;
using System.Diagnostics;

namespace POFF.Kicker.Model;

[Serializable()]
[DebuggerDisplay("Match N°{Number}: {Team1} - {Team2}")]
public class Match
{

    internal Match()
    {
        // 
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

    public bool HasTeam(Team team)
    {
        if (Team1.Equals(team))
            return true;
        if (Team2.Equals(team))
            return true;
        return false;
    }

    public override string ToString()
    {
        return string.Format("Spiel {0}: {2} vs. {3}", Number, Team1.Name, Team2.Name);
    }

    public new bool Equals(object obj)
    {
        {
            var withBlock = (Match)obj;
            if ((withBlock.Team1.Name ?? "") != (Team1.Name ?? "") && (withBlock.Team1.Name ?? "") != (Team2.Name ?? ""))
                return false;
            if ((withBlock.Team2.Name ?? "") != (Team1.Name ?? "") && (withBlock.Team2.Name ?? "") != (Team2.Name ?? ""))
                return false;

            return true;
        }
    }

}