using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POFF.Kicker.Model;

[TestClass()]
public class StandingTests
{

    [TestMethod()]
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