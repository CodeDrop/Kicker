using System.Linq;
using NUnit.Framework;
using POFF.Kicker.Domain;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.Tests;

[TestFixture]
class TournamentTests
{
    [Test]
    public void TournamentTest()
    {
        // Arrange
        // -

        // Act
        var result = new Tournament();

        // Assert
        Assert.IsNotNull(result.TeamManager, "TeamManager is null");
        Assert.IsNotNull(result.MatchManager, "MatchManager is null");
    }

    [Test]
    public void GetStandingsTest()
    {
        // Arrange
        var testClass = new Tournament();
        var team1 = new Team(1);
        var team2 = new Team(2);
        testClass.AddTeam(team1);
        testClass.AddTeam(team2);
        testClass.MatchManager.Generate([team1, team2]);
        var matchResult = new Result();
        matchResult.AddSetResult(new SetResult() { Home = 5, Guest = 3 });
        testClass.MatchManager.SetStatus(1, matchResult);

        // Act
        var result = testClass.GetStandings();

        // Assert
        Assert.IsNotNull(result, "GetStandings returned null");
        Assert.AreEqual(2, result.Count(), "Unexpected Count");
    }

}