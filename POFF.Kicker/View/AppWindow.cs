using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.Domain;
using System.ComponentModel;

namespace POFF.Kicker.View;

public partial class AppWindow : Form
{
    private readonly AppWindowViewModel _viewModel;
    private const string _noTeamFilter = "(Team Filter)";

    public AppWindow() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        _viewModel = AppWindowViewModel.Instance;
        _TeamsScreenContent.ViewModel = _viewModel;
        _viewModel.Teams.ListChanged += TeamsChanged;
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        UpdateGui();
    }

    private void TeamsChanged(object sender, ListChangedEventArgs e)
    {
        PlayerFilterToolStripDropDownButton.DropDownItems.Clear();
        PlayerFilterToolStripDropDownButton.DropDownItems.Add(_noTeamFilter);
        PlayerFilterToolStripDropDownButton.DropDownItems.AddRange([.. _viewModel.Teams.Select(p => new ToolStripMenuItem(p.Name) { Tag = p })]);
    }

    private void AppWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        _viewModel.Save();
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
        PlayerFilterToolStripDropDownButton.Text = e.ClickedItem.Text;
        UpdateMatchList();
    }

    private void ExitMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void OpenMenuItem_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "POFF Tournament (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            _viewModel.Open(openFileDialog.FileName);
            Text = $"POFF Kicker - {Path.GetFileNameWithoutExtension(openFileDialog.FileName)}";
            UpdateGui();
        }
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
        UpdateGui();
    }

    private void RemoveTeamMenuItem_Click(object sender, EventArgs e)
    {
        var team = _viewModel.SelectedTeam;
        if (team is null ||
            CheckDeleteResults($"Mannschaft \"{team.Name}\" löschen?") == DialogResult.No)
            return;

        _viewModel.RemoveTeam();
        UpdateGui();
    }

    private void UpdateGui()
    {
        UpdateMatchList();
        UpdateStandingList();
    }

    private void UpdateMatchList()
    {
        MatchListView.Items.Clear();
        string filter = PlayerFilterToolStripDropDownButton.Text;
        var no = default(int);

        foreach (var match in _viewModel.Tournament.Matches)
        {
            no += 1;
            if (filter == _noTeamFilter || filter == match.Team1.Name || filter == match.Team2.Name)
            {
                MatchListView.Items.Add(new MatchListViewItem(match, no));
            }
        }

        TotalMatchesCountToolStripStatusLabel.Text = _viewModel.Tournament.TotalMatchCount().ToString();
        PlayedMatchesCountToolStripStatusLabel.Text = _viewModel.Tournament.PlayedMatchCount().ToString();
    }

    private void UpdateStandingList()
    {
        StandingListView.Items.Clear();
        foreach (var standing in _viewModel.Tournament.GetStandings())
            StandingListView.Items.Add(new StandingListViewItem(standing));
    }

    private void MatchListView_DoubleClick(object sender, EventArgs e)
    {
        if (!(MatchListView.SelectedItems.Count == 1))
            return;

        var match = ((MatchListViewItem)MatchListView.SelectedItems[0]).Match;
        {
            var dialog = new ResultDialog(match);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _viewModel.Tournament.SetResult(match.Number, dialog.Result);
                UpdateMatchList();
                UpdateStandingList();
            }
        }
    }

    private DialogResult ShowQuestion(string format, params object[] args)
    {
        return MessageBox.Show(string.Format(format, args), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    private DialogResult CheckDeleteResults(string format)
    {
        if (_viewModel.Tournament.PlayedMatchCount() > 0)
            return ShowQuestion($"{format}{Environment.NewLine}Erfasste Spielergebnisse werden gelöscht.");
        return DialogResult.Yes;
    }
}