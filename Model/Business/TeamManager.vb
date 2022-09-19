Public Class TeamManager

    Public Sub New()
        Load()
    End Sub

    Private Teams(-1) As Team

    Public Function NewTeam() As Team
        Return New Team(Teams.Length + 1)
    End Function

    Public Sub AddTeam(team As Team)
        Dim index As Integer

        index = Teams.Length
        ReDim Preserve Teams(index)
        Teams(index) = team
    End Sub

    Public Sub RemoveTeam(teamToRemove As Team)
        Dim index As Integer

        For Each team In Teams
            If Not team.Equals(teamToRemove) Then
                Teams(index) = team
                index += 1
            End If
        Next team

        ReDim Preserve Teams(index - 1)
    End Sub

    Public Function GetTeams() As Team()
        Return Teams
    End Function

    Private Sub Load()
        Dim data As Object = Database.Load(GetType(Team()))
        If Not data Is Nothing Then Teams = CType(data, Team())
    End Sub

End Class