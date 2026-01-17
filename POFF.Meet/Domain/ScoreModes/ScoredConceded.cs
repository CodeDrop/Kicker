namespace POFF.Meet.Domain.ScoreModes;

public readonly struct ScoredConceded(in int scored, in int conceded)
{
    public int Scored { get; } = scored;

    public int Conceded { get; } = conceded;

    public readonly int Difference => Scored - Conceded;

    public override string ToString()
    {
        return $"{Scored}:{Conceded}";
    }
}