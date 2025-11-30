using System.Linq;
using NUnit.Framework;
using POFF.Kicker.Domain.MatchGenerators;

namespace POFF.Kicker.Tests;

[TestFixture]
public class GeneticMatchGeneratorTests
{

    [Test]
    public void Generate2Test()
    {
        var sut = new GeneticMatchGenerator(2);
        var result = sut.Generate();
        Assert.AreEqual(1, result.Count());
    }

    [Test]
    public void Generate3Test()
    {
        var sut = new GeneticMatchGenerator(3);
        var result = sut.Generate();
        Assert.AreEqual(3, result.Count());
    }

    [Test]
    public void Generate5Test()
    {
        var sut = new GeneticMatchGenerator(5);
        var result = sut.Generate();
        Assert.AreEqual(10, result.Count());
    }

}