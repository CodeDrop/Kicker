Imports POFF.Kicker.ViewModel.Interfaces

Namespace Types

    Friend Class DefaultConfirmationMessageHandler
        Implements IConfirmationMessage

        Private Sub New()
            '
        End Sub

        Public Shared Empty As IConfirmationMessage = New DefaultConfirmationMessageHandler()

        Public Function Confirm(message As String) As Boolean Implements IConfirmationMessage.Confirm
            Return True
        End Function

    End Class

End Namespace