using NUnit.Framework;
using POFF.Kicker.Domain;
using POFF.Kicker.Domain.ScoreModes;

namespace POFF.Kicker.Tests;

[TestFixture]
class StandingTests
{
    [Test]
    public void StandingTest()
    {
        // Arrange
        var team = new Team(1);

        // Act
        var result = new Standing(team);

        // Assert
        Assert.That(result.Team, Is.SameAs(team));
    }
}