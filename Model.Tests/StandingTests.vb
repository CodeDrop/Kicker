Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> _
Public Class StandingTests

    <TestMethod()> _
    Public Sub StandingTest()
        ' Arrange
        Dim team = New Team(1)

        ' Act
        Dim result = New Standing(team)

        ' Assert
        Assert.AreSame(team, result.Team, "Unexpected Team")
    End Sub

End Class