using NUnit.Framework;

namespace POFF.Meet.Tests.ScoreModes;

[TestFixture]
public class WinDrawLossTests
{
    [Test]
    public void Wins_is_initialized()
    {
        var sut = new WinDrawLoss(5, 1, 2);
        Assert.That(sut.Wins, Is.EqualTo(5));
    }

    [Test]
    public void Draws_is_initialized()
    {
        var sut = new WinDrawLoss(5, 1, 2);
        Assert.That(sut.Draws, Is.EqualTo(1));
    }

    [Test]
    public void Losses_is_initialized()
    {
        var sut = new WinDrawLoss(5, 1, 2);
        Assert.That(sut.Losses, Is.EqualTo(2));
    }

    [Test]
    public void Add_operator_sums_wins()
    {
        WinDrawLoss a = new(1, 0, 0);
        WinDrawLoss b = new(2, 0, 0);
        Assert.That((a + b).Wins, Is.EqualTo(3));
    }

    [Test]
    public void Add_operator_sums_draws()
    {
        WinDrawLoss a = new(0, 1, 0);
        WinDrawLoss b = new(0, 2, 0);
        Assert.That((a + b).Draws, Is.EqualTo(3));
    }

    [Test]
    public void Difference_returns_win_minus_loss()
    {
        WinDrawLoss sut = new(5, 4, 3);
        Assert.That(sut.Difference, Is.EqualTo(2));
    }

    [Test]
    [TestCase(5, 1, 2, "5/1/2")]
    [TestCase(0, 2, 6, "0/2/6")]
    public void ToString_returns_scored_colon_conceded(int wins, int draws, int losses, string expected)
    {
        var sut = new WinDrawLoss(wins, draws, losses);
        Assert.That(sut.ToString(), Is.EqualTo(expected));
    }
}