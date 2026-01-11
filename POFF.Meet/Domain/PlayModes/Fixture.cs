using System;

namespace POFF.Meet.Domain.PlayModes;

/// <summary>
/// Zero-based index pair representing a fixture between two teams.
/// </summary>
public class Fixture : Tuple<int, int>
{
    public static readonly Fixture Empty = new Fixture(0, 0);

    public Fixture(int team1Index, int team2Index) 
        : base(team1Index, team2Index)
    { }

    public int Section { get; set; } = -1;

    public override int GetHashCode()
    {
        return Item1.GetHashCode() | Item2.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is not Fixture otherMatchIndexPair) return false;

        return Item1 == otherMatchIndexPair.Item1 && Item2 == otherMatchIndexPair.Item2 || Item1 == otherMatchIndexPair.Item2 && Item2 == otherMatchIndexPair.Item1;
    }
}