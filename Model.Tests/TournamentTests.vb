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
        Dim testClass = New Tournament()
        Dim team1 = New Team(1)
        Dim team2 = New Team(2)
        testClass.AddTeam(team1)
        testClass.AddTeam(team2)
        testClass.MatchManager.Generate({team1, team2})
        Dim matchResult = New Result()
        matchResult.AddSetResult(New SetResult() With {.Home = 5, .Guest = 3})
        testClass.MatchManager.SetStatus(1, matchResult)

        ' Act
        Dim result = testClass.GetStandings()

        ' Assert
        Assert.IsNotNull(result, "GetStandings returned null")
        Assert.AreEqual(2, result.Count, "Unexpected Count")
    End Sub

End Class