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
        return Place.CompareTo(standing.Place);
    }

    public bool Equals(Team obj)
    {
        return obj.Equals(Team);
    }
}