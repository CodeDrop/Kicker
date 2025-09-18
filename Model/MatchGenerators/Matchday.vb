Public Class Matchday
    Inherits List(Of MatchIndexPair)

    Public Function ContainsPlayerIn(match As MatchIndexPair) As Boolean
        Return Me.Any(Function(m) _
            m.Item1 = match.Item1 OrElse
            m.Item1 = match.Item2 OrElse
            m.Item2 = match.Item1 OrElse
            m.Item2 = match.Item2
        )
    End Function

    Public Function MatchesWithPlayersFrom(match As MatchIndexPair) As IEnumerable(Of MatchIndexPair)
        Return Me.Where(Function(m) _
            m.Item1 = match.Item1 OrElse
            m.Item1 = match.Item2 OrElse
            m.Item2 = match.Item1 OrElse
            m.Item2 = match.Item2
        )
    End Function
End Class
