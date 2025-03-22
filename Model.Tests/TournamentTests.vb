<TestClass()> Public Class TournamentTests

    <TestMethod()> Public Sub TournamentTest()
        ' Arrange
        ' -

        ' Act
        Dim result = New Tournament()

        ' Assert
        Assert.IsNotNull(result.TeamManager, "TeamManager is null")
        Assert.IsNotNull(result.MatchManager, "MatchManager is null")
    End Sub

    <TestMethod()> Public Sub GetStandingsTest()
        ' Arrange
        Dim testClass As Tournament = CreateTournementWith2Teams()

        ' Act
        Dim result = testClass.GetStandings()

        ' Assert
        Assert.IsNotNull(result, "GetStandings returned null")
        Assert.AreEqual(2, result.Count, "Unexpected Count")
    End Sub

    Private Shared Function CreateTournementWith2Teams() As Tournament
        Dim result = New Tournament()
        Dim team1 = New Team(1)
        Dim team2 = New Team(2)
        result.AddTeam(team1)
        result.AddTeam(team2)
        result.MatchManager.Generate({team1, team2})
        Dim matchResult = New Result()
        matchResult.AddSetResult(New SetResult() With {.Home = 5, .Guest = 3})
        result.MatchManager.SetStatus(1, matchResult)
        Return result
    End Function

    <TestMethod()> Public Sub ExportTest()
        Dim testClass = CreateTournementWith2Teams()
        testClass.Export()
    End Sub

End Class