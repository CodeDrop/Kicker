using Microsoft.VisualStudio.TestTools.UnitTesting;
using POFF.Kicker.Data;

namespace POFF.Kicker.Tests;

[TestClass()]
public class MatchTests
{

    [TestMethod()]
    public void MatchTest()
    {
        // Arrange
        var team1 = new Team(1);
        var team2 = new Team(2);
        const int number = 19;

        // Act
        var result = new Match(number, team1, team2);

        // Assert
        Assert.AreEqual(number, result.Number, "Unexpected Number");
        Assert.AreSame(team1, result.Team1, "Unexpected Team1");
        Assert.AreSame(team2, result.Team2, "Unexpected Team2");
    }

}