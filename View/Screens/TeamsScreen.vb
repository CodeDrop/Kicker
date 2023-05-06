Imports POFF.Kicker.ViewModel
Imports POFF.Kicker.ViewModel.Screens
Imports POFF.Kicker.Model
Imports POFF.Kicker.ViewModel.Interfaces
Imports POFF.Kicker.ViewModel.Types

Namespace Screens

    Public Class TeamsScreen
        Implements IConfirmationMessage

        Public Sub New()

            ' Dieser Aufruf ist für den Designer erforderlich.
            InitializeComponent()

            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
            ViewModel = AppWindowViewModel.DI(Of TeamsScreenViewModel)()
            ViewModel.ConfirmationMessageHandler = Me
            TeamsDataGridView.DataSource = ViewModel.Teams
        End Sub

        Private ReadOnly ViewModel As TeamsScreenViewModel

        Private Sub TeamsDataGridView_DoubleClick(sender As Object, e As EventArgs) Handles TeamsDataGridView.DoubleClick
            With TeamsDataGridView.SelectedRows
                If .Count > 0 Then EditTeam(CType(.Item(0).DataBoundItem, Team))
            End With
        End Sub

        Private Sub TeamContextMenu_Popup(sender As Object, e As EventArgs) Handles TeamContextMenuStrip.Opening
            Dim enabled = TeamsDataGridView.SelectedRows.Count > 0
            WithdrawTeamMenuItem.Enabled = enabled
            DeleteTeamMenuItem.Enabled = enabled
        End Sub

        Private Sub DeleteTeamMenuItem_Click(sender As System.Object, e As EventArgs) Handles DeleteTeamMenuItem.Click
            With TeamsDataGridView.SelectedRows
                If .Count > 0 Then ViewModel.RemoveTeam(CType(.Item(0).DataBoundItem, Team))
            End With
        End Sub

        Private Sub WithdrawTeamMenuItem_Click(sender As Object, e As EventArgs) Handles WithdrawTeamMenuItem.Click
            With TeamsDataGridView.SelectedRows
                If .Count > 0 Then ViewModel.ToggleTeamStatus(CType(.Item(0).DataBoundItem, Team))
                TeamsDataGridView.Refresh()
            End With
        End Sub

        Private Sub EditTeam(team As Team)
            Using dialog = New TeamDialog(New TeamInfo(team))
                dialog.ShowDialog(Me)
            End Using
        End Sub

        Public Function Confirm(message As String) As Boolean Implements IConfirmationMessage.Confirm
            Return MessageBox.Show(Me, message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
        End Function

        Private Sub TeamsDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles TeamsDataGridView.CellFormatting
            If ViewModel.Teams.Item(e.RowIndex).Withdrawn Then
                e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Strikeout)
                e.CellStyle.ForeColor = Color.LightGray
            End If
        End Sub

        Private Sub TeamsDataGridView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TeamsDataGridView.CellMouseDown
            If e.Button = MouseButtons.Right Then
                With CType(sender, DataGridView)
                    .ClearSelection()
                    .Rows(e.RowIndex).Selected = True
                End With
            End If
        End Sub
    End Class

End Namespace