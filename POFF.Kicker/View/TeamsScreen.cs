using System;
using System.Drawing;
using System.Windows.Forms;
using POFF.Kicker.Domain;

namespace POFF.Kicker.View;

public partial class TeamsScreen
{
    public TeamsScreen()
    {
        // Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent();

        // Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    }

    public AppWindowViewModel ViewModel
    {
        private get;
        set
        {
            field = value;
            TeamsDataGridView.DataSource = value.Teams;
        }
    }

    private void TeamsDataGridView_DoubleClick(object sender, EventArgs e)
    {
        var rows = TeamsDataGridView.SelectedRows;
        if (rows.Count > 0)
        {
            EditTeam((Team)rows[0].DataBoundItem);
        }
    }

    private void EditTeam(Team team)
    {
        using var dialog = new TeamDialog(new TeamInfo(team));
        dialog.ShowDialog(this);
    }

    private void TeamsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            e.Value = e.RowIndex + 1;
        }
        if (((Team) (TeamsDataGridView.Rows[e.RowIndex].DataBoundItem)).Withdrawn)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
            e.CellStyle.ForeColor = Color.LightGray;
        }
    }

    private void TeamsDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        ViewModel.SelectedTeam = TeamsDataGridView.SelectedRows.Count == 1 ? (Team)TeamsDataGridView.SelectedRows[0].DataBoundItem : null;
    }
}