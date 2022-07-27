Imports POFF.Kicker.Model

Namespace Components

    Public Class TeamListViewItem
        Inherits ListViewItem

        Public Sub New(ByVal team As Team)
            MyBase.New("0")
            Me.SubItems.Add(team.Name)
            Me.SubItems.Add(team.Player1)
            Me.SubItems.Add(team.Player2)

            TeamValue = team
        End Sub

        Private ReadOnly TeamValue As Team
        Public ReadOnly Property Team() As Team
            Get
                Return TeamValue
            End Get
        End Property

    End Class

End Namespace