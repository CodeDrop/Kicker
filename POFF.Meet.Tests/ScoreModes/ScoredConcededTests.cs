using NUnit.Framework;
using POFF.Meet.Domain.ScoreModes;

namespace POFF.Meet.Tests.ScoreModes;

[TestFixture]
public class ScoredConcededTests
{
    [Test]
    public void Scored_is_initialized()
    {
        var sut = new ScoredConceded(10, 0);
        Assert.That(sut.Scored, Is.EqualTo(10));
    }

    [Test]
    public void Conceded_is_initialized()
    {
        var sut = new ScoredConceded(0, 10);
        Assert.That(sut.Conceded, Is.EqualTo(10));
    }

    [Test]
    [TestCase(15, 5, 10)]
    [TestCase(3, 4, -1)]
    public void Difference_is_scored_minus_conceded(int scored, int conceded, int expected)
    {
        var sut = new ScoredConceded(scored, conceded);
        Assert.That(sut.Difference, Is.EqualTo(expected));
    }
}