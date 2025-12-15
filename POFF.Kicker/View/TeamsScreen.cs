using System;
using System.Drawing;
using System.Windows.Forms;
using POFF.Kicker.Domain;
using POFF.Kicker.Domain;

namespace POFF.Kicker.View;

public partial class TeamsScreen : IConfirmationMessage
{
    public TeamsScreen()
    {

        // Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent();

        // Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        ViewModel = AppWindowViewModel.Instance.TeamsScreen;
        ViewModel.ConfirmationMessageHandler = this;
        TeamsDataGridView.DataSource = ViewModel.Teams;
    }

    private readonly TeamsScreenViewModel ViewModel;

    private void TeamsDataGridView_DoubleClick(object sender, EventArgs e)
    {
        {
            var rows = TeamsDataGridView.SelectedRows;
            if (rows.Count > 0)
            {
                EditTeam((Team)rows[0].DataBoundItem);
            }
        }
    }

    private void TeamContextMenu_Popup(object sender, EventArgs e)
    {
        bool enabled = TeamsDataGridView.SelectedRows.Count > 0;
        WithdrawTeamMenuItem.Enabled = enabled;
        DeleteTeamMenuItem.Enabled = enabled;
    }

    private void DeleteTeamMenuItem_Click(object sender, EventArgs e)
    {
        var rows = TeamsDataGridView.SelectedRows;
        if (rows.Count > 0)
            ViewModel.RemoveTeam((Team)rows[0].DataBoundItem);
    }

    private void WithdrawTeamMenuItem_Click(object sender, EventArgs e)
    {
        var rows = TeamsDataGridView.SelectedRows;
        if (rows.Count > 0)
            ViewModel.ToggleTeamStatus((Team)rows[0].DataBoundItem);
        TeamsDataGridView.Refresh();
    }

    private void EditTeam(Team team)
    {
        using (var dialog = new TeamDialog(new TeamInfo(team)))
        {
            dialog.ShowDialog(this);
        }
    }

    public bool Confirm(string message)
    {
        return MessageBox.Show(this, message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
    }

    private void TeamsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            e.Value = e.RowIndex + 1;
        }
        if (ViewModel.Teams[e.RowIndex].Withdrawn)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
            e.CellStyle.ForeColor = Color.LightGray;
        }
    }

    private void TeamsDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var dataGridView = (DataGridView)sender;
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
        }
    }
}