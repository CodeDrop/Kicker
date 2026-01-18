namespace POFF.Meet;

public struct WinDrawLoss(in int wins, in int draws, in int losses)
{
    public int Wins { get; } = wins;
    public int Draws { get; } = draws;
    public int Losses { get; } = losses;
    public int Difference { get; } = wins - losses;

    public static WinDrawLoss operator +(in WinDrawLoss a, in WinDrawLoss b)
    {
        return new WinDrawLoss(a.Wins + b.Wins, a.Draws + b.Draws, a.Losses + b.Losses);
    }

    override public string ToString()
    {
        return $"{Wins}/{Draws}/{Losses}";
    }
}