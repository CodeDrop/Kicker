<Serializable()> _
Public Class Result

    Public SetResults(-1) As SetResult

    Public Sub AddSetResult(setResult As SetResult)
        If setResult Is Nothing Then Throw New ArgumentNullException("setResultRow")

        Dim goalCount1, goalCount2 As Integer

        If IsNumeric(setResult.Home) Then goalCount1 = Integer.Parse(setResult.Home)
        If IsNumeric(setResult.Guest) Then goalCount2 = Integer.Parse(setResult.Guest)

        ReDim Preserve Me.SetResults(SetResults.Length)
        Me.SetResults(SetResults.Length - 1) = New SetResult()
        Me.SetResults(SetResults.Length - 1).Home = goalCount1
        Me.SetResults(SetResults.Length - 1).Guest = goalCount2
    End Sub

    Public Sub Clear()
        ReDim Preserve Me.SetResults(-1)
    End Sub

    Public Overrides Function ToString() As String
        If SetResults.Length = 0 Then Return ""

        Dim resultString = New Text.StringBuilder()

        For Each setResult In SetResults
            resultString.AppendFormat("/{0}", setResult)
        Next setResult

        Return resultString.ToString.Substring(1)
    End Function

End Class
