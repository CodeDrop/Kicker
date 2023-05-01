Imports System.Text

Public Class HtmlExport

    Private ReadOnly Tournament As Tournament

    Public Sub New(tournament As Tournament)
        Me.Tournament = tournament
    End Sub

    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder(My.Resources.HtmlExportTemplate)

        SetSubtitel(builder)
        SetStandings(builder)
        SetGames(builder)

        My.Computer.Clipboard.SetText(builder.ToString())
        Return builder.ToString()
    End Function

    Private Sub SetSubtitel(builder As StringBuilder)
        Dim subtitle = $"Stand {Now:dd.M.yyyy} nach {Tournament.PlayedMatchCount()} von 153 Spielen"
        builder.Replace("<!-- Stand -->", subtitle)
    End Sub

    Private Sub SetStandings(builder As StringBuilder)
        Dim standingsBuilder As New StringBuilder()

        For Each standing As Standing In Tournament.GetStandings()
            ' <tr><td>1.</td><td>Spieler 1</td><td>3</td><td class="font-weight-bold">7</td></td><td>10:2</td></tr>
            standingsBuilder.Append("<tr>")
            standingsBuilder.Append($"<td>{standing.Place}</td>")
            standingsBuilder.Append($"<td>{standing.Team.Name}</td>")
            standingsBuilder.Append($"<td>{standing.MatchCount}</td>")
            standingsBuilder.Append($"<td class=""font-weight-bold"">{standing.Points}</td>")
            standingsBuilder.Append($"<td>{standing.Goals}:{standing.GoalsAgainst}</td>")
            standingsBuilder.Append("</tr>")
            standingsBuilder.Append(Environment.NewLine)
        Next standing

        builder.Replace("<!-- Tabelle -->", standingsBuilder.ToString())
    End Sub

    Private Sub SetGames(builder As StringBuilder)
        Dim gamesBuilder As New StringBuilder()

        For Each game As Match In Tournament.MatchManager.GetMatches()
            ' <tr><td>1</td><td>Spieler 1</td><td>Spieler 2</td><td>3:1</td></tr>
            gamesBuilder.Append("<tr>")
            gamesBuilder.Append($"<td>{game.Number}</td>")
            gamesBuilder.Append($"<td>{game.Team1.Name}</td>")
            gamesBuilder.Append($"<td>{game.Team2.Name}</td>")
            gamesBuilder.Append($"<td>{game.Result}</td>")
            gamesBuilder.Append("</tr>")
            gamesBuilder.Append(Environment.NewLine)
        Next game

        builder.Replace("<!-- Spiele -->", gamesBuilder.ToString())
    End Sub

End Class
