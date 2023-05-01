Imports System.Text

Public Class HtmlExport

    Private ReadOnly Tournament As Tournament

    Public Sub New(tournament As Tournament)
        Me.Tournament = tournament
    End Sub

    Public Overrides Function ToString() As String
        Dim builder As New StringBuilder(My.Resources.HtmlExportTemplate)

        AddStandings(builder)

        My.Computer.Clipboard.SetText(builder.ToString())
        Return builder.ToString()
    End Function

    Private Sub AddStandings(builder As StringBuilder)
        Dim standingsBuilder As New StringBuilder()

        For Each standing As Standing In Tournament.GetStandings()
            ' <tr><td>1.</td><td>Florian Kapfhammer</td><td>3</td><td class="font-weight-bold">7</td></td><td>10:2</td></tr>
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
End Class
