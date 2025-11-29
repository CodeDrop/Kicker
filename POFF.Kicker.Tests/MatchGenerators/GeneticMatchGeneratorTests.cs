using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POFF.Kicker.MatchGenerators;

namespace POFF.Kicker.Tests.MatchGenerators;

[TestClass]
public class GeneticMatchGeneratorTests
{

    [TestMethod]
    public void Generate2Test()
    {
        var sut = new GeneticMatchGenerator(2);
        var result = sut.Generate();
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Generate3Test()
    {
        var sut = new GeneticMatchGenerator(3);
        var result = sut.Generate();
        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void Generate5Test()
    {
        var sut = new GeneticMatchGenerator(5);
        var result = sut.Generate();
        Assert.AreEqual(10, result.Count());
    }

}