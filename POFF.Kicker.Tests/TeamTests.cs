using NUnit.Framework;
using POFF.Kicker.Domain;

namespace POFF.Kicker.Tests;

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