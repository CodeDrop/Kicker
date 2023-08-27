Public Interface IMatchGenerator
    Function Generate(teamsCount As Integer) As IEnumerable(Of Tuple(Of Integer, Integer))
End Interface
