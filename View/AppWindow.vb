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

    Private Sub AppWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UpdateGui()
    End Sub

    Private Sub NewTeamMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTeamToolStripMenuItem.Click
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

    Private Sub CreateAgendaMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreatePlaylistToolStripMenuItem.Click
        SwitchToTab(MatchesTabPage)                 ' Show matches tab page

        ' Ask user for acknoledge, if there are already matches played
        If CheckDeleteResults("Die Ergebnisse der bereits durchgeführten Spiele{0}werden gelöscht, wenn Sie den Spielplan neu erstellen.{0}{0}Wollen Sie die Ergebnisse verwerfen und den Spielplan erstellen?", vbCrLf) = DialogResult.No Then Return

        ' Generate match list 
        ViewModel.Tournament.MatchManager.Generate(ViewModel.Tournament.GetTeams())
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
    End Sub

    Private Sub UpdateStandingList()
        StandingListView.Items.Clear()
        For Each standing In ViewModel.Tournament.GetStandings()
            StandingListView.Items.Add(New StandingListViewItem(standing))
        Next standing
    End Sub

    Private Sub MatchListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MatchListView.DoubleClick
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

    Private Sub ShowInformation(ByVal text As String)
        ShowInformation("{0}", text)
    End Sub

    Private Sub ShowInformation(ByVal format As String, ByVal ParamArray args As Object())
        Dim message As String = String.Format(format, args)
        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function ShowQuestion(ByVal text As String) As DialogResult
        Return ShowQuestion("{0}", text)
    End Function

    Private Function ShowQuestion(ByVal format As String, ByVal ParamArray args As Object()) As DialogResult
        Return MessageBox.Show(String.Format(format, args), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Private Function CheckDeleteResults(ByVal format As String, ByVal ParamArray args As Object()) As DialogResult
        Dim finishedMatchCount As Integer = ViewModel.Tournament.MatchManager.GetMatches(MatchStatus.Finished).Length

        If finishedMatchCount > 0 Then Return ShowQuestion(format, args)
        Return DialogResult.Yes
    End Function

    Private Sub SwitchToTab(ByVal tabPage As TabPage)
        AppTabControl.SelectedTab = tabPage
        AppTabControl.Refresh()
    End Sub

End Class