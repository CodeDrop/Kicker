using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using POFF.Kicker.Model;
using POFF.Kicker.View.Components;
using POFF.Kicker.View.Screens;
using POFF.Kicker.ViewModel;
using POFF.Kicker.ViewModel.Types;

namespace POFF.Kicker.View;


public partial class AppWindow : Form
{

    private readonly AppWindowViewModel ViewModel;
    private const string NoTeamFilter = "(Team Filter)";

    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AppWindow());
    }

    public AppWindow() : base()
    {
        ViewModel = AppWindowViewModel.Instance;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        // ViewModel <-> View
        AppTabControl.DataBindings.Add("SelectedIndex", ViewModel, "TabIndex", false, DataSourceUpdateMode.OnPropertyChanged);

        // Actions
        FormClosing += (s, e) => ViewModel.Save();
        CopyToolStripMenuItem.Click += (s, e) => ViewModel.CopyToClipboard();
        SaveToolStripMenuItem.Click += (s, e) => ViewModel.Save();
        ExitToolStripMenuItem.Click += (s, e) => Close();
        PlayerFilterToolStripDropDownButton.DropDownItemClicked += UpdateFilter;
        Load += AppWindow_Load;
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        UpdateGui();
        PlayerFilterToolStripDropDownButton.DropDownItems.Add(NoTeamFilter);
        PlayerFilterToolStripDropDownButton.DropDownItems.AddRange(ViewModel.Tournament.TeamManager.GetTeams().Select(p => new ToolStripMenuItem(p.Name) { Tag = p }).ToArray());
    }

    private void NewTeamMenuItem_Click(object sender, EventArgs e)
    {
        SwitchToTab(TeamsTabPage);                   // Switch to teams tab

        // Ask user for acknoledge, if there are already matches played
        if (CheckDeleteResults("Der Spielplan und Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie noch eine Mannschaft hinzufügen.{0}{0}Wollen Sie die Manschaft hinzufügen?", Environment.NewLine) == DialogResult.No)
            return;

        {
            var withBlock = new TeamDialog(new TeamInfo());
            if (withBlock.ShowDialog() == DialogResult.OK)
            {
                ViewModel.AddTeam(withBlock.TeamInfo);
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
        var @type = OptionMatchDaysToolStripMenuItem.Checked ? TournamentType.MatchDays : TournamentType.Standard;
        ViewModel.Tournament.Start(type);
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

        foreach (var match in ViewModel.Tournament.MatchManager.GetMatches())
        {
            no += 1;
            if (CultureInfo.CurrentCulture.CompareInfo.Compare(filter ?? "", NoTeamFilter, CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0 || CultureInfo.CurrentCulture.CompareInfo.Compare(match.Team1.Name ?? "", filter ?? "", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0 || CultureInfo.CurrentCulture.CompareInfo.Compare(match.Team2.Name ?? "", filter ?? "", CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0)
            {
                MatchListView.Items.Add(new MatchListViewItem(match, no));
            }
        }

        TotalMatchesCountToolStripStatusLabel.Text = ViewModel.Tournament.TotalMatchCount().ToString();
        PlayedMatchesCountToolStripStatusLabel.Text = ViewModel.Tournament.PlayedMatchCount().ToString();
    }

    private void UpdateStandingList()
    {
        StandingListView.Items.Clear();
        foreach (var standing in ViewModel.Tournament.GetStandings())
            StandingListView.Items.Add(new StandingListViewItem(standing));
    }

    private void UpdateFilter(object sender, ToolStripItemClickedEventArgs e)
    {
        PlayerFilterToolStripDropDownButton.Text = e.ClickedItem.Text;
        UpdateMatchList();
    }

    private void MatchListView_DoubleClick(object sender, EventArgs e)
    {
        if (!(MatchListView.SelectedItems.Count == 1))
            return;

        var match = ((MatchListViewItem)MatchListView.SelectedItems[0]).Match;
        {
            var withBlock = new ResultDialog(match);
            if (withBlock.ShowDialog(this) == DialogResult.OK)
            {
                ViewModel.Tournament.MatchManager.SetStatus(match.Number, withBlock.Result);
                UpdateMatchList();
                UpdateStandingList();
            }
        }
    }

    private void ShowInformation(string text)
    {
        ShowInformation("{0}", text);
    }

    private void ShowInformation(string format, params object[] args)
    {
        string message = string.Format(format, args);
        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private DialogResult ShowQuestion(string text)
    {
        return ShowQuestion("{0}", text);
    }

    private DialogResult ShowQuestion(string format, params object[] args)
    {
        return MessageBox.Show(string.Format(format, args), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    private DialogResult CheckDeleteResults(string format, params object[] args)
    {
        int finishedMatchCount = ViewModel.Tournament.MatchManager.GetMatches(MatchStatus.Finished).Length;

        if (finishedMatchCount > 0)
            return ShowQuestion(format, args);
        return DialogResult.Yes;
    }

    private void SwitchToTab(TabPage tabPage)
    {
        AppTabControl.SelectedTab = tabPage;
        AppTabControl.Refresh();
    }

}