using System;

namespace POFF.Kicker.MatchGenerators;

public class MatchIndexPair : Tuple<int, int>
{

    public static readonly MatchIndexPair Empty = new MatchIndexPair(0, 0);

    public MatchIndexPair(int team1Index, int team2Index) : base(team1Index, team2Index)
    {
    }

    public override int GetHashCode()
    {
        return Item1.GetHashCode() | Item2.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is null || !(obj is MatchIndexPair))
            return false;
        {
            var withBlock = (MatchIndexPair)obj;
            return Item1 == withBlock.Item1 && Item2 == withBlock.Item2 || Item1 == withBlock.Item2 && Item2 == withBlock.Item1;
        }
    }

    public bool ContainsTeamOf(MatchIndexPair other)
    {
        return Item1 == other.Item1 || Item1 == other.Item2 || Item2 == other.Item2 || Item2 == other.Item1;
    }

    public override string ToString()
    {
        return $"{Item1} - {Item2}";
    }

}