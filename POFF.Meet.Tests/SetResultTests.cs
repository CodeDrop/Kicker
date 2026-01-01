using NUnit.Framework;
using POFF.Meet.Domain;

namespace POFF.Meet.Tests;

[TestFixture]
public class SetResultTests
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