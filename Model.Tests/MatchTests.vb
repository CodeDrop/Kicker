Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class MatchTests

    <TestMethod()>
    Public Sub MatchTest()
        ' Arrange
        Dim team1 = New Team(1)
        Dim team2 = New Team(2)
        Const number = 19

        ' Act
        Dim result = New Match(number, team1, team2)

        ' Assert
        Assert.AreEqual(number, result.Number, "Unexpected Number")
        Assert.AreSame(team1, result.Team1, "Unexpected Team1")
        Assert.AreSame(team2, result.Team2, "Unexpected Team2")
    End Sub

End Class