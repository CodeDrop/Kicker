Imports POFF.Kicker.Model

Namespace Components

    Public Class StandingListViewItem
        Inherits ListViewItem

        Public Sub New(standing As Standing)
            MyBase.New(standing.Place.ToString)
            With standing
                Me.SubItems.Add(.Team.Name)
                Me.SubItems.Add(.Points.ToString)
                Me.SubItems.Add(.WonSetCount.ToString)
                Me.SubItems.Add(String.Format("{0}:{1}", .Goals, .GoalsAgainst))
                Me.SubItems.Add(.MatchCount.ToString)
            End With

            StandingValue = standing
        End Sub

        Private ReadOnly StandingValue As Standing
        Public ReadOnly Property Standing() As Standing
            Get
                Return StandingValue
            End Get
        End Property

    End Class

End Namespace