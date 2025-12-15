using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.Types;

namespace POFF.Kicker.View;

public partial class AppWindow : Form
{
    private readonly AppWindowViewModel _viewModel;
    private const string _noTeamFilter = "(Team Filter)";

    public AppWindow() : base()
    {
        _viewModel = AppWindowViewModel.Instance;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        // ViewModel <-> View
        AppTabControl.DataBindings.Add("SelectedIndex", _viewModel, "TabIndex", false, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        UpdateGui();
        UpdateTeams();
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

    private void UpdateTeams()
    {
        PlayerFilterToolStripDropDownButton.DropDownItems.Clear();
        PlayerFilterToolStripDropDownButton.DropDownItems.Add(_noTeamFilter);
        PlayerFilterToolStripDropDownButton.DropDownItems.AddRange([.. _viewModel.Tournament.Teams.Select(p => new ToolStripMenuItem(p.Name) { Tag = p })]);
    }

    private void OpenMenuItem_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "POFF Tournament (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            _viewModel.Open(openFileDialog.FileName);
            Text = $"POFF Kicker - {Path.GetFileNameWithoutExtension(openFileDialog.FileName)}";
            UpdateTeams();
            UpdateGui();
        }
    }

    private void SaveMenuItem_Click(object sender, EventArgs e)
    {
        _viewModel.Save();
    }

    private void NewTeamMenuItem_Click(object sender, EventArgs e)
    {
        SwitchToTab(TeamsTabPage);                   // Switch to teams tab

        // Ask user for acknoledge, if there are already matches played
        if (CheckDeleteResults("Der Spielplan und Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie noch eine Mannschaft hinzufügen.{0}{0}Wollen Sie die Manschaft hinzufügen?", Environment.NewLine) == DialogResult.No)
            return;

        {
            var dialog = new TeamDialog(new TeamInfo());
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _viewModel.AddTeam(dialog.TeamInfo);
                UpdateGui();
            }
        }
    }

    private void CreateAgendaMenuItem_Click(object sender, EventArgs e)
    {
        SwitchToTab(MatchesTabPage);                 // Show matches tab page

        // Ask user for acknoledge, if there are already matches played
        if (CheckDeleteResults("Die Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie den Spielplan neu erstellen.{0}{0}Wollen Sie die Ergebnisse verwerfen und den Spielplan erstellen?", Environment.NewLine) == DialogResult.No)
            return;

        // Generate match list 
        _viewModel.Tournament.Start();
        UpdateMatchList();
        UpdateStandingList();
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

    private DialogResult CheckDeleteResults(string format, params object[] args)
    {
        if (_viewModel.Tournament.PlayedMatchCount() > 0)
            return ShowQuestion(format, args);
        return DialogResult.Yes;
    }

    private void SwitchToTab(TabPage tabPage)
    {
        AppTabControl.SelectedTab = tabPage;
        AppTabControl.Refresh();
    }
}