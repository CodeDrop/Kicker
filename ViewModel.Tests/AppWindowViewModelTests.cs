using Microsoft.VisualStudio.TestTools.UnitTesting;
using POFF.Kicker.ViewModel.Screens;

namespace POFF.Kicker.ViewModel
{

    [TestClass()]
    public class AppWindowViewModelTests
    {

        [TestMethod()]
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

        [TestMethod()]
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
}