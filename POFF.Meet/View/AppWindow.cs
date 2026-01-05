using POFF.Meet.Domain;
using POFF.Meet.Infrastructure;
using POFF.Meet.Properties;
using System;
using System.Collections.Generic;
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
        _viewModel.Matches.ListChanged += GamesChanged;

        DataBindings.Add(nameof(Text), _viewModel, nameof(_viewModel.Title));

        TeamsGridView.AutoGenerateColumns = false;
        TeamsGridView.DataSource = _viewModel.Teams;
        GamesGridView.AutoGenerateColumns = false;
        GamesGridView.DataSource = _viewModel.Matches;
        RankingGridView.AutoGenerateColumns = false;
        RankingGridView.DataSource = _viewModel.Standings;

        TeamsChanged(_viewModel.Teams, null);
        GamesChanged(_viewModel.Matches, null);
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        if (Settings.Default.RecentFiles.Count > 0 && File.Exists(Settings.Default.RecentFiles[0]))
        {
            OpenFileAndUpdateRecentFiles(Settings.Default.RecentFiles[0]);
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
        _viewModel.NewTournament();
    }

    private void OpenMenuItem_Click(object sender, EventArgs e)
    {
        if (!CloseTournament()) return;

        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "POFF Meet (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filename = openFileDialog.FileName;
            OpenFileAndUpdateRecentFiles(filename);
        }
    }

    private void OpenFileAndUpdateRecentFiles(string filename)
    {
        _viewModel.Storage = new FileTournamentStorage(filename);
        _viewModel.Open();
        UpdateRecentFiles(filename);
    }

    private void UpdateRecentFiles(string filename)
    {
        if (Settings.Default.RecentFiles.Contains(filename))
        {
            Settings.Default.RecentFiles.Remove(filename);
        }
        if (Settings.Default.RecentFiles.Count >= 5)
        {
            Settings.Default.RecentFiles.RemoveAt(4);
        }

        Settings.Default.RecentFiles.Insert(0, filename);

        RecentMenuItem.DropDownItems.Clear();
        foreach (var file in Settings.Default.RecentFiles)
        {
            RecentMenuItem.DropDown.Items.Add(file);
        }
    }

    private void RecentFilesMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        var file = e.ClickedItem.Text;
        if (!File.Exists(file))
        {
            MessageBox.Show(
                $"File \"{file}\" does not exist and will be removed from recent list.",
                "Invalid tournament file",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            Settings.Default.RecentFiles.Remove(file);
            RecentMenuItem.DropDown.Items.Remove(e.ClickedItem);
            return;
        }

        if (!CloseTournament()) return;

        OpenFileAndUpdateRecentFiles(file);
    }

    private void SaveMenuItem_Click(object sender, EventArgs e)
    {
        if (_viewModel.IsNew)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "POFF Meet (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            if (dialog.ShowDialog() != DialogResult.OK) return;

            _viewModel.Storage = new FileTournamentStorage(dialog.FileName);
            UpdateRecentFiles(dialog.FileName);
        }

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

    private void GamesChanged(object sender, ListChangedEventArgs e)
    {
        TotalMatchesCountToolStripStatusLabel.Text = _viewModel.TotalMatchCount().ToString();
        PlayedMatchesCountToolStripStatusLabel.Text = _viewModel.PlayedMatchCount().ToString();
    }

    private void GamesGridView_SelectedRowsChanged(object sender, EventArgs e)
    {
        var games = new List<Match>();
        foreach (DataGridViewRow row in GamesGridView.SelectedRows)
        {
            if (row.DataBoundItem is Match match)
            {
                games.Add(match);
            }
        }
        _viewModel.SelectedMatches = games;
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
        if (((Team)TeamsGridView.Rows[e.RowIndex].DataBoundItem).Withdrawn)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
            e.CellStyle.ForeColor = Color.LightGray;
        }
    }

    private void TeamsDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        _viewModel.SelectedTeam = TeamsGridView.SelectedRows.Count == 1 ? (Team)TeamsGridView.SelectedRows[0].DataBoundItem : null;
    }

    private void TeamsDataGridView_DoubleClick(object sender, EventArgs e)
    {
        var rows = TeamsGridView.SelectedRows;
        if (rows.Count == 1)
        {
            EditTeam((Team)rows[0].DataBoundItem);
        }
    }
    private void GamesGridView_DoubleClick(object sender, EventArgs e)
    {
        var rows = GamesGridView.SelectedRows;
        if (rows.Count != 1) return;

        _viewModel.SelectedMatch = (Match)rows[0].DataBoundItem;

        using var dialog = new ResultDialog(_viewModel.SelectedMatch);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _viewModel.ProcessResult(dialog.SetResults);
        }
    }

    private void EditTeam(Team team)
    {
        using var dialog = new TeamDialog(new TeamInfo(team));
        dialog.ShowDialog(this);
    }

    private void ExportMenuItem_Click(object sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog { OverwritePrompt = false };
        dialog.Title = "Export into TWIG file";
        dialog.Filter = "TWIG template (*.html.twig)|*.html.twig";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _viewModel.ExportInto(dialog.FileName);
        }
    }

    private void AboutMenuItem_Click(object sender, EventArgs e)
    {
        using var dialog = new AboutDialog { MeetingId = _viewModel.TournamentId };
        dialog.ShowDialog(this);
    }
}