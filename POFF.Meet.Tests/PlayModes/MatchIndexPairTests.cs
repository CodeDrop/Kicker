using NUnit.Framework;
using POFF.Meet.Domain.PlayModes;

namespace POFF.Meet.Tests;

[TestFixture]
class MatchIndexPairTests
{
    [Test]
    public void ContainsTeam1OfTest()
    {
        var m1 = new Fixture(1, 2);
        var m2 = new Fixture(1, 3);
        Assert.That(m1.ContainsTeamOf(m2), Is.True);
    }

    [Test]
    public void ContainsTeam2OfTest()
    {
        var m1 = new Fixture(1, 2);
        var m2 = new Fixture(5, 2);
        Assert.That(m1.ContainsTeamOf(m2), Is.True);
    }

    [Test]
    public void ContainsNoTeamOfTest()
    {
        var m1 = new Fixture(1, 2);
        var m2 = new Fixture(3, 4);
        Assert.IsFalse(m1.ContainsTeamOf(m2));
    }

    [Test]
    public void EqualsSameTest()
    {
        var m1 = new Fixture(1, 2);
        Assert.That(m1.Equals(m1), Is.True);
    }

    [Test]
    public void EqualsDuplicateTest()
    {
        var m1 = new Fixture(1, 2);
        var m2 = new Fixture(1, 2);
        Assert.That(m1.Equals(m2), Is.True);
    }

    [Test]
    public void EqualsReverseTest()
    {
        var m1 = new Fixture(1, 2);
        var m2 = new Fixture(2, 1);
        Assert.That(m1.Equals(m2), Is.True);
    }
}