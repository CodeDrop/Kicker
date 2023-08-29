Public Class MatchDaysMatchGenerator
    Implements IMatchGenerator

    Public Function Generate(teamsCount As Integer) As IEnumerable(Of MatchIndexPair) Implements IMatchGenerator.Generate
        Dim matchIndexes = GetAllMatches(teamsCount)
        Dim matchesPerRound = GetMatchesPerRound(teamsCount)
        Return Shuffle(matchIndexes, matchesPerRound)
    End Function

    Private Iterator Function Shuffle(matchIndexes As IEnumerable(Of MatchIndexPair), matchesPerRound As Integer) As IEnumerable(Of MatchIndexPair)
        Dim round = New List(Of MatchIndexPair)(matchesPerRound)
        Dim processedMatches = New List(Of MatchIndexPair)(matchIndexes.Count())

        Do While processedMatches.Count < matchIndexes.Count
            round.Clear()
            Dim eliminationMatch = Nothing
            Dim availableMatches = matchIndexes.Except(processedMatches).ToList()

            Do While round.Count < matchesPerRound

                For Each matchIndexPair In availableMatches
                    If round.Count = matchesPerRound Then Exit For
                    If Not round.Any(Function(m) m.ContainsTeamOf(matchIndexPair)) _
                        AndAlso Not matchIndexPair.Equals(eliminationMatch) Then
                        round.Add(matchIndexPair)
                    End If
                Next matchIndexPair

                If round.Count < matchesPerRound Then
                    Dim eliminationMatchIndex = If(eliminationMatch IsNot Nothing, round.IndexOf(eliminationMatch) + 1, 0)
                    eliminationMatch = round.ElementAt(eliminationMatchIndex)
                    round.Remove(eliminationMatch)
                End If
            Loop

            For Each matchIndexPair In round
                Yield matchIndexPair
            Next matchIndexPair

            processedMatches.AddRange(round)
        Loop
    End Function

    Private Function GetMatchesPerRound(teamsCount As Integer) As Integer
        Return Math.Floor(teamsCount / 2)
    End Function

    Private Shared Function GetAllMatches(teamsCount As Integer) As IEnumerable(Of MatchIndexPair)
        Dim matchIndexes = New List(Of MatchIndexPair)
        Dim diff = 0

        For i = 1 To Math.Floor(teamsCount / 2)
            diff += 1
            For t1 = 0 To teamsCount - 1
                Dim t2 = If(t1 + diff < teamsCount, t1 + diff, t1 + diff - teamsCount)
                matchIndexes.Add(New MatchIndexPair(t1, t2))
            Next t1
        Next i

        Return matchIndexes.Distinct()
    End Function

    Private Function GetRoundsCount(teamsCount As Integer) As Integer
        ' 0->0, 1->0, 2->1, 3->2, 4->3, 5->5, 6->5
        Return If(teamsCount < 2, 0, teamsCount - 1 + teamsCount Mod 2)
    End Function

    Private Function GetMatchCount(teamsCount As Integer) As Integer
        ' 0->0, 1->0, 2->1, 3->3, 5->10
        Return (teamsCount - 1) * teamsCount / 2
    End Function

End Class

#Region "Match Index overview"

' - 2 -
' 1:2

' - 3 -
' 1*
' 2:3

' 2*
' 1:3

' 3*
' 1:2

' - 4 -
' 1:2
' 3:4

' 1:3
' 2:4

' 1:4
' 2:3

' - 5 -
' 1*
' 2:3
' 4:5

' 2*
' 1:4
' 3:5

' 3*
' 1:5
' 2:4

' 4*
' 1:3
' 2:5

' 5*
' 1:2
' 3:4

' - 6 -
' 1:2
' 3:4
' 5:6

' 1:3  
' 2:5  
' 4:6  

' 1:4  
' 2:6  
' 3:5  

' 1:5  
' 2:4  
' 3:6        

' 1:6  
' 2:3  
' 4:5  

' 1 - 2 - 3 - 4 - 5 - 6    
'----------------------
' 2 - 3 - 4 - 5 - 6 
' 3 - 4 - 5 - 6 
' 4 - 5 - 6  
' 5 - 6 
' 6


' 1 - 2 - 3
' 4 - 5 - 6 

' 2 - 4 - 6
' 1 - 3 - 5 

' 3 - 6 - 4
' 1 - 2 - 5

' 4 - 2 - 6
' 2 - 5 - 6


' 3 - 4 - 5 - 6 - 1 
' 4 - 5 - 6 - 1 - 2 
' 5 - 6 - 1 - 2 - 3

' 1 - 2 - 3 - 4 - 5
' 2 - 3 - 4 - 5 
' 3 - 4 - 5 - 1 
' 4 - 5 - 1 - 2 
' 5 - 1 - 2 - 3

' <summary>
' Generiert anhand der übergebenen Teilnehmer die Spielpaarungen.
' </summary>
' <param name="bTeilnehmer">Aktuelle Teilnehmer</param>
' <returns>Generierte Spielpaarungen</returns>
' <remarks>
' Vorgehensweise:
' Man nehme zum Beispiel 5 Teams und stelle diese in eine Zeile 1234567
' Runde 1 besitzt den Abstand 1. Das heißt, der Algorithmus geht von links nach rechts jeden einzelnen Eintrag durch
' und bildet mit seinem rechten Nachbarn eine Spielpaarung: 1-2, 2-3, 3-4, 4-5, 5-6, 6-7, 7-1
' Runde 2 besitzt den Abstand 2. Auch hier geht der Algorithmus von links nach rechts jeden einzelnen Eintrag durch,
' bildet aber mit jedem zweiten Nachbarn eine Spielpaarung: 1-3, 2-4, 3-5, 4-6, 5-7, 6-1, 7-2
' Und schließlich in Runde 3 (der letzten Runde) besitzt der Abstand den Wert 3. Gleiche Vorgehensweise, allerdings unterschiedliche
' Schrittanzahl, sofern die Teilnehmerzahl 6 betragen würde. Bei gerader Teilnehmerzahl ist die Schrittzahl die halbe Teilnehmerzahl,
' bei ungerader Teilnehmerzahl ändert sich nichts. Es werden also in diesem Beispiel die Spielpaarungen 1-4, 2-5, 3-6, 4-7, 5-1
' und 6-2 gebildet.
' Die Gesamtanzahl der Runden beträgt immer die Hälfte der Teilnehmerzahl (abgerundet), wobei bei der letzten Runde immer die in
' Runde 3 beschriebene Sonderregel beachtet werden muss.
' Ergbnis:
' Man erhält eine Jeder-gegen-Jeden-Generierung mit ausbalanciertem Heim- und Auswärtsspielpaarungen. Einziges Manko dieses Algorithmus
' ist die erste Runde, in der die Reihenfolge 1-2, 3-4, 5-6, 7-1, 2-3, 4-5, 6-7 sinnvoller gewesen wäre, da die Durchführung nicht
' von einem bereits spielenden Team blockiert wird. Dies lässt sich allerdings im Anschluss sehr leicht korrigieren, worauf in
' diesem Beispiel erstmal verzichtet worden ist. Auch könnte die Streuung der Partien, damit manche Spielpausen nicht zu lang sind,
' anspassen.
' Wichtig: Es findet keine Neuinitialisierung statt. Würde diese Methode ein weiteres Mal aufgerufen werden, werden die Punkte, Tore und
' alles andere draufaddiert.
' </remarks>
#End Region
