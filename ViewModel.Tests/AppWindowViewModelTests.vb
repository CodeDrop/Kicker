Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports POFF.Kicker.ViewModel.Screens

<TestClass()> Public Class AppWindowViewModelTests

    <TestMethod()> Public Sub InstanceTest()
        ' Arrange
        ' -

        ' Act
        Dim result = AppWindowViewModel.Instance

        ' Assert
        Assert.AreEqual(0, result.TabIndex, "Unexpected TabIndex")
        Assert.IsNotNull(result.TeamsScreen, "TeamsScreen is null")
    End Sub

    <TestMethod()> Public Sub DITest()
        ' Arrange
        ' -

        ' Act
        Dim result = AppWindowViewModel.DI(Of TeamsScreenViewModel)()

        ' Assert
        Assert.IsNotNull(result, "DI returned null")
    End Sub

End Class