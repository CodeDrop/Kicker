using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POFF.Kicker.Domain;

[TestClass()]
public class TeamTests
{

    [TestMethod()]
    public void TeamTest()
    {
        // Arrange
        int number = 3;

        // Act
        var result = new Team(number);

        // Assert
        Assert.AreEqual("Team N°3", result.Name, "Unexpected Name");
    }

}