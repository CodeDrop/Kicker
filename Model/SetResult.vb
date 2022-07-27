<Serializable()> _
Public Class SetResult

    Public Property Home As Integer
    Public Property Guest As Integer

    Public Overrides Function ToString() As String
        Return String.Format("{0}:{1}", Home, Guest)
    End Function
End Class
