using NUnit.Framework;
using POFF.Meet.Domain;

namespace POFF.Meet.Tests;

[TestFixture]
public class MatchInfoTests
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
        Assert.That(result.Team1Name, Is.EqualTo("Team 1"), "Unexpected Team1Name");
        Assert.That(result.Team2Name, Is.EqualTo("Team 2"), "Unexpected Team2Name");
        Assert.That(result.ResultSummary, Is.EqualTo("5:1/5:2"), "Unexpected ResultSummary");
    }
}