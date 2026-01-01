using NUnit.Framework;
using POFF.Meet.Domain;
using POFF.Meet.Domain.ScoreModes;

namespace POFF.Meet.Tests;

[TestFixture]
class StandingTests
{
    [Test]
    public void StandingTest()
    {
        // Arrange
        var team = new Team {Name = "Team N°1"};

        // Act
        var result = new Standing(team);

        // Assert
        Assert.That(result.Team, Is.SameAs(team));
    }
}