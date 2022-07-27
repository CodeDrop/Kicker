Imports POFF.Kicker.Model

Namespace Types

    Public Class SetResultInput

        Public Sub New()
            HomeValue = Nothing
            GuestValue = Nothing
        End Sub

        Public Sub New(setResult As SetResult)
            If setResult Is Nothing Then Throw New ArgumentNullException("setResult")

            HomeValue = setResult.Home
            GuestValue = setResult.Guest
        End Sub

        Private HomeValue As Integer?
        Public Property Home As Integer?
            Get
                Return HomeValue
            End Get
            Set(value As Integer?)
                HomeValue = value
            End Set
        End Property

        Private GuestValue As Integer?
        Public Property Guest As Integer?
            Get
                Return GuestValue
            End Get
            Set(value As Integer?)
                GuestValue = value
            End Set
        End Property

    End Class

End Namespace