Imports System.Text

Public Class HtmlExport

    Private ReadOnly Tournament As Tournament

    Public Sub New(tournament As Tournament)
        Me.Tournament = tournament
    End Sub

    Private Sub AddStandings(builder As StringBuilder)

        For Each standing As Standing In Tournament.GetStandings()
            ' <tr><td>1.</td><td>Florian Kapfhammer</td><td>3</td><td class="font-weight-bold">7</td></td><td>10:2</td></tr>
            builder.Append("<tr>")
            builder.Append($"<td>{standing.Place}</td>")
            builder.Append($"<td>{standing.Team.Name}</td>")
            builder.Append($"<td>{standing.MatchCount}</td>")
            builder.Append($"<td class=""font-weight-bold"">{standing.Points}</td>")
            builder.Append($"<td>{standing.Goals}:{standing.GoalsAgainst}</td>")
            builder.Append("</tr>")
            builder.Append(Environment.NewLine)
        Next standing
    End Sub

    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder()

        AddStandings(builder)

        My.Computer.Clipboard.SetText(builder.ToString())
        Return builder.ToString()
    End Function

End Class
