using System;

namespace POFF.Meet.Domain.ScoreModes;

public class Standing : IComparable
{
    public Standing(Team team)
    {
        Team = team;
    }

    public int Place { get; set; }
    public Team Team { get; set; }
    public int Points { get; set; }
    public int Goals { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalsDifference => Goals - GoalsAgainst;
    public int MatchCount { get; set; }
    public int WonSetCount { get; set; }

    public int CompareTo(object obj)
    {
        Standing standing = (Standing)obj;

        if (Points != standing.Points)
            return standing.Points.CompareTo(Points);
        if (WonSetCount != standing.WonSetCount)
            return standing.WonSetCount.CompareTo(WonSetCount);
        if (Goals != standing.Goals)
            return standing.Goals.CompareTo(Goals);
        if (GoalsAgainst != standing.GoalsAgainst)
            return GoalsAgainst.CompareTo(standing.GoalsAgainst);

        return 0;
    }

    public bool Equals(Team obj)
    {
        return obj.Equals(Team);
    }
}