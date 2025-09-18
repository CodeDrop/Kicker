Public Class MatchManager

    Public Sub New()
        Load()
    End Sub

    Private Matches(-1) As Match

    Public Sub Clear()
        ReDim Matches(-1)
    End Sub

    Public Sub Generate(teams As Team(), Optional type As TournamentType = TournamentType.Standard)
        If teams Is Nothing Then Return

        Dim matchGenerator As IMatchGenerator
        If type = TournamentType.MatchDays Then
            matchGenerator = New MatchDaysMatchGenerator(teams.Count)
        Else
            matchGenerator = New GeneticMatchGenerator(teams.Count)
        End If

        Dim matchIndexes = matchGenerator.Generate()
        ReDim Matches(matchIndexes.Count - 1) ' Reset
        Dim matchNumber = 1

        For Each matchIndexPair In matchIndexes
            Matches(matchNumber - 1) = New Match(matchNumber, teams(matchIndexPair.Item1), teams(matchIndexPair.Item2))
            matchNumber += 1
        Next matchIndexPair
    End Sub

    ' Get next match with fitting status
    Public Function GetNextMatch() As Match
        Dim runningMatch As Match
        Dim teamConflict As Boolean

        For Each match In Matches
            If match.Status = MatchStatus.Open Then
                teamConflict = False

                For Each runningMatch In GetMatches(MatchStatus.Running)
                    teamConflict = runningMatch.HasTeam(match.Team1) Or runningMatch.HasTeam(match.Team2)
                    If teamConflict Then Exit For
                Next runningMatch

                If Not teamConflict Then Return match
            End If
        Next match

        Return Nothing
    End Function

    ' Get all matches
    Public Function GetMatches() As Match()
        Return Matches
    End Function

    ' Get matches depending on running status
    Public Function GetMatches(matchStatus As MatchStatus) As Match()
        Dim matchesInStatus = New List(Of Match)

        For index = 0 To Matches.Length - 1
            If Matches(index).Status = matchStatus Then
                matchesInStatus.Add(Matches(index))
            End If
        Next index

        Return matchesInStatus.ToArray()
    End Function

    Public Sub SetStatus(matchNo As Integer, result As Result)
        SetStatus(matchNo, MatchStatus.Finished)
        Matches(matchNo - 1).Result = result
    End Sub

    Private Sub SetStatus(matchNo As Integer, matchStatus As MatchStatus)
        If matchNo < 1 Or matchNo > Matches.Length Then Throw New IndexOutOfRangeException("matchNo may only have values between 1 and number of matches")
        Matches(matchNo - 1).Status = matchStatus
    End Sub

    Private Sub Load()
        Dim data As Object = Database.Load(GetType(Match()))
        If Not data Is Nothing Then Matches = CType(data, Match())
    End Sub

    Public Sub Save()
        Database.Save(GetType(Match()), Matches)
    End Sub

End Class
