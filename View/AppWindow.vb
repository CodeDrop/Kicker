Imports POFF.Kicker.Model
Imports POFF.Kicker.View.Screens
Imports POFF.Kicker.View.Components
Imports POFF.Kicker.ViewModel
Imports POFF.Kicker.ViewModel.Types

Public Class AppWindow
    Inherits Form

    Public Sub New()
        MyBase.New()
        ViewModel = AppWindowViewModel.Instance

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' ViewModel <-> View
        AppTabControl.DataBindings.Add("SelectedIndex", ViewModel, "TabIndex", False, DataSourceUpdateMode.OnPropertyChanged)

        ' Actions
        AddHandler FormClosing, Sub() ViewModel.Save()
        AddHandler CopyToolStripMenuItem.Click, Sub() ViewModel.CopyToClipboard()
        AddHandler SaveToolStripMenuItem.Click, Sub() ViewModel.Save()
        AddHandler ExitToolStripMenuItem.Click, Sub() Close()
    End Sub

    Private ReadOnly ViewModel As AppWindowViewModel

    Private Sub AppWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateGui()
    End Sub

    Private Sub NewTeamMenuItem_Click(sender As Object, e As EventArgs) Handles NewTeamToolStripMenuItem.Click
        SwitchToTab(TeamsTabPage)                   ' Switch to teams tab

        ' Ask user for acknoledge, if there are already matches played
        If CheckDeleteResults("Der Spielplan und Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie noch eine Mannschaft hinzufügen.{0}{0}Wollen Sie die Manschaft hinzufügen?", vbCrLf) = DialogResult.No Then Return

        With New TeamDialog(New TeamInfo())
            If .ShowDialog = DialogResult.OK Then
                ViewModel.AddTeam(.TeamInfo)
                UpdateGui()
            End If
        End With
    End Sub

    Private Sub CreateAgendaMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePlaylistToolStripMenuItem.Click
        SwitchToTab(MatchesTabPage)                 ' Show matches tab page

        ' Ask user for acknoledge, if there are already matches played
        If CheckDeleteResults("Die Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie den Spielplan neu erstellen.{0}{0}Wollen Sie die Ergebnisse verwerfen und den Spielplan erstellen?", vbCrLf) = DialogResult.No Then Return

        ' Generate match list 
        ViewModel.Tournament.Start()
        UpdateMatchList()
        UpdateStandingList()
    End Sub

    Private Sub UpdateGui()
        UpdateMatchList()
        UpdateStandingList()
    End Sub

    Private Sub UpdateMatchList()
        MatchListView.Items.Clear()

        For Each match In Me.ViewModel.Tournament.MatchManager.GetMatches()
            DirectCast(MatchListView.Items.Add(New MatchListViewItem(match)), MatchListViewItem).RefreshNumber()
        Next match

        TotalMatchesCountToolStripStatusLabel.Text = ViewModel.Tournament.TotalMatchCount().ToString()
        PlayedMatchesCountToolStripStatusLabel.Text = ViewModel.Tournament.PlayedMatchCount().ToString()
    End Sub

    Private Sub UpdateStandingList()
        StandingListView.Items.Clear()
        For Each standing In ViewModel.Tournament.GetStandings()
            StandingListView.Items.Add(New StandingListViewItem(standing))
        Next standing
    End Sub

    Private Sub MatchListView_DoubleClick(sender As Object, e As EventArgs) Handles MatchListView.DoubleClick
        If Not MatchListView.SelectedItems.Count = 1 Then Return

        Dim match As Match = CType(MatchListView.SelectedItems(0), MatchListViewItem).Match
        With New ResultDialog(match)
            If .ShowDialog(Me) = DialogResult.OK Then
                ViewModel.Tournament.MatchManager.SetStatus(match.Number, .Result)
                UpdateMatchList()
                UpdateStandingList()
            End If
        End With
    End Sub

    Private Sub ShowInformation(text As String)
        ShowInformation("{0}", text)
    End Sub

    Private Sub ShowInformation(format As String, ParamArray args As Object())
        Dim message As String = String.Format(format, args)
        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function ShowQuestion(text As String) As DialogResult
        Return ShowQuestion("{0}", text)
    End Function

    Private Function ShowQuestion(format As String, ParamArray args As Object()) As DialogResult
        Return MessageBox.Show(String.Format(format, args), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Private Function CheckDeleteResults(format As String, ParamArray args As Object()) As DialogResult
        Dim finishedMatchCount As Integer = ViewModel.Tournament.MatchManager.GetMatches(MatchStatus.Finished).Length

        If finishedMatchCount > 0 Then Return ShowQuestion(format, args)
        Return DialogResult.Yes
    End Function

    Private Sub SwitchToTab(tabPage As TabPage)
        AppTabControl.SelectedTab = tabPage
        AppTabControl.Refresh()
    End Sub

End Class