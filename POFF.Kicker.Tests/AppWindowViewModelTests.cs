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
        Assert.AreEqual(0, result.TabIndex, "Unexpected TabIndex");
        Assert.IsNotNull(result.TeamsScreen, "TeamsScreen is null");
    }

    [Test]
    public void DITest()
    {
        // Arrange
        // -

        // Act
        var result = AppWindowViewModel.DI<TeamsScreenViewModel>();

        // Assert
        Assert.IsNotNull(result, "DI returned null");
    }

}