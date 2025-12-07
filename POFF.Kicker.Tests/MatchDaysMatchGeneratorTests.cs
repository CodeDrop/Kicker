using System;
using System.Linq;
using NUnit.Framework;
using POFF.Kicker.Domain.MatchGenerators;

namespace POFF.Kicker.Tests;

[TestFixture]
class MatchDaysMatchGeneratorTests
{
    [Test]
    public void Generate2Test()
    {
        var sut = new MatchdaysMatchGenerator(2);
        var result = sut.Generate();
        Assert.That(result.Count(), Is.EqualTo(1));
    }

    [Test]
    public void Generate4Test()
    {
        var sut = new MatchdaysMatchGenerator(4);
        var result = sut.Generate();
        Assert.That(result.Count(), Is.EqualTo(6));
    }

    [Test]
    public void Generate10Test()
    {
        var sut = new MatchdaysMatchGenerator(10);
        var result = sut.Generate();
        Assert.That(result.Count(), Is.EqualTo(45));
        Assert.AreNotEqual(new Tuple<int, int>(0, 2), result.ElementAt(1));
    }

    [Test]
    public void GenerateXTest()
    {
        var sut = new MatchdaysMatchGenerator(14);
        var result = sut.Generate();
        foreach (var matchIndexPair in result)
            Console.WriteLine(matchIndexPair);
    }
}