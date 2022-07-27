Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TestStack.White
Imports TestStack.White.Factory
Imports TestStack.White.UIItems
Imports TestStack.White.UIItems.Finders
Imports TestStack.White.UIItems.MenuItems
Imports TestStack.White.UIItems.WindowStripControls
Imports TestStack.White.UIItems.WindowItems

<TestClass()> Public Class AppWindowTests

    Private App As Application
    Private Window As Window
    Private Menu As MenuBar

    <TestInitialize> Public Sub SetUp()
        App = Application.Launch("..\..\..\View\bin\Kicker.exe")
        Window = App.GetWindow("POFF Kicker", InitializeOption.NoCache)
        Menu = Window.GetMenuBar(SearchCriteria.ByAutomationId("AppMainMenuStrip"))
    End Sub

    <TestCleanup()> Public Sub TearDown()
        If Not Window.IsClosed Then
            Window.Close()
        End If
    End Sub

    <TestMethod()> Public Sub ExitTest()
        ' Arrange
        ' -

        ' Act
        GetMenuItem(Menu, "Turnier").Click()
        GetMenuItem(Menu, "Beenden").Click()

        ' Assert
        ' (no error occurred)
    End Sub

    <TestMethod()> Public Sub NewTeamCancelTest()
        ' Arrange
        ' -

        ' Act
        GetMenuItem(Menu, "Turnier").Click()
        GetMenuItem(Menu, "Neue Mannschaft").Click()
        Dim window = App.GetWindows().Item(1)
        window.Get(Of Button)("AbortButton").Click()

        ' Assert
        ' (no error occurred)
    End Sub

    Private Shared Function GetMenuItem(menuBar As MenuBar, menuItemName As String) As Menu
        For i = 0 To menuBar.TopLevelMenu.Count - 1
            If menuBar.TopLevelMenu(i).Name = menuItemName Then
                Return menuBar.TopLevelMenu(i)
            End If
        Next i

        Assert.Fail("menuItemName '{0}' not found", menuItemName)
        Return Nothing
    End Function


End Class