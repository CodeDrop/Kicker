Partial Public Class AppWindow

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TeamsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents MatchesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ResultsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents AppTabControl As System.Windows.Forms.TabControl
    Friend WithEvents MatchListView As System.Windows.Forms.ListView
    Friend WithEvents Team1ColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents Team2ColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents MatchImageList As System.Windows.Forms.ImageList
    Friend WithEvents ResultColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents StandingListView As System.Windows.Forms.ListView
    Friend WithEvents PlaceColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents TeamTableColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents PointsColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents GoalsColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents MatchesColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents WonSetsColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents MatchStatusColumnHeader As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppWindow))
        Me.AppTabControl = New System.Windows.Forms.TabControl()
        Me.TeamsTabPage = New System.Windows.Forms.TabPage()
        Me.TeamsScreenContent = New POFF.Kicker.View.Screens.TeamsScreen()
        Me.MatchesTabPage = New System.Windows.Forms.TabPage()
        Me.MatchListView = New System.Windows.Forms.ListView()
        Me.MatchStatusColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MatchNumberColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Team1ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Team2ColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResultColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MatchImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.StandingListView = New System.Windows.Forms.ListView()
        Me.PlaceColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TeamTableColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PointsColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WonSetsColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GoalsColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MatchesColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AppMainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.TournamentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewTeamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatePlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionMatchDaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SpacerStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalMatchesToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalMatchesCountToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PlayedMatchesToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PlayedMatchesCountToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PlayerFilterToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AppTabControl.SuspendLayout()
        Me.TeamsTabPage.SuspendLayout()
        Me.MatchesTabPage.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        Me.AppMainMenuStrip.SuspendLayout()
        Me.AppStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'AppTabControl
        '
        Me.AppTabControl.Controls.Add(Me.TeamsTabPage)
        Me.AppTabControl.Controls.Add(Me.MatchesTabPage)
        Me.AppTabControl.Controls.Add(Me.ResultsTabPage)
        Me.AppTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppTabControl.Location = New System.Drawing.Point(0, 24)
        Me.AppTabControl.Name = "AppTabControl"
        Me.AppTabControl.SelectedIndex = 0
        Me.AppTabControl.Size = New System.Drawing.Size(664, 307)
        Me.AppTabControl.TabIndex = 0
        '
        'TeamsTabPage
        '
        Me.TeamsTabPage.Controls.Add(Me.TeamsScreenContent)
        Me.TeamsTabPage.Location = New System.Drawing.Point(4, 27)
        Me.TeamsTabPage.Name = "TeamsTabPage"
        Me.TeamsTabPage.Size = New System.Drawing.Size(656, 276)
        Me.TeamsTabPage.TabIndex = 0
        Me.TeamsTabPage.Text = "Mannschaften"
        '
        'TeamsScreenContent
        '
        Me.TeamsScreenContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TeamsScreenContent.Location = New System.Drawing.Point(0, 0)
        Me.TeamsScreenContent.Name = "TeamsScreenContent"
        Me.TeamsScreenContent.Size = New System.Drawing.Size(656, 276)
        Me.TeamsScreenContent.TabIndex = 0
        '
        'MatchesTabPage
        '
        Me.MatchesTabPage.Controls.Add(Me.MatchListView)
        Me.MatchesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MatchesTabPage.Name = "MatchesTabPage"
        Me.MatchesTabPage.Size = New System.Drawing.Size(656, 281)
        Me.MatchesTabPage.TabIndex = 1
        Me.MatchesTabPage.Text = "Spiele"
        '
        'MatchListView
        '
        Me.MatchListView.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MatchListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.MatchStatusColumnHeader, Me.MatchNumberColumnHeader, Me.Team1ColumnHeader, Me.Team2ColumnHeader, Me.ResultColumnHeader})
        Me.MatchListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MatchListView.FullRowSelect = True
        Me.MatchListView.HideSelection = False
        Me.MatchListView.HoverSelection = True
        Me.MatchListView.Location = New System.Drawing.Point(0, 0)
        Me.MatchListView.Name = "MatchListView"
        Me.MatchListView.Size = New System.Drawing.Size(656, 281)
        Me.MatchListView.SmallImageList = Me.MatchImageList
        Me.MatchListView.TabIndex = 2
        Me.MatchListView.UseCompatibleStateImageBehavior = False
        Me.MatchListView.View = System.Windows.Forms.View.Details
        '
        'MatchStatusColumnHeader
        '
        Me.MatchStatusColumnHeader.Text = ""
        Me.MatchStatusColumnHeader.Width = 50
        '
        'MatchNumberColumnHeader
        '
        Me.MatchNumberColumnHeader.Text = "N°"
        '
        'Team1ColumnHeader
        '
        Me.Team1ColumnHeader.Text = "Mannschaft 1"
        Me.Team1ColumnHeader.Width = 200
        '
        'Team2ColumnHeader
        '
        Me.Team2ColumnHeader.Text = "Mannschaft 2"
        Me.Team2ColumnHeader.Width = 200
        '
        'ResultColumnHeader
        '
        Me.ResultColumnHeader.Text = "Ergebnis"
        Me.ResultColumnHeader.Width = 150
        '
        'MatchImageList
        '
        Me.MatchImageList.ImageStream = CType(resources.GetObject("MatchImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MatchImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MatchImageList.Images.SetKeyName(0, "")
        Me.MatchImageList.Images.SetKeyName(1, "")
        Me.MatchImageList.Images.SetKeyName(2, "")
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.Controls.Add(Me.StandingListView)
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Size = New System.Drawing.Size(656, 281)
        Me.ResultsTabPage.TabIndex = 2
        Me.ResultsTabPage.Text = "Tabelle"
        '
        'StandingListView
        '
        Me.StandingListView.BackColor = System.Drawing.Color.LightSteelBlue
        Me.StandingListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PlaceColumnHeader, Me.TeamTableColumnHeader, Me.PointsColumnHeader, Me.WonSetsColumnHeader, Me.GoalsColumnHeader, Me.MatchesColumnHeader})
        Me.StandingListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StandingListView.FullRowSelect = True
        Me.StandingListView.HideSelection = False
        Me.StandingListView.HoverSelection = True
        Me.StandingListView.Location = New System.Drawing.Point(0, 0)
        Me.StandingListView.MultiSelect = False
        Me.StandingListView.Name = "StandingListView"
        Me.StandingListView.Size = New System.Drawing.Size(656, 281)
        Me.StandingListView.TabIndex = 1
        Me.StandingListView.UseCompatibleStateImageBehavior = False
        Me.StandingListView.View = System.Windows.Forms.View.Details
        '
        'PlaceColumnHeader
        '
        Me.PlaceColumnHeader.Text = "Platz"
        Me.PlaceColumnHeader.Width = 50
        '
        'TeamTableColumnHeader
        '
        Me.TeamTableColumnHeader.Text = "Mannschaft"
        Me.TeamTableColumnHeader.Width = 200
        '
        'PointsColumnHeader
        '
        Me.PointsColumnHeader.Text = "Punkte"
        Me.PointsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.PointsColumnHeader.Width = 65
        '
        'WonSetsColumnHeader
        '
        Me.WonSetsColumnHeader.Text = "Sätze"
        Me.WonSetsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.WonSetsColumnHeader.Width = 55
        '
        'GoalsColumnHeader
        '
        Me.GoalsColumnHeader.Text = "Tore"
        Me.GoalsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MatchesColumnHeader
        '
        Me.MatchesColumnHeader.Text = "Spiele"
        Me.MatchesColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AppMainMenuStrip
        '
        Me.AppMainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TournamentToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.AppMainMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.AppMainMenuStrip.Name = "AppMainMenuStrip"
        Me.AppMainMenuStrip.Size = New System.Drawing.Size(664, 24)
        Me.AppMainMenuStrip.TabIndex = 1
        Me.AppMainMenuStrip.Text = "MenuStrip1"
        '
        'TournamentToolStripMenuItem
        '
        Me.TournamentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewTeamToolStripMenuItem, Me.CreatePlaylistToolStripMenuItem, Me.CopyToolStripMenuItem, Me.SaveToolStripMenuItem, Me.AppToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.TournamentToolStripMenuItem.Name = "TournamentToolStripMenuItem"
        Me.TournamentToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.TournamentToolStripMenuItem.Text = "&Turnier"
        '
        'NewTeamToolStripMenuItem
        '
        Me.NewTeamToolStripMenuItem.Name = "NewTeamToolStripMenuItem"
        Me.NewTeamToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewTeamToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.NewTeamToolStripMenuItem.Text = "&Neue Mannschaft"
        '
        'CreatePlaylistToolStripMenuItem
        '
        Me.CreatePlaylistToolStripMenuItem.Name = "CreatePlaylistToolStripMenuItem"
        Me.CreatePlaylistToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.CreatePlaylistToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CreatePlaylistToolStripMenuItem.Text = "Spiel&plan erstellen"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.CopyToolStripMenuItem.Text = "Kopieren (HTML)"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.SaveToolStripMenuItem.Text = "&Speichern"
        '
        'AppToolStripMenuItem
        '
        Me.AppToolStripMenuItem.Name = "AppToolStripMenuItem"
        Me.AppToolStripMenuItem.Size = New System.Drawing.Size(289, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.ExitToolStripMenuItem.Text = "Be&enden"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionMatchDaysToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OptionsToolStripMenuItem.Text = "Optionen"
        '
        'OptionMatchDaysToolStripMenuItem
        '
        Me.OptionMatchDaysToolStripMenuItem.CheckOnClick = True
        Me.OptionMatchDaysToolStripMenuItem.Name = "OptionMatchDaysToolStripMenuItem"
        Me.OptionMatchDaysToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.OptionMatchDaysToolStripMenuItem.Text = "Spieltage"
        '
        'AppStatusStrip
        '
        Me.AppStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayerFilterToolStripDropDownButton, Me.SpacerStripStatusLabel, Me.TotalMatchesToolStripStatusLabel, Me.TotalMatchesCountToolStripStatusLabel, Me.PlayedMatchesToolStripStatusLabel, Me.PlayedMatchesCountToolStripStatusLabel})
        Me.AppStatusStrip.Location = New System.Drawing.Point(0, 331)
        Me.AppStatusStrip.Name = "AppStatusStrip"
        Me.AppStatusStrip.Size = New System.Drawing.Size(664, 22)
        Me.AppStatusStrip.TabIndex = 2
        Me.AppStatusStrip.Text = "StatusStrip1"
        '
        'SpacerStripStatusLabel
        '
        Me.SpacerStripStatusLabel.Name = "SpacerStripStatusLabel"
        Me.SpacerStripStatusLabel.Size = New System.Drawing.Size(476, 17)
        Me.SpacerStripStatusLabel.Spring = True
        '
        'TotalMatchesToolStripStatusLabel
        '
        Me.TotalMatchesToolStripStatusLabel.Name = "TotalMatchesToolStripStatusLabel"
        Me.TotalMatchesToolStripStatusLabel.Size = New System.Drawing.Size(41, 17)
        Me.TotalMatchesToolStripStatusLabel.Text = "Spiele:"
        '
        'TotalMatchesCountToolStripStatusLabel
        '
        Me.TotalMatchesCountToolStripStatusLabel.Name = "TotalMatchesCountToolStripStatusLabel"
        Me.TotalMatchesCountToolStripStatusLabel.Size = New System.Drawing.Size(10, 17)
        Me.TotalMatchesCountToolStripStatusLabel.Text = "."
        '
        'PlayedMatchesToolStripStatusLabel
        '
        Me.PlayedMatchesToolStripStatusLabel.Name = "PlayedMatchesToolStripStatusLabel"
        Me.PlayedMatchesToolStripStatusLabel.Size = New System.Drawing.Size(52, 17)
        Me.PlayedMatchesToolStripStatusLabel.Text = "Gespielt:"
        '
        'PlayedMatchesCountToolStripStatusLabel
        '
        Me.PlayedMatchesCountToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.PlayedMatchesCountToolStripStatusLabel.Name = "PlayedMatchesCountToolStripStatusLabel"
        Me.PlayedMatchesCountToolStripStatusLabel.Size = New System.Drawing.Size(10, 17)
        Me.PlayedMatchesCountToolStripStatusLabel.Text = "."
        '
        'PlayerFilterToolStripDropDownButton
        '
        Me.PlayerFilterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.PlayerFilterToolStripDropDownButton.Image = CType(resources.GetObject("PlayerFilterToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.PlayerFilterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlayerFilterToolStripDropDownButton.Name = "PlayerFilterToolStripDropDownButton"
        Me.PlayerFilterToolStripDropDownButton.Size = New System.Drawing.Size(86, 20)
        Me.PlayerFilterToolStripDropDownButton.Text = "(Team Filter)"
        '
        'AppWindow
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 24)
        Me.ClientSize = New System.Drawing.Size(664, 353)
        Me.Controls.Add(Me.AppTabControl)
        Me.Controls.Add(Me.AppMainMenuStrip)
        Me.Controls.Add(Me.AppStatusStrip)
        Me.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AppWindow"
        Me.Text = "POFF Kicker"
        Me.AppTabControl.ResumeLayout(False)
        Me.TeamsTabPage.ResumeLayout(False)
        Me.MatchesTabPage.ResumeLayout(False)
        Me.ResultsTabPage.ResumeLayout(False)
        Me.AppMainMenuStrip.ResumeLayout(False)
        Me.AppMainMenuStrip.PerformLayout()
        Me.AppStatusStrip.ResumeLayout(False)
        Me.AppStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AppMainMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents TournamentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewTeamToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreatePlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TeamsScreenContent As POFF.Kicker.View.Screens.TeamsScreen
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MatchNumberColumnHeader As ColumnHeader
    Private WithEvents AppStatusStrip As StatusStrip
    Private WithEvents TotalMatchesToolStripStatusLabel As ToolStripStatusLabel
    Private WithEvents PlayedMatchesToolStripStatusLabel As ToolStripStatusLabel
    Private WithEvents SpacerStripStatusLabel As ToolStripStatusLabel
    Private WithEvents PlayedMatchesCountToolStripStatusLabel As ToolStripStatusLabel
    Private WithEvents TotalMatchesCountToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionMatchDaysToolStripMenuItem As ToolStripMenuItem
    Private WithEvents PlayerFilterToolStripDropDownButton As ToolStripDropDownButton
End Class
