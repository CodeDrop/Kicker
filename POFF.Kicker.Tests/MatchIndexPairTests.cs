using NUnit.Framework;
using POFF.Kicker.Domain.MatchGenerators;

namespace POFF.Kicker.Tests;

[TestFixture]
public class MatchIndexPairTests
{


    [Test]
    public void ContainsTeam1OfTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(1, 3);
        Assert.IsTrue(m1.ContainsTeamOf(m2));
    }

    [Test]
    public void ContainsTeam2OfTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(5, 2);
        Assert.IsTrue(m1.ContainsTeamOf(m2));
    }

    [Test]
    public void ContainsNoTeamOfTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(3, 4);
        Assert.IsFalse(m1.ContainsTeamOf(m2));
    }

    [Test]
    public void EqualsSameTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        Assert.That(m1.Equals(m1), Is.True);
    }

    [Test]
    public void EqualsDuplicateTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(1, 2);
        Assert.That(m1.Equals(m2), Is.True);
    }

    [Test]
    public void EqualsReverseTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(2, 1);
        Assert.That(m1.Equals(m2), Is.True);
    }
}