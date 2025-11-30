using NUnit.Framework;
using POFF.Kicker.Domain;

namespace POFF.Kicker.Tests;

[TestFixture]
public class StandingTests
{

    [Test]
    public void StandingTest()
    {
        // Arrange
        var team = new Team(1);

        // Act
        var result = new Standing(team);

        // Assert
        Assert.AreSame(team, result.Team, "Unexpected Team");
    }

}