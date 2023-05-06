Imports System.Text.RegularExpressions

<TestClass()>
Public Class HtmlExportTests

    Private Shared Result As String

    <ClassInitialize>
    Public Shared Sub SetUp(testContext As TestContext)
        ' Arrange
        Dim tournament = New Tournament()
        Dim team1 = New Team(1)
        Dim team2 = New Team(2)
        Dim team3 = New Team(3) With {.Withdrawn = True}
        tournament.AddTeam(team1)
        tournament.AddTeam(team2)
        tournament.AddTeam(team3)
        tournament.MatchManager.Generate({team1, team2, team3})
        Dim matchResult = New Result()
        matchResult.AddSetResult(New SetResult() With {.Home = 5, .Guest = 3})
        tournament.MatchManager.SetStatus(1, matchResult)
        Dim testClass = New HtmlExport(tournament)

        ' Act
        Result = testClass.ToString()
    End Sub

    <TestMethod>
    Public Sub HeaderTest()
        StringAssert.StartsWith(Result, "{% extends 'base.html.twig' %}")
    End Sub

    <TestMethod>
    Public Sub TitleTest()
        StringAssert.Contains(Result, "<h1>Club-Liga")
    End Sub

    <TestMethod>
    Public Sub SubtitleTest()
        StringAssert.Contains(Result, " nach 1 von ")
    End Sub

    <TestMethod>
    Public Sub StandingTest()
        StringAssert.Contains(Result, "<td>Team N°1</td>")
    End Sub

    <TestMethod>
    Public Sub GamesTest()
        StringAssert.Contains(Result, "<td>Team N°1</td><td>Team N°2</td><td>5:3</td>")
    End Sub

    <TestMethod>
    Public Sub GamesOfWithdrawnTeam()
        Dim pattern As New Regex("<td>Team N°3</td>")
        StringAssert.DoesNotMatch(Result, pattern)
    End Sub

    <TestMethod>
    Public Sub FooterTest()
        StringAssert.EndsWith(Result, "{% endblock %}")
    End Sub

End Class
