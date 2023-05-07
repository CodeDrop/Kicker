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
        Dim subtitle = $"Stand {Now:d.M.yyyy} nach {Tournament.PlayedMatchCount()} von {Tournament.TotalMatchCount()} Spielen"
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

        For Each match As Match In Tournament.MatchManager.GetMatches()
            If ContainsWithdrawnTeam(match) Then Continue For
            ' <tr><td>1</td><td>Spieler 1</td><td>Spieler 2</td><td>3:1</td></tr>
            gamesBuilder.Append("<tr>")
            gamesBuilder.Append($"<td>{match.Number}</td>")
            gamesBuilder.Append($"<td>{match.Team1.Name}</td>")
            gamesBuilder.Append($"<td>{match.Team2.Name}</td>")
            gamesBuilder.Append($"<td>{match.Result}</td>")
            gamesBuilder.Append("</tr>")
            gamesBuilder.Append(Environment.NewLine)
        Next match

        builder.Replace("<!-- Spiele -->", gamesBuilder.ToString())
    End Sub

    Private Function ContainsWithdrawnTeam(match As Match) As Boolean
        Dim team1 = Tournament.GetTeams().Single(Function(t) t.Equals(match.Team1))
        Dim team2 = Tournament.GetTeams().Single(Function(t) t.Equals(match.Team2))
        Return team1.Withdrawn Or team2.Withdrawn
    End Function

End Class
