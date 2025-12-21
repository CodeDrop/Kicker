using POFF.Meet.Domain;
using POFF.Meet.Infrastructure;
using POFF.Meet.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POFF.Meet.View;

public partial class AppWindow : Form
{
    private readonly AppWindowViewModel _viewModel;
    private const string _noTeamFilter = "(Team Filter)";

    public AppWindow() : base()
    {
        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        _viewModel = new AppWindowViewModel();
        _viewModel.Teams.ListChanged += TeamsChanged;
        _viewModel.Matches.ListChanged += MatchesChanged;
        _viewModel.Standings.ListChanged += StandingsChanged;

        DataBindings.Add(nameof(Text), _viewModel, nameof(_viewModel.Title));
        TeamsDataGridView.DataSource = _viewModel.Teams;

        TeamsChanged(_viewModel.Teams, null);
        MatchesChanged(_viewModel.Matches, null);
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        if (File.Exists(Settings.Default.RecentFile))
        {
            var filename = Settings.Default.RecentFile;
            OpenTournamentFile(filename);
        }
    }

    private void AppWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        Settings.Default.Save();
        e.Cancel = !CloseTournament();
    }

    private bool CloseTournament()
    {
        if (!_viewModel.IsDirty) return true;

        var dialogResult = ShowQuestion("Es gibt ungespeicherte Änderungen. Möchten Sie diese speichern?", MessageBoxButtons.YesNoCancel);
        if (dialogResult == DialogResult.Cancel) return false;
        if (dialogResult == DialogResult.Yes)
        {
            _viewModel.Save();
        }
        return true;
    }

    private void NewMenuItem_Click(object sender, EventArgs e)
    {
        if (!CloseTournament()) return;

        using var dialog = new SaveFileDialog();
        dialog.Filter = "POFF Turnier (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _viewModel.NewTournament(dialog.FileName);
            Settings.Default.RecentFile = dialog.FileName;
        }
    }

    private void OpenMenuItem_Click(object sender, EventArgs e)
    {
        if (!CloseTournament()) return;

        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "POFF Turnier (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            OpenTournamentFile(openFileDialog.FileName);
            Settings.Default.RecentFile = openFileDialog.FileName;
        }
    }

    private void OpenTournamentFile(string filename)
    {
        _viewModel.Open(filename);
    }

    private void SaveMenuItem_Click(object sender, EventArgs e)
    {
        _viewModel.Save();
    }

    private void AddTeamMenuItem_Click(object sender, EventArgs e)
    {
        if (CheckDeleteResults($"Mannschaft hinzufügen?") == DialogResult.No)
            return;

        var dialog = new TeamDialog(new TeamInfo());
        if (dialog.ShowDialog() != DialogResult.OK) return;

        _viewModel.AddTeam(dialog.TeamInfo);
    }

    private void RemoveTeamMenuItem_Click(object sender, EventArgs e)
    {
        var team = _viewModel.SelectedTeam;
        if (team is null ||
            CheckDeleteResults($"Mannschaft \"{team.Name}\" löschen?") == DialogResult.No)
            return;

        _viewModel.RemoveTeam();
    }

    private void ClipboardGamesMenuItem_Click(object sender, EventArgs e)
    {
        _viewModel.CopyToClipboard(ExportType.Games);
    }

    private void ClipboardTableMenuItem_Click(object sender, EventArgs e)
    {
        _viewModel.CopyToClipboard(ExportType.Standings);
    }

    private void ClipboardCopyAllMenuItem_Click(object sender, EventArgs e)
    {
        _viewModel.CopyToClipboard(ExportType.Games | ExportType.Standings);
    }

    private void PlayerFilterDropDownButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        _viewModel.MatchFilter = e.ClickedItem.Text == _noTeamFilter ? "" : e.ClickedItem.Text;
    }

    private void ExitMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void TeamsChanged(object sender, ListChangedEventArgs e)
    {
        PlayerFilterToolStripDropDownButton.DropDownItems.Clear();
        PlayerFilterToolStripDropDownButton.DropDownItems.Add(_noTeamFilter);
        PlayerFilterToolStripDropDownButton.DropDownItems.AddRange([.. _viewModel.Teams.Select(t => new ToolStripMenuItem(t.Name))]);
    }

    private void MatchesChanged(object sender, ListChangedEventArgs e)
    {
        MatchListView.Items.Clear();

        foreach (var match in _viewModel.Matches)
        {
            MatchListView.Items.Add(new MatchListViewItem(match));
        }

        TotalMatchesCountToolStripStatusLabel.Text = _viewModel.TotalMatchCount().ToString();
        PlayedMatchesCountToolStripStatusLabel.Text = _viewModel.PlayedMatchCount().ToString();
    }

    private void StandingsChanged(object sender, ListChangedEventArgs e)
    {
        StandingListView.Items.Clear();
        foreach (var standing in _viewModel.Standings)
        {
            StandingListView.Items.Add(new StandingListViewItem(standing));
        }
    }

    private void MatchListView_DoubleClick(object sender, EventArgs e)
    {
        if (!(MatchListView.SelectedItems.Count == 1))
            return;

        _viewModel.SelectedMatch = ((MatchListViewItem)MatchListView.SelectedItems[0]).Match;

        using var dialog = new ResultDialog(_viewModel.SelectedMatch);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _viewModel.ProcessResult(dialog.SetResults);
        }
    }

    private DialogResult ShowQuestion(string questions, MessageBoxButtons buttons = MessageBoxButtons.YesNo)
    {
        return MessageBox.Show(questions, Application.ProductName, buttons, MessageBoxIcon.Question);
    }

    private DialogResult CheckDeleteResults(string format)
    {
        if (_viewModel.PlayedMatchCount() > 0)
            return ShowQuestion($"{format}{Environment.NewLine}Erfasste Spielergebnisse werden gelöscht.");
        return DialogResult.Yes;
    }

    private void TeamsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            e.Value = e.RowIndex + 1;
        }
        if (((Team)TeamsDataGridView.Rows[e.RowIndex].DataBoundItem).Withdrawn)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
            e.CellStyle.ForeColor = Color.LightGray;
        }
    }

    private void TeamsDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        _viewModel.SelectedTeam = TeamsDataGridView.SelectedRows.Count == 1 ? (Team)TeamsDataGridView.SelectedRows[0].DataBoundItem : null;
    }

    private void TeamsDataGridView_DoubleClick(object sender, EventArgs e)
    {
        var rows = TeamsDataGridView.SelectedRows;
        if (rows.Count == 1)
        {
            EditTeam((Team)rows[0].DataBoundItem);
        }
    }

    private void EditTeam(Team team)
    {
        using var dialog = new TeamDialog(new TeamInfo(team));
        dialog.ShowDialog(this);
    }
}