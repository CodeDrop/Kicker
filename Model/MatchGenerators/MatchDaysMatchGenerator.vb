
Public Class MatchdaysMatchGenerator
    Implements IMatchGenerator
    Private ReadOnly _teamsCount As Integer
    Private ReadOnly _matches As New List(Of MatchIndexPair)()
    Private ReadOnly _matchdays As New List(Of Matchday)()

    Public Sub New(Optional teamsCount As Integer = 10)
        _teamsCount = teamsCount
    End Sub

    Public Function Generate() As IEnumerable(Of MatchIndexPair) Implements IMatchGenerator.Generate
        _matches.Clear()
        _matches.AddRange(GenerateMatches())
        _matchdays.Clear()
        _matchdays.AddRange(GenerateMatchdays())
        Return MatchIndexPairsOrderdByMatchdays()
    End Function

    Private Iterator Function MatchIndexPairsOrderdByMatchdays() As IEnumerable(Of MatchIndexPair)
        For Each matchday In _matchdays
            For Each matchIndexPair In matchday
                Yield matchIndexPair
            Next matchIndexPair
        Next matchday
    End Function

    Private Iterator Function GenerateMatches() As IEnumerable(Of MatchIndexPair)
        For i As Integer = 1 To _teamsCount
            For j As Integer = i + 1 To _teamsCount
                Yield New MatchIndexPair(i, j)
            Next
        Next
    End Function

    Private Iterator Function GenerateMatchdays() As IEnumerable(Of Matchday)
        Dim blockSize As Integer = _teamsCount \ 2

        For i As Integer = 0 To _teamsCount - 2
            Yield GenerateMatchday(blockSize)
        Next
    End Function

    Private Function GenerateMatchday(blockSize As Integer) As Matchday
        Dim matchday As New Matchday()
        While matchday.Count < blockSize
            Dim invalidatedMatches As New List(Of MatchIndexPair)()
            Dim nextMatch As MatchIndexPair = GetNextMatch(matchday)
            If nextMatch.Equals(MatchIndexPair.Empty) Then
                nextMatch = _matches.Except(invalidatedMatches).FirstOrDefault()
                If nextMatch Is Nothing Then nextMatch = MatchIndexPair.Empty
                invalidatedMatches.AddRange(matchday.MatchesWithPlayersFrom(nextMatch))
                _matches.AddRange(invalidatedMatches)
                matchday.RemoveAll(Function(m) invalidatedMatches.Contains(m))
            End If
            matchday.Add(nextMatch)
            _matches.Remove(nextMatch)
        End While
        Return matchday
    End Function

    Private Function GetNextMatch(matchday As Matchday) As MatchIndexPair
        If _matches.Count = 0 Then Return MatchIndexPair.Empty

        For i As Integer = 0 To _matches.Count - 1
            Dim match = _matches(i)
            If Not matchday.ContainsPlayerIn(match) Then
                Return match
            End If
        Next

        Return MatchIndexPair.Empty
    End Function
End Class
