Public Class Tournament

    Public Sub New()
        TeamManager = New TeamManager()
        MatchManager = New MatchManager()
        StandingManager = New StandingManager()
    End Sub

    Private ReadOnly StandingManager As StandingManager

    Public ReadOnly Property TeamManager() As TeamManager

    Public ReadOnly Property MatchManager() As MatchManager

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

End Class
