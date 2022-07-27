Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports POFF.Kicker.Model

<TestClass()> Public Class MatchInfoTests

    <TestMethod()> Public Sub MatchInfoTest()
        ' Arrange
        Dim match = New Match(1, New Team() With {.Name = "Team 1"}, New Team() With {.Name = "Team 2"})
        match.Result.AddSetResult(New SetResult() With {.Home = 5, .Guest = 1})
        match.Result.AddSetResult(New SetResult() With {.Home = 5, .Guest = 2})

        ' Act
        Dim result = New MatchInfo(match)

        ' Assert
        Assert.AreEqual("Team 1", result.Team1Name, "Unexpected Team1Name")
        Assert.AreEqual("Team 2", result.Team2Name, "Unexpected Team2Name")
        Assert.AreEqual("5:1/5:2", result.ResultSummary, "Unexpected ResultSummary")
    End Sub

End Class