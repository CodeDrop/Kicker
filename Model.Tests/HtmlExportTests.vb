<TestClass()>
Public Class HtmlExportTests

    <TestMethod>
    Public Sub ToStringTest()
        ' Arrange
        Dim tournament = New Tournament()
        Dim team1 = New Team(1)
        Dim team2 = New Team(2)
        tournament.AddTeam(team1)
        tournament.AddTeam(team2)
        tournament.MatchManager.Generate({team1, team2})
        Dim matchResult = New Result()
        matchResult.AddSetResult(New SetResult() With {.Home = 5, .Guest = 3})
        tournament.MatchManager.SetStatus(1, matchResult)
        Dim testClass = New HtmlExport(tournament)

        ' Act
        Dim result = testClass.ToString()

        ' Assert
        StringAssert.StartsWith(result, "{% extends 'base.html.twig' %}")
        StringAssert.Contains(result, "<h1>Club-Liga")
        StringAssert.EndsWith(result, "{% endblock %}")
    End Sub

End Class
