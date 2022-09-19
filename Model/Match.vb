<Serializable()> _
Public Class Match

    Friend Sub New()
        '
    End Sub

    Public Sub New(number As Integer, team1 As Team, team2 As Team)
        Me.Number = number
        Me.Team1 = team1
        Me.Team2 = team2
        Me.Result = New Result()
    End Sub

    Public Property Number As Integer
    Public Property Team1 As Team
    Public Property Team2 As Team
    Public Property Status As MatchStatus
    Public Property Result As Result

    Public Function HasTeam(team As Team) As Boolean
        If Team1.Equals(team) Then Return True
        If Team2.Equals(team) Then Return True
        Return False
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Spiel {0}: {2} vs. {3}", Number, Team1.Name, Team2.Name)
    End Function

    Public Overloads Function Equals(obj As Object) As Boolean
        With CType(obj, Match)
            If .Team1.Name <> Me.Team1.Name AndAlso .Team1.Name <> Me.Team2.Name Then Return False
            If .Team2.Name <> Me.Team1.Name AndAlso .Team2.Name <> Me.Team2.Name Then Return False

            Return True
        End With
    End Function

End Class
