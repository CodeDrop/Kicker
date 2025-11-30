using NUnit.Framework;

namespace POFF.Kicker.Domain;

[TestFixture]
public class TeamTests
{

    [Test]
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