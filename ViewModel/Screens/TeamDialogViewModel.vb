Imports POFF.Kicker.ViewModel.Types

Namespace Screens

    Public Class TeamDialogViewModel

        Public Sub New(teamInfo As TeamInfo)
            ' Check parameters
            If teamInfo Is Nothing Then Throw New ArgumentNullException("teamInfo")

            ' Initialize members
            TeamInfoValue = teamInfo
        End Sub

        Private ReadOnly TeamInfoValue As TeamInfo
        Private ReadOnly Property TeamInfo As TeamInfo
            Get
                Return TeamInfoValue
            End Get
        End Property

        Public Sub AcceptChanges()
            TeamInfo.AcceptChanges()
        End Sub

    End Class

End Namespace