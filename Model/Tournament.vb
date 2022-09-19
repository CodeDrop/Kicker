Imports System.Text

Public Class Tournament

    Public Sub New()
        TeamManager = New TeamManager()
        MatchManager = New MatchManager()
        StandingManager = New StandingManager()
    End Sub

    Private ReadOnly StandingManager As StandingManager

    Public ReadOnly Property TeamManager() As TeamManager

    Public ReadOnly Property MatchManager() As MatchManager

    Public Sub Start()
        MatchManager.Generate(GetTeams())
    End Sub

    Public ReadOnly Property TotalMatchCount As Integer
        Get
            Return MatchManager.TotalMatchCount
        End Get
    End Property

    Public Function PlayedMatchCount() As Integer
        Return MatchManager.GetMatches(MatchStatus.Finished).Length
    End Function

    Public ReadOnly Property GetTeams() As Team()
        Get
            Return TeamManager.GetTeams()
        End Get
    End Property

    Public Sub AddTeam(team As Team)
        TeamManager.AddTeam(team)
        MatchManager.Clear()
    End Sub

    Public Sub RemoveTeam(team As Team)
        If team Is Nothing Then Throw New ArgumentNullException("team")

        TeamManager.RemoveTeam(team)
        MatchManager.Clear()
    End Sub

    Public Sub Save()
        Database.Save(GetType(Team()), TeamManager.GetTeams())
        MatchManager.Save()
    End Sub

    Public Function GetStandings() As IEnumerable(Of Standing)
        Return StandingManager.GetStandings(MatchManager.GetMatches(MatchStatus.Finished))
    End Function

    Public Sub CopyStandingsHtmlToClipboard()
        Dim builder As New StringBuilder()

        For Each standing As Standing In GetStandings()
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

        My.Computer.Clipboard.SetText(builder.ToString())
    End Sub

End Class
