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
    [TestCase(8, 1, "8:1")]
    [TestCase(0, 3, "0:3")]
    public void ToString_returns_scored_colon_conceded(int scored, int conceded, string expected)
    {
        var sut = new ScoredConceded(scored, conceded);
        Assert.That(sut.ToString(), Is.EqualTo(expected));
    }



}