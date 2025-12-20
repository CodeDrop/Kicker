using System.Linq;
using NUnit.Framework;
using POFF.Meet.Domain;
using POFF.Meet.View.Model;

namespace POFF.Meet.Tests;

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
        Assert.That(result.Teams, Is.Not.Null);
        Assert.That(result.Matches, Is.Not.Null);
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
        var matchResult = new Result();
        matchResult.AddSetResult(new SetResult() { Home = 5, Guest = 3 });
        testClass.SetResult(1, matchResult);

        // Act
        var result = testClass.GetStandings();

        // Assert
        Assert.That(result, Is.Not.Null, "GetStandings returned null");
        Assert.That(result.Count(), Is.EqualTo(2), "Unexpected Count");
    }
}