Public Class StandingManager

    Public Function GetStandings(finishedMatches As Match()) As Standing()
        Dim list = New Dictionary(Of Team, Standing)
        Dim setsWon(-1), points(-1), goals(-1) As Integer

        For Each finishedMatch In finishedMatches
            ReDim setsWon(1), points(1), goals(1)

            With finishedMatch
                If Not list.ContainsKey(.Team1) Then list.Add(.Team1, New Standing(.Team1))
                If Not list.ContainsKey(.Team2) Then list.Add(.Team2, New Standing(.Team2))

                For Each setResult In .Result.SetResults
                    Select Case setResult.Home.CompareTo(setResult.Guest)
                        Case Is > 0 : setsWon(0) += 1
                        Case Is < 0 : setsWon(1) += 1
                    End Select

                    goals(0) += setResult.Home
                    goals(1) += setResult.Guest
                Next setResult

                Select Case setsWon(0).CompareTo(setsWon(1))
                    Case Is > 0 : points(0) += 3
                    Case 0 : points(0) += 1 : points(1) += 1
                    Case Is < 0 : points(1) += 3
                End Select
            End With

            With list(finishedMatch.Team1)
                .MatchCount += 1
                .Points += points(0)
                .WonSetCount += setsWon(0)
                .Goals += goals(0)
                .GoalsAgainst += goals(1)
            End With
            With list(finishedMatch.Team2)
                .MatchCount += 1
                .Points += points(1)
                .WonSetCount += setsWon(1)
                .Goals += goals(1)
                .GoalsAgainst += goals(0)
            End With
        Next finishedMatch

        ' Set place numbers 
        Dim standings(list.Count - 1) As Standing

        Dim tempArray = Array.CreateInstance(GetType(Standing), list.Count)
        list.Values.CopyTo(tempArray, 0)                   ' Copy hashtable to array
        Array.Sort(tempArray)                       ' Sort 
        For index = 0 To tempArray.Length - 1
            standings(index) = CType(tempArray.GetValue(index), Standing)
            standings(index).Place = index + 1      ' Set place number
        Next index

        Return standings
    End Function

End Class
