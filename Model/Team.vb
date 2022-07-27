<Serializable()> _
Public Class Team

    Public Sub New()
        ' Default constructor needed for serialization
    End Sub

    Public Sub New(ByVal number As Integer)
        Name = String.Format("Team N°{0}", number)
    End Sub

    Public Property Name As String
    Public Property Player1 As String
    Public Property Player2 As String

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim otherTeam As Team = obj
        Return Me.Name.Equals(otherTeam.Name)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Name.GetHashCode()
    End Function

End Class