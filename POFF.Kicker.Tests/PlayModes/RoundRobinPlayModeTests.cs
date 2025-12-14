using System.Linq;
using NUnit.Framework;
using POFF.Kicker.Domain.PlayModes;

namespace POFF.Kicker.Tests;

[TestFixture]
class RoundRobinPlayModeTests
{
    [Test]
    public void Generate2Test()
    {
        var sut = new RoundRobinPlayMode();
        var result = sut.Generate(2);
        Assert.That(result.Count(), Is.EqualTo(1));
    }

    [Test]
    public void Generate3Test()
    {
        var sut = new RoundRobinPlayMode();
        var result = sut.Generate(3);
        Assert.That(result.Count(), Is.EqualTo(3));
    }

    [Test]
    public void Generate5Test()
    {
        var sut = new RoundRobinPlayMode();
        var result = sut.Generate(5);
        Assert.That(result.Count(), Is.EqualTo(10));
    }
}