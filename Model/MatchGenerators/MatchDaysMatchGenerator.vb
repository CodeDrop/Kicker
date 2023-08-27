Public Class MatchDaysMatchGenerator
    Implements IMatchGenerator

    Public Function Generate(teamsCount As Integer) As IEnumerable(Of Tuple(Of Integer, Integer)) Implements IMatchGenerator.Generate
        Dim matchIndexes = New List(Of Tuple(Of Integer, Integer))
        For t1 = 0 To teamsCount - 1
            For t2 = t1 + 1 To teamsCount - 1
                matchIndexes.Add(New Tuple(Of Integer, Integer)(t1, t2))
            Next t2
        Next t1
        Return matchIndexes
    End Function

End Class
