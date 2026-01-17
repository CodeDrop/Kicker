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
    public void Add_operator_sums_scored()
    {
        ScoredConceded a = new(5, 3);
        ScoredConceded b = new(2, 5);
        Assert.That((a + b).Scored, Is.EqualTo(7));
    }

    [Test]
    public void Add_operator_sums_conceded()
    {
        ScoredConceded a = new(5, 3);
        ScoredConceded b = new(2, 5);
        Assert.That((a + b).Conceded, Is.EqualTo(8));
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