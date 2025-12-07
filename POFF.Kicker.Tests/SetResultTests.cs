using NUnit.Framework;
using POFF.Kicker.Domain;

namespace POFF.Kicker.Tests;

[TestFixture]
class SetResultTests
{
    [Test]
    public void ToStringTest()
    {
        // Arrange
        var setResult = new SetResult() { Home = 5, Guest = 3 };

        // Act
        string result = setResult.ToString();

        // Assert
        Assert.That(result, Is.EqualTo("5:3"), "Unexpected result");
    }
}