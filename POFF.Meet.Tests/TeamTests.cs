using NUnit.Framework;
using POFF.Meet.Domain;

namespace POFF.Meet.Tests;

[TestFixture]
public class TeamTests
{
    [Test]
    public void TeamTest()
    {
        // Act
        var result = new Team();

        // Assert
        Assert.That(result.Name, Is.Empty);
    }
}