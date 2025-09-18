Public Class MatchIndexPair
    Inherits Tuple(Of Integer, Integer)

    Public Shared ReadOnly Empty As MatchIndexPair = New MatchIndexPair(0, 0)

    Public Sub New(team1Index As Integer, team2Index As Integer)
        MyBase.New(team1Index, team2Index)
    End Sub

    Public Overrides Function GetHashCode() As Integer
        Return Item1.GetHashCode() Or Item2.GetHashCode()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse TypeOf obj IsNot MatchIndexPair Then Return False
        With CType(obj, MatchIndexPair)
            Return (Item1 = .Item1 AndAlso Item2 = .Item2) OrElse (Item1 = .Item2 AndAlso Item2 = .Item1)
        End With
    End Function

    Public Function ContainsTeamOf(other As MatchIndexPair) As Boolean
        Return Item1 = other.Item1 OrElse Item1 = other.Item2 _
            OrElse Item2 = other.Item2 OrElse Item2 = other.Item1
    End Function

    Public Overrides Function ToString() As String
        Return $"{Item1} - {Item2}"
    End Function

End Class
