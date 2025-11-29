using Microsoft.VisualStudio.TestTools.UnitTesting;
using POFF.Kicker.MatchGenerators;

namespace POFF.Kicker.Tests.MatchGenerators;

[TestClass]
public class MatchIndexPairTests
{


    [TestMethod]
    public void ContainsTeam1OfTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(1, 3);
        Assert.IsTrue(m1.ContainsTeamOf(m2));
    }

    [TestMethod]
    public void ContainsTeam2OfTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(5, 2);
        Assert.IsTrue(m1.ContainsTeamOf(m2));
    }

    [TestMethod]
    public void ContainsNoTeamOfTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(3, 4);
        Assert.IsFalse(m1.ContainsTeamOf(m2));
    }

    [TestMethod]
    public void EqualsSameTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        Assert.AreEqual(m1, m1);
    }

    [TestMethod]
    public void EqualsDuplicateTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(1, 2);
        Assert.AreEqual(m1, m2);
    }

    [TestMethod]
    public void EqualsReverseTest()
    {
        var m1 = new MatchIndexPair(1, 2);
        var m2 = new MatchIndexPair(2, 1);
        Assert.AreEqual(m1, m2);
    }


}