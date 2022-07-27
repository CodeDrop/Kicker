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

        Private Sub TeamsDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TeamsDataGridView.DoubleClick
            With TeamsDataGridView.SelectedRows
                If .Count > 0 Then EditTeam(CType(.Item(0).DataBoundItem, Team))
            End With
        End Sub

        Private Sub TeamContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles TeamContextMenuStrip.Opening
            DeleteTeamMenuItem.Enabled = TeamsDataGridView.SelectedRows.Count > 0
        End Sub

        Private Sub DeleteTeamMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteTeamMenuItem.Click
            With TeamsDataGridView.SelectedRows
                If .Count > 0 Then ViewModel.RemoveTeam(CType(.Item(0).DataBoundItem, Team))
            End With
        End Sub

        Private Sub EditTeam(ByVal team As Team)
            Using dialog = New TeamDialog(New TeamInfo(team))
                dialog.ShowDialog(Me)
            End Using
        End Sub

        Public Function Confirm(message As String) As Boolean Implements IConfirmationMessage.Confirm
            Return MessageBox.Show(Me, message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
        End Function

    End Class

End Namespace