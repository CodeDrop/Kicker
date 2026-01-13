namespace POFF.Meet.Domain.ScoreModes;

public struct ScoredConceded(in int scored, in int conceded)
{
    public int Scored { get; } = scored;

    public int Conceded { get; } = conceded;

    public readonly int Difference => Scored - Conceded;
}