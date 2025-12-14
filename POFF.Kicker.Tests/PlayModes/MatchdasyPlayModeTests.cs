using System;
using System.Linq;
using NUnit.Framework;
using POFF.Kicker.Domain.PlayModes;

namespace POFF.Kicker.Tests;

[TestFixture]
class MatchdasyPlayModeTests
{
    [Test]
    public void Generate2Test()
    {
        var sut = new MatchdaysPlayMode();
        var result = sut.Generate(2);
        Assert.That(result.Count(), Is.EqualTo(1));
    }

    [Test]
    public void Generate4Test()
    {
        var sut = new MatchdaysPlayMode();
        var result = sut.Generate(4);
        Assert.That(result.Count(), Is.EqualTo(6));
    }

    [Test]
    public void Generate10Test()
    {
        var sut = new MatchdaysPlayMode();
        var result = sut.Generate(10);
        Assert.That(result.Count(), Is.EqualTo(45));
        Assert.That(result.ElementAt(1), Is.Not.EqualTo(new Tuple<int, int>(0, 2)));
    }

    [Test]
    public void GenerateXTest()
    {
        var sut = new MatchdaysPlayMode();
        var result = sut.Generate(14);
        foreach (var matchIndexPair in result)
            Console.WriteLine(matchIndexPair);
    }
}