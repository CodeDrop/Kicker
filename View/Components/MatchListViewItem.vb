Imports POFF.Kicker.Model

Namespace Components

    Public Class MatchListViewItem
        Inherits ListViewItem

        Public Sub New(match As Match)
            MyBase.New("", match.Status)
            Me.SubItems.Add("?")
            Me.SubItems.Add(match.Team1.Name)
            Me.SubItems.Add(match.Team2.Name)
            Me.SubItems.Add(match.Result.ToString)

            If match.Team1.Withdrawn Or match.Team2.Withdrawn Then
                Me.Font = New Font(Me.Font, FontStyle.Strikeout)
                Me.ForeColor = Color.LightGray
            End If

            MatchValue = match
        End Sub

        Private MatchValue As Match
        Public ReadOnly Property Match() As Match
            Get
                Return MatchValue
            End Get
        End Property

        Friend Sub RefreshNumber()
            SubItems(1).Text = $"{Index + 1}"
        End Sub

    End Class

End Namespace