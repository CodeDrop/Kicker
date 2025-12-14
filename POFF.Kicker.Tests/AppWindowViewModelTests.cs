using NUnit.Framework;
using POFF.Kicker.View;

namespace POFF.Kicker.Tests;

[TestFixture]
class AppWindowViewModelTests
{
    [Test]
    public void InstanceTest()
    {
        // Arrange
        // -

        // Act
        var result = AppWindowViewModel.Instance;

        // Assert
        Assert.That(result.TabIndex, Is.EqualTo(0), "Unexpected TabIndex");
        Assert.That(result.TeamsScreen, Is.Not.Null, "TeamsScreen is null");
    }
}