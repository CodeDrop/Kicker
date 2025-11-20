using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace View.IntegrationTest
{

    [TestClass()]
    public class AppWindowTests
    {

        private Application App;
        private Window Window;
        private MenuBar Menu;

        [TestInitialize]
        public void SetUp()
        {
            App = Application.Launch(@"..\..\..\View\bin\Kicker.exe");
            Window = App.GetWindow("POFF Kicker", InitializeOption.NoCache);
            Menu = Window.GetMenuBar(SearchCriteria.ByAutomationId("AppMainMenuStrip"));
        }

        [TestCleanup()]
        public void TearDown()
        {
            if (!Window.IsClosed)
            {
                Window.Close();
            }
        }

        [TestMethod()]
        public void ExitTest()
        {
            // Arrange
            // -

            // Act
            GetMenuItem(Menu, "Turnier").Click();
            GetMenuItem(Menu, "Beenden").Click();

            // Assert
            // (no error occurred)
        }

        [TestMethod()]
        public void NewTeamCancelTest()
        {
            // Arrange
            // -

            // Act
            GetMenuItem(Menu, "Turnier").Click();
            GetMenuItem(Menu, "Neue Mannschaft").Click();
            var window = App.GetWindows()[1];
            window.Get<Button>("AbortButton").Click();

            // Assert
            // (no error occurred)
        }

        private static Menu GetMenuItem(MenuBar menuBar, string menuItemName)
        {
            for (int i = 0, loopTo = menuBar.TopLevelMenu.Count - 1; i <= loopTo; i++)
            {
                if ((menuBar.TopLevelMenu[i].Name ?? "") == (menuItemName ?? ""))
                {
                    return menuBar.TopLevelMenu[i];
                }
            }

            Assert.Fail("menuItemName '{0}' not found", menuItemName);
            return null;
        }


    }
}