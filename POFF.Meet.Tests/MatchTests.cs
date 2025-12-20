using NUnit.Framework;
using POFF.Meet.Domain;

namespace POFF.Meet.Tests;

[TestFixture]
class MatchTests
{
    [Test]
    public void MatchTest()
    {
        // Arrange
        var team1 = new Team(1);
        var team2 = new Team(2);
        const int number = 19;

        // Act
        var result = new Match(number, team1, team2);

        // Assert
        Assert.That(result.Number, Is.EqualTo(number), "Unexpected Number");
        Assert.That(result.Team1, Is.SameAs(team1), "Unexpected Team1");
        Assert.That(result.Team2, Is.SameAs(team2), "Unexpected Team2");
    }
}