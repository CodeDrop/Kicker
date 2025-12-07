using NUnit.Framework;
using POFF.Kicker.Domain;

namespace POFF.Kicker.Tests;

[TestFixture]
class ResultTests
{
    [Test]
    public void AddSetResultTest()
    {
        // Arrange
        var result = new Result();
        var setResult = new SetResult() { Home = 5, Guest = 2 };

        // Act
        result.AddSetResult(setResult);

        // Assert
        Assert.That(result.SetResults, Is.Not.Null, "SetResults is null");
        Assert.That(result.SetResults.Length, Is.EqualTo(1), "Unexpected number of SetResults");
        Assert.That(result.SetResults[0].Home, Is.EqualTo(5), "Unexpected SetResults[0].Home");
        Assert.That(result.SetResults[0].Guest, Is.EqualTo(2), "Unexpected SetResults[0].Guest");
    }
}