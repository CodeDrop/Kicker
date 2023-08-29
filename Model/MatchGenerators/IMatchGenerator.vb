Public Interface IMatchGenerator
    Function Generate(teamsCount As Integer) As IEnumerable(Of MatchIndexPair)
End Interface
