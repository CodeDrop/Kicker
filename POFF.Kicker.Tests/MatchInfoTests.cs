using NUnit.Framework;
using POFF.Kicker.Domain;

namespace POFF.Kicker.Tests;


[TestFixture]
class MatchInfoTests
{

    [Test]
    public void MatchInfoTest()
    {
        // Arrange
        var match = new Match(1, new Team() { Name = "Team 1" }, new Team() { Name = "Team 2" });
        match.Result.AddSetResult(new SetResult() { Home = 5, Guest = 1 });
        match.Result.AddSetResult(new SetResult() { Home = 5, Guest = 2 });

        // Act
        var result = new MatchInfo(match);

        // Assert
        Assert.AreEqual("Team 1", result.Team1Name, "Unexpected Team1Name");
        Assert.AreEqual("Team 2", result.Team2Name, "Unexpected Team2Name");
        Assert.AreEqual("5:1/5:2", result.ResultSummary, "Unexpected ResultSummary");
    }

}