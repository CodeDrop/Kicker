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

    [Test]
    public void Team_ToString_returns_name()
    {
        var sut = new Team { Name = "Team A" };
        Assert.That(sut.ToString(), Is.EqualTo("Team A"));
    }
}