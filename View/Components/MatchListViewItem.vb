Imports POFF.Kicker.Model

Namespace Components

    Public Class MatchListViewItem
        Inherits ListViewItem

        Public Sub New(match As Match, Optional matchNo As Integer = 0)
            MyBase.New("", match.Status)
            SubItems.Add($"{matchNo}")
            SubItems.Add(match.Team1.Name)
            SubItems.Add(match.Team2.Name)
            SubItems.Add(match.Result.ToString)

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