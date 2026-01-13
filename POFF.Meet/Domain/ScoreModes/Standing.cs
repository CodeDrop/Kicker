using System;

namespace POFF.Meet.Domain.ScoreModes;

public class Standing : IComparable
{
    public Standing(Team team)
    {
        Team = team;
    }

    public int Place { get; set; }
    public Team Team { get; }
    public int Points { get; set; }
    public ScoredConceded Sets { get; set; }
    public ScoredConceded Goals { get; set; }
    public int MatchCount { get; set; }

    public int CompareTo(object obj)
    {
        Standing standing = (Standing)obj;

        if (Points != standing.Points)
            return standing.Points.CompareTo(Points);
        if (MatchCount != standing.MatchCount)
            return standing.MatchCount.CompareTo(MatchCount);
        if (Sets.Scored != standing.Sets.Scored)
            return standing.Sets.Scored.CompareTo(Sets.Scored);
        if (Goals.Scored != standing.Goals.Scored)
            return standing.Goals.Scored.CompareTo(Goals.Scored);
        if (Goals.Conceded != standing.Goals.Conceded)
            return Goals.Conceded.CompareTo(standing.Goals.Conceded);

        return 0;
    }

    public bool Equals(Team obj)
    {
        return obj.Equals(Team);
    }
}