Public Class MatchManager

    Public Sub New()
        Load()
    End Sub

    Private Teams As Team()

    Private Matches(-1) As Match

    Public ReadOnly Property TotalMatchCount
        Get
            Return Matches.Length
        End Get
    End Property

    Public Sub Clear()
        ReDim Matches(-1)
    End Sub

    Public Sub Generate(teams As Team())
        If teams Is Nothing Then Return

        Dim startIndex As Integer

        Me.Teams = teams
        Dim teamCount = teams.Length
        Dim matchCount = CInt((teamCount - 1) * teamCount / 2)
        ReDim Matches(-1)                          ' Reset

        ' Build a section of one more than half the team count
        Dim sectionCount = CInt(teamCount / 2) + 1

        Do While Matches.Length < matchCount
            FindNextSectionMatch(startIndex, sectionCount)               ' Gruppe 1
            If sectionCount > 1 Then
                FindNextSectionMatch(startIndex + sectionCount - 1, sectionCount) ' Gruppe 2
            End If

            ' Change group zusammensetzung
            startIndex += 1
        Loop
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

    Private Sub FindNextSectionMatch(startIndex As Integer, groupCount As Integer)
        Dim team1Index, team2Index As Integer ' "real" index culculated from "circular" index (identical while cIndex<length)

        For team1CIndex = startIndex To startIndex + groupCount - 2
            team1Index = GetTeamIndex(Teams, team1CIndex)

            For team2CIndex = team1CIndex + 1 To startIndex + groupCount - 1
                team2Index = GetTeamIndex(Teams, team2CIndex)

                If Not MatchExists(team1Index, team2Index) Then
                    Dim MatchIndex As Integer = Matches.Length
                    ReDim Preserve Matches(MatchIndex)
                    Matches(MatchIndex) = New Match(MatchIndex + 1, Teams(team1Index), Teams(team2Index))
                    Return
                End If
            Next team2CIndex
        Next team1CIndex
    End Sub

    Private Function GetTeamIndex(teams As Team(), circularIndex As Integer) As Integer
        Dim index As Integer = circularIndex

        Do While Not index < teams.Length
            index = index - teams.Length
        Loop

        Return index
    End Function

    Private Function MatchExists(team1Index As Integer, team2Index As Integer) As Boolean
        For Each item In Matches
            If (Teams(team1Index).Equals(item.Team1) And Teams(team2Index).Equals(item.Team2)) _
               Or
               (Teams(team1Index).Equals(item.Team2) And Teams(team2Index).Equals(item.Team1)) _
               Then
                Return True ' Match found
            End If
        Next item

        Return False
    End Function

    Private Sub Load()
        Dim data As Object = Database.Load(GetType(Match()))
        If Not data Is Nothing Then Matches = CType(data, Match())
    End Sub

    Public Sub Save()
        Database.Save(GetType(Match()), Matches)
    End Sub

End Class
