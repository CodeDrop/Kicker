using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POFF.Kicker.Domain.MatchGenerators;

namespace POFF.Kicker.Tests;

[TestClass]
public class MatchDaysMatchGeneratorTests
{

    [TestMethod]
    public void Generate2Test()
    {
        var sut = new MatchdaysMatchGenerator(2);
        var result = sut.Generate();
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Generate4Test()
    {
        var sut = new MatchdaysMatchGenerator(4);
        var result = sut.Generate();
        Assert.AreEqual(6, result.Count());
    }

    [TestMethod]
    public void Generate10Test()
    {
        var sut = new MatchdaysMatchGenerator(10);
        var result = sut.Generate();
        Assert.AreEqual(45, result.Count());
        Assert.AreNotEqual(new Tuple<int, int>(0, 2), result.ElementAt(1));
    }

    [TestMethod]
    public void GenerateXTest()
    {
        var sut = new MatchdaysMatchGenerator(14);
        var result = sut.Generate();
        foreach (var matchIndexPair in result)
            Console.WriteLine(matchIndexPair);
    }

}