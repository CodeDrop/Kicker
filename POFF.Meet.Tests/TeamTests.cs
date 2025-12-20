using NUnit.Framework;
using POFF.Meet.Domain;

namespace POFF.Meet.Tests;

[TestFixture]
class TeamTests
{
    [Test]
    public void TeamTest()
    {
        // Arrange
        int number = 3;

        // Act
        var result = new Team(number);

        // Assert
        Assert.That(result.Name, Is.EqualTo("Team N°3"), "Unexpected Name");
    }
}