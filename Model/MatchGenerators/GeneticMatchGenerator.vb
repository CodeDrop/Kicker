Public Class GeneticMatchGenerator
    Implements IMatchGenerator

    Private Matches As New List(Of MatchIndexPair)
    Private ReadOnly _teamsCount As Integer

    Public Sub New(teamsCount As Integer)
        _teamsCount = teamsCount
    End Sub

    Public Function Generate() As IEnumerable(Of MatchIndexPair) Implements IMatchGenerator.Generate
        Dim startIndex As Integer
        Dim matchCount = CInt((_teamsCount - 1) * _teamsCount / 2)
        Matches.Clear()

        ' Build a section of one more than half the team count
        Dim sectionCount = CInt(_teamsCount / 2) + 1

        Do While Matches.Count < matchCount
            Dim matchNumber = Matches.Count + 1
            FindNextSectionMatch(matchNumber, startIndex, sectionCount)               ' Gruppe 1
            If sectionCount > 1 Then
                FindNextSectionMatch(matchNumber, startIndex + sectionCount - 1, sectionCount) ' Gruppe 2
            End If

            ' Change group zusammensetzung
            startIndex += 1
        Loop

        Return Matches
    End Function

    Private Sub FindNextSectionMatch(matchNumber As Integer, startIndex As Integer, groupCount As Integer)
        Dim team1Index, team2Index As Integer ' "real" index calculated from "circular" index (identical while cIndex<length)

        For team1CIndex = startIndex To startIndex + groupCount - 2
            team1Index = GetTeamIndex(_teamsCount, team1CIndex)

            For team2CIndex = team1CIndex + 1 To startIndex + groupCount - 1
                team2Index = GetTeamIndex(_teamsCount, team2CIndex)

                If Not MatchExists(team1Index, team2Index) Then
                    Dim matchIndexPair = New MatchIndexPair(team1Index, team2Index)

                    If Matches.Count < matchNumber Then
                        Matches.Add(matchIndexPair)
                    Else
                        Matches(matchNumber - 1) = matchIndexPair
                    End If
                    Return
                End If
            Next team2CIndex
        Next team1CIndex
    End Sub

    Private Function GetTeamIndex(teamsCount As Integer, circularIndex As Integer) As Integer
        Dim index As Integer = circularIndex

        Do While Not index < teamsCount
            index = index - teamsCount
        Loop

        Return index
    End Function

    Private Function MatchExists(team1Index As Integer, team2Index As Integer) As Boolean
        For Each matchIndexPair In Matches
            If (team1Index = matchIndexPair.Item1 And team2Index = matchIndexPair.Item2) _
               Or
               (team1Index = matchIndexPair.Item2 And team2Index = matchIndexPair.Item1) _
               Then
                Return True ' Match found
            End If
        Next matchIndexPair

        Return False
    End Function

End Class
