using NUnit.Framework;
using POFF.Meet.Domain.PlayModes;

namespace POFF.Meet.Tests;

[TestFixture]
public class MatchIndexPairTests
{
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