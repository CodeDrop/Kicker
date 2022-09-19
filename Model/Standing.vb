Public Class Standing
    Implements IComparable

    Public Sub New(team As Team)
        Me.Team = team
    End Sub

    Public Property Place As Integer
    Public Property Team As Team
    Public Property Points As Integer
    Public Property Goals As Integer
    Public Property GoalsAgainst As Integer
    Public Property MatchCount As Integer
    Public Property WonSetCount As Integer

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Dim standing As Standing = CType(obj, Standing)

        If Me.Points <> standing.Points Then Return standing.Points.CompareTo(Points)
        If Me.WonSetCount <> standing.WonSetCount Then Return standing.WonSetCount.CompareTo(WonSetCount)
        If Me.Goals <> standing.Goals Then Return standing.Goals.CompareTo(Goals)
        If Me.GoalsAgainst <> standing.GoalsAgainst Then Return GoalsAgainst.CompareTo(standing.GoalsAgainst)

        Return 0
    End Function

    Public Overloads Function Equals(obj As Team) As Boolean
        Return CType(obj, Team).Equals(Team)
    End Function

End Class
