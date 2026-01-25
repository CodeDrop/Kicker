using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.Domain.ScoreModes;
using POFF.Meet.Infrastructure;
using POFF.Meet.Infrastructure.Files;
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
        _viewModel.Standings.ListChanged += RankingChanged;
        _viewModel.Matches.ListChanged += GamesChanged;

        DataBindings.Add(nameof(Text), _viewModel, nameof(_viewModel.Title));

        RankingGridView.AutoGenerateColumns = false;
        RankingGridView.DataSource = _viewModel.Standings;

        GamesGridView.AutoGenerateColumns = false;
        GamesGridView.DataSource = _viewModel.Matches;

        PlayModeComboBox.DataSource = _viewModel.PlayModes;
        PlayModeComboBox.DataBindings.Add(nameof(ComboBox.SelectedItem), _viewModel, nameof(_viewModel.PlayMode), false, DataSourceUpdateMode.Never);
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
            return Save();
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
        openFileDialog.Filter = "POFF Meet files (*.xml)|*.xml|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filename = openFileDialog.FileName;
            OpenFileAndUpdateRecentFiles(filename);
        }
    }

    private void OpenFileAndUpdateRecentFiles(string filename)
    {
        _viewModel.Storage = new FileTournamentStorage(filename);
        ExecuteWithoutControlEvents(_viewModel.Open);
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
        _ = Save();
    }

    private bool Save()
    {
        if (_viewModel.IsNew)
        {
            using var dialog = new SaveFileDialog();
            dialog.Filter = "POFF Meet (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            if (dialog.ShowDialog() != DialogResult.OK) return false;

            _viewModel.Storage = new FileTournamentStorage(dialog.FileName);
            UpdateRecentFiles(dialog.FileName);
        }

        _viewModel.Save();
        return true;
    }

    private void AddTeamMenuItem_Click(object sender, EventArgs e)
    {
        if (CheckDeleteResults($"Add team?") == DialogResult.No)
            return;

        var teamInfo = new TeamInfo();
        using var dialog = new TeamDialog(teamInfo);
        if (dialog.ShowDialog() != DialogResult.OK) return;

        _viewModel.AddTeam(teamInfo);
    }

    private void RemoveTeamMenuItem_Click(object sender, EventArgs e)
    {
        var team = _viewModel.SelectedTeam;
        if (team is null ||
            CheckDeleteResults($"Remove team \"{team.Name}\"?") == DialogResult.No)
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

    private void RankingChanged(object sender, ListChangedEventArgs e)
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

    private void RankingGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex % 2 == 0)
        {
            e.CellStyle.BackColor = Color.WhiteSmoke;
        }
        if (((Standing)RankingGridView.Rows[e.RowIndex].DataBoundItem).Team.Withdrawn)
        {
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
            e.CellStyle.ForeColor = Color.SlateGray;
        }
    }

    private void RankingGridView_SelectionChanged(object sender, EventArgs e)
    {
        _viewModel.SelectedTeam = RankingGridView.SelectedRows.Count == 1 ? ((Standing)RankingGridView.SelectedRows[0].DataBoundItem).Team : null;
    }

    private void RankingGridView_DoubleClick(object sender, EventArgs e)
    {
        var rows = RankingGridView.SelectedRows;
        if (rows.Count != 1) return;

        using var dialog = new TeamDialog(new TeamInfo(_viewModel.SelectedTeam));
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _viewModel.UpdateTeam(dialog.TeamInfo);
        }
    }

    private void GamesGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        int section = ((Match)GamesGridView.Rows[e.RowIndex].DataBoundItem).Section;

        // Alternate section coloring
        if (section > 0 && section % 2 == 0)
        {
            e.CellStyle.BackColor = Color.Beige;
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

    private void PlayModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckDeleteResults("Change play mode?") == DialogResult.Yes)
        {
            _viewModel.PlayMode = (PlayMode)PlayModeComboBox.SelectedItem;
        }
        else
        {
            // Reset selection back to current play mode
            ExecuteWithoutControlEvents(() => PlayModeComboBox.SelectedItem = _viewModel.PlayMode);
        }
    }

    private void ExecuteWithoutControlEvents(Action action)
    {
        PlayModeComboBox.SelectedIndexChanged -= PlayModeComboBox_SelectedIndexChanged;

        try
        {
            action();
        }
        finally
        {
            PlayModeComboBox.SelectedIndexChanged += PlayModeComboBox_SelectedIndexChanged;
        }
    }
}