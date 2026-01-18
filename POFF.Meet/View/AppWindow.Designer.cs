using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace POFF.Meet.View;

public partial class AppWindow
{

    // Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components is not null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AppMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.TournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddTeamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTeamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardGamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardCopyAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppStatusStrip = new System.Windows.Forms.StatusStrip();
            this.PlayerFilterToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SpacerStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMatchesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMatchesCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayedMatchesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayedMatchesCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppSplitContainer = new System.Windows.Forms.SplitContainer();
            this.RankingGroupBox = new System.Windows.Forms.GroupBox();
            this.RankingGridView = new System.Windows.Forms.DataGridView();
            this.GamesGroupBox = new System.Windows.Forms.GroupBox();
            this.GamesGridView = new System.Windows.Forms.DataGridView();
            this.StatusColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GameNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayModeComboBox = new System.Windows.Forms.ComboBox();
            this.RankingPlaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingTeamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingGamesCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingPointsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingSetsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankingGoalsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppMainMenuStrip.SuspendLayout();
            this.AppStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppSplitContainer)).BeginInit();
            this.AppSplitContainer.Panel1.SuspendLayout();
            this.AppSplitContainer.Panel2.SuspendLayout();
            this.AppSplitContainer.SuspendLayout();
            this.RankingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankingGridView)).BeginInit();
            this.GamesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AppMainMenuStrip
            // 
            this.AppMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TournamentToolStripMenuItem,
            this.ClipboardMenuItem,
            this.HelpMenuItem});
            this.AppMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.AppMainMenuStrip.Name = "AppMainMenuStrip";
            this.AppMainMenuStrip.Size = new System.Drawing.Size(1138, 24);
            this.AppMainMenuStrip.TabIndex = 1;
            this.AppMainMenuStrip.Text = "MenuStrip1";
            // 
            // TournamentToolStripMenuItem
            // 
            this.TournamentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.RecentMenuItem,
            this.SaveMenuItem,
            this.ExportMenuItem,
            this.toolStripMenuItem1,
            this.AddTeamMenuItem,
            this.RemoveTeamMenuItem,
            this.AppToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.TournamentToolStripMenuItem.Name = "TournamentToolStripMenuItem";
            this.TournamentToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.TournamentToolStripMenuItem.Text = "&Tournament";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenuItem.Size = new System.Drawing.Size(191, 22);
            this.NewMenuItem.Text = "&New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(191, 22);
            this.OpenMenuItem.Text = "&Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // RecentMenuItem
            // 
            this.RecentMenuItem.Name = "RecentMenuItem";
            this.RecentMenuItem.Size = new System.Drawing.Size(191, 22);
            this.RecentMenuItem.Text = "Recen&t";
            this.RecentMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.RecentFilesMenuItem_DropDownItemClicked);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(191, 22);
            this.SaveMenuItem.Text = "&Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // ExportMenuItem
            // 
            this.ExportMenuItem.Name = "ExportMenuItem";
            this.ExportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ExportMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ExportMenuItem.Text = "&Export...";
            this.ExportMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // AddTeamMenuItem
            // 
            this.AddTeamMenuItem.Name = "AddTeamMenuItem";
            this.AddTeamMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.AddTeamMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AddTeamMenuItem.Text = "&Add Team";
            this.AddTeamMenuItem.Click += new System.EventHandler(this.AddTeamMenuItem_Click);
            // 
            // RemoveTeamMenuItem
            // 
            this.RemoveTeamMenuItem.Name = "RemoveTeamMenuItem";
            this.RemoveTeamMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.RemoveTeamMenuItem.Size = new System.Drawing.Size(191, 22);
            this.RemoveTeamMenuItem.Text = "&Remove Team";
            this.RemoveTeamMenuItem.Click += new System.EventHandler(this.RemoveTeamMenuItem_Click);
            // 
            // AppToolStripMenuItem
            // 
            this.AppToolStripMenuItem.Name = "AppToolStripMenuItem";
            this.AppToolStripMenuItem.Size = new System.Drawing.Size(188, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ExitToolStripMenuItem.Text = "&Quit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // ClipboardMenuItem
            // 
            this.ClipboardMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClipboardGamesMenuItem,
            this.ClipboardTableMenuItem,
            this.ClipboardCopyAllMenuItem});
            this.ClipboardMenuItem.Name = "ClipboardMenuItem";
            this.ClipboardMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ClipboardMenuItem.Text = "Clipboard";
            // 
            // ClipboardGamesMenuItem
            // 
            this.ClipboardGamesMenuItem.Name = "ClipboardGamesMenuItem";
            this.ClipboardGamesMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ClipboardGamesMenuItem.Text = "Spiele (HTML)";
            this.ClipboardGamesMenuItem.Click += new System.EventHandler(this.ClipboardGamesMenuItem_Click);
            // 
            // ClipboardTableMenuItem
            // 
            this.ClipboardTableMenuItem.Name = "ClipboardTableMenuItem";
            this.ClipboardTableMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ClipboardTableMenuItem.Text = "Tabelle (HTML)";
            this.ClipboardTableMenuItem.Click += new System.EventHandler(this.ClipboardTableMenuItem_Click);
            // 
            // ClipboardCopyAllMenuItem
            // 
            this.ClipboardCopyAllMenuItem.Name = "ClipboardCopyAllMenuItem";
            this.ClipboardCopyAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.ClipboardCopyAllMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ClipboardCopyAllMenuItem.Text = "Beides (HTML)";
            this.ClipboardCopyAllMenuItem.Click += new System.EventHandler(this.ClipboardCopyAllMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpMenuItem.Text = "&Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.AboutMenuItem.Size = new System.Drawing.Size(126, 22);
            this.AboutMenuItem.Text = "&About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // AppStatusStrip
            // 
            this.AppStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerFilterToolStripDropDownButton,
            this.SpacerStripStatusLabel,
            this.TotalMatchesToolStripStatusLabel,
            this.TotalMatchesCountToolStripStatusLabel,
            this.PlayedMatchesToolStripStatusLabel,
            this.PlayedMatchesCountToolStripStatusLabel});
            this.AppStatusStrip.Location = new System.Drawing.Point(0, 537);
            this.AppStatusStrip.Name = "AppStatusStrip";
            this.AppStatusStrip.Size = new System.Drawing.Size(1138, 22);
            this.AppStatusStrip.TabIndex = 2;
            this.AppStatusStrip.Text = "StatusStrip1";
            // 
            // PlayerFilterToolStripDropDownButton
            // 
            this.PlayerFilterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PlayerFilterToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayerFilterToolStripDropDownButton.Image")));
            this.PlayerFilterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayerFilterToolStripDropDownButton.Name = "PlayerFilterToolStripDropDownButton";
            this.PlayerFilterToolStripDropDownButton.Size = new System.Drawing.Size(86, 20);
            this.PlayerFilterToolStripDropDownButton.Text = "(Team Filter)";
            this.PlayerFilterToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlayerFilterDropDownButton_ItemClicked);
            // 
            // SpacerStripStatusLabel
            // 
            this.SpacerStripStatusLabel.Name = "SpacerStripStatusLabel";
            this.SpacerStripStatusLabel.Size = new System.Drawing.Size(924, 17);
            this.SpacerStripStatusLabel.Spring = true;
            // 
            // TotalMatchesToolStripStatusLabel
            // 
            this.TotalMatchesToolStripStatusLabel.Name = "TotalMatchesToolStripStatusLabel";
            this.TotalMatchesToolStripStatusLabel.Size = new System.Drawing.Size(41, 17);
            this.TotalMatchesToolStripStatusLabel.Text = "Spiele:";
            // 
            // TotalMatchesCountToolStripStatusLabel
            // 
            this.TotalMatchesCountToolStripStatusLabel.Name = "TotalMatchesCountToolStripStatusLabel";
            this.TotalMatchesCountToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this.TotalMatchesCountToolStripStatusLabel.Text = ".";
            // 
            // PlayedMatchesToolStripStatusLabel
            // 
            this.PlayedMatchesToolStripStatusLabel.Name = "PlayedMatchesToolStripStatusLabel";
            this.PlayedMatchesToolStripStatusLabel.Size = new System.Drawing.Size(52, 17);
            this.PlayedMatchesToolStripStatusLabel.Text = "Gespielt:";
            // 
            // PlayedMatchesCountToolStripStatusLabel
            // 
            this.PlayedMatchesCountToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.PlayedMatchesCountToolStripStatusLabel.Name = "PlayedMatchesCountToolStripStatusLabel";
            this.PlayedMatchesCountToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this.PlayedMatchesCountToolStripStatusLabel.Text = ".";
            // 
            // AppSplitContainer
            // 
            this.AppSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.AppSplitContainer.Name = "AppSplitContainer";
            // 
            // AppSplitContainer.Panel1
            // 
            this.AppSplitContainer.Panel1.Controls.Add(this.RankingGroupBox);
            // 
            // AppSplitContainer.Panel2
            // 
            this.AppSplitContainer.Panel2.Controls.Add(this.GamesGroupBox);
            this.AppSplitContainer.Size = new System.Drawing.Size(1138, 513);
            this.AppSplitContainer.SplitterDistance = 568;
            this.AppSplitContainer.TabIndex = 3;
            // 
            // RankingGroupBox
            // 
            this.RankingGroupBox.Controls.Add(this.RankingGridView);
            this.RankingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RankingGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RankingGroupBox.Name = "RankingGroupBox";
            this.RankingGroupBox.Size = new System.Drawing.Size(568, 513);
            this.RankingGroupBox.TabIndex = 2;
            this.RankingGroupBox.TabStop = false;
            this.RankingGroupBox.Text = "Ranking";
            // 
            // RankingGridView
            // 
            this.RankingGridView.AllowUserToAddRows = false;
            this.RankingGridView.AllowUserToDeleteRows = false;
            this.RankingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RankingGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RankingPlaceColumn,
            this.RankingTeamColumn,
            this.RankingGamesCountColumn,
            this.RankingPointsColumn,
            this.RankingSetsColumn,
            this.RankingGoalsColumn});
            this.RankingGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RankingGridView.Location = new System.Drawing.Point(3, 23);
            this.RankingGridView.Name = "RankingGridView";
            this.RankingGridView.ReadOnly = true;
            this.RankingGridView.RowHeadersVisible = false;
            this.RankingGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RankingGridView.Size = new System.Drawing.Size(562, 487);
            this.RankingGridView.TabIndex = 2;
            this.RankingGridView.SelectionChanged += new System.EventHandler(this.RankingGridView_SelectionChanged);
            this.RankingGridView.DoubleClick += new System.EventHandler(this.RankingGridView_DoubleClick);
            // 
            // GamesGroupBox
            // 
            this.GamesGroupBox.Controls.Add(this.GamesGridView);
            this.GamesGroupBox.Controls.Add(this.PlayModeComboBox);
            this.GamesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.GamesGroupBox.Name = "GamesGroupBox";
            this.GamesGroupBox.Size = new System.Drawing.Size(566, 513);
            this.GamesGroupBox.TabIndex = 3;
            this.GamesGroupBox.TabStop = false;
            this.GamesGroupBox.Text = "Games";
            // 
            // GamesGridView
            // 
            this.GamesGridView.AllowUserToAddRows = false;
            this.GamesGridView.AllowUserToDeleteRows = false;
            this.GamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GamesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusColumn,
            this.GameNumberColumn,
            this.HomeColumn,
            this.GuestColumn,
            this.ResultColumn});
            this.GamesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamesGridView.Location = new System.Drawing.Point(3, 23);
            this.GamesGridView.Name = "GamesGridView";
            this.GamesGridView.ReadOnly = true;
            this.GamesGridView.RowHeadersVisible = false;
            this.GamesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GamesGridView.Size = new System.Drawing.Size(560, 463);
            this.GamesGridView.TabIndex = 0;
            this.GamesGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GamesGridView_CellFormatting);
            this.GamesGridView.SelectionChanged += new System.EventHandler(this.GamesGridView_SelectedRowsChanged);
            this.GamesGridView.DoubleClick += new System.EventHandler(this.GamesGridView_DoubleClick);
            // 
            // StatusColumn
            // 
            this.StatusColumn.DataPropertyName = "Status";
            this.StatusColumn.FalseValue = "0";
            this.StatusColumn.Frozen = true;
            this.StatusColumn.HeaderText = "";
            this.StatusColumn.IndeterminateValue = "1";
            this.StatusColumn.MinimumWidth = 24;
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.TrueValue = "2";
            this.StatusColumn.Width = 24;
            // 
            // GameNumberColumn
            // 
            this.GameNumberColumn.DataPropertyName = "Number";
            this.GameNumberColumn.HeaderText = "N°";
            this.GameNumberColumn.Name = "GameNumberColumn";
            this.GameNumberColumn.ReadOnly = true;
            this.GameNumberColumn.Width = 40;
            // 
            // HomeColumn
            // 
            this.HomeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HomeColumn.DataPropertyName = "Team1";
            this.HomeColumn.HeaderText = "Home";
            this.HomeColumn.Name = "HomeColumn";
            this.HomeColumn.ReadOnly = true;
            // 
            // GuestColumn
            // 
            this.GuestColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GuestColumn.DataPropertyName = "Team2";
            this.GuestColumn.HeaderText = "Guest";
            this.GuestColumn.Name = "GuestColumn";
            this.GuestColumn.ReadOnly = true;
            // 
            // ResultColumn
            // 
            this.ResultColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ResultColumn.DataPropertyName = "Result";
            this.ResultColumn.HeaderText = "Result";
            this.ResultColumn.Name = "ResultColumn";
            this.ResultColumn.ReadOnly = true;
            // 
            // PlayModeComboBox
            // 
            this.PlayModeComboBox.DisplayMember = "Name";
            this.PlayModeComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PlayModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayModeComboBox.FormattingEnabled = true;
            this.PlayModeComboBox.Location = new System.Drawing.Point(3, 486);
            this.PlayModeComboBox.Name = "PlayModeComboBox";
            this.PlayModeComboBox.Size = new System.Drawing.Size(560, 24);
            this.PlayModeComboBox.Sorted = true;
            this.PlayModeComboBox.TabIndex = 1;
            this.PlayModeComboBox.SelectedIndexChanged += new System.EventHandler(this.PlayModeComboBox_SelectedIndexChanged);
            // 
            // RankingPlaceColumn
            // 
            this.RankingPlaceColumn.DataPropertyName = "Place";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RankingPlaceColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.RankingPlaceColumn.HeaderText = "#";
            this.RankingPlaceColumn.Name = "RankingPlaceColumn";
            this.RankingPlaceColumn.ReadOnly = true;
            this.RankingPlaceColumn.Width = 30;
            // 
            // RankingTeamColumn
            // 
            this.RankingTeamColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RankingTeamColumn.DataPropertyName = "Team";
            this.RankingTeamColumn.HeaderText = "Team";
            this.RankingTeamColumn.Name = "RankingTeamColumn";
            this.RankingTeamColumn.ReadOnly = true;
            // 
            // RankingGamesCountColumn
            // 
            this.RankingGamesCountColumn.DataPropertyName = "MatchCount";
            this.RankingGamesCountColumn.HeaderText = "Played";
            this.RankingGamesCountColumn.Name = "RankingGamesCountColumn";
            this.RankingGamesCountColumn.ReadOnly = true;
            this.RankingGamesCountColumn.Width = 50;
            // 
            // RankingPointsColumn
            // 
            this.RankingPointsColumn.DataPropertyName = "Points";
            this.RankingPointsColumn.HeaderText = "Score";
            this.RankingPointsColumn.Name = "RankingPointsColumn";
            this.RankingPointsColumn.ReadOnly = true;
            this.RankingPointsColumn.Width = 50;
            // 
            // RankingSetsColumn
            // 
            this.RankingSetsColumn.DataPropertyName = "Goals";
            this.RankingSetsColumn.HeaderText = "Frames";
            this.RankingSetsColumn.Name = "RankingSetsColumn";
            this.RankingSetsColumn.ReadOnly = true;
            this.RankingSetsColumn.Width = 70;
            // 
            // RankingGoalsColumn
            // 
            this.RankingGoalsColumn.DataPropertyName = "Goals";
            this.RankingGoalsColumn.HeaderText = "Frame Scores";
            this.RankingGoalsColumn.Name = "RankingGoalsColumn";
            this.RankingGoalsColumn.ReadOnly = true;
            this.RankingGoalsColumn.Visible = false;
            this.RankingGoalsColumn.Width = 70;
            // 
            // AppWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 20);
            this.ClientSize = new System.Drawing.Size(1138, 559);
            this.Controls.Add(this.AppSplitContainer);
            this.Controls.Add(this.AppMainMenuStrip);
            this.Controls.Add(this.AppStatusStrip);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppWindow";
            this.Text = "POFF Meet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppWindow_FormClosing);
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.AppMainMenuStrip.ResumeLayout(false);
            this.AppMainMenuStrip.PerformLayout();
            this.AppStatusStrip.ResumeLayout(false);
            this.AppStatusStrip.PerformLayout();
            this.AppSplitContainer.Panel1.ResumeLayout(false);
            this.AppSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppSplitContainer)).EndInit();
            this.AppSplitContainer.ResumeLayout(false);
            this.RankingGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RankingGridView)).EndInit();
            this.GamesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GamesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    private MenuStrip AppMainMenuStrip;
    private ToolStripMenuItem TournamentToolStripMenuItem;
    private ToolStripMenuItem AddTeamMenuItem;
    private ToolStripMenuItem SaveMenuItem;
    private ToolStripSeparator AppToolStripMenuItem;
    private ToolStripMenuItem ExitToolStripMenuItem;
    private StatusStrip AppStatusStrip;
    private ToolStripStatusLabel TotalMatchesToolStripStatusLabel;
    private ToolStripStatusLabel PlayedMatchesToolStripStatusLabel;
    private ToolStripStatusLabel SpacerStripStatusLabel;
    private ToolStripStatusLabel PlayedMatchesCountToolStripStatusLabel;
    private ToolStripStatusLabel TotalMatchesCountToolStripStatusLabel;
    private ToolStripDropDownButton PlayerFilterToolStripDropDownButton;
    private ToolStripMenuItem ClipboardMenuItem;
    private ToolStripMenuItem ClipboardTableMenuItem;
    private ToolStripMenuItem ClipboardGamesMenuItem;
    private ToolStripMenuItem ClipboardCopyAllMenuItem;
    private ToolStripMenuItem OpenMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem RemoveTeamMenuItem;
    private ToolStripMenuItem NewMenuItem;
    private ToolStripMenuItem ExportMenuItem;
    private SplitContainer AppSplitContainer;
    private GroupBox GamesGroupBox;
    private ToolStripMenuItem HelpMenuItem;
    private ToolStripMenuItem AboutMenuItem;
    private ToolStripMenuItem RecentMenuItem;
    private DataGridView GamesGridView;
    private GroupBox RankingGroupBox;
    private DataGridView RankingGridView;
    private DataGridViewCheckBoxColumn StatusColumn;
    private DataGridViewTextBoxColumn GameNumberColumn;
    private DataGridViewTextBoxColumn HomeColumn;
    private DataGridViewTextBoxColumn GuestColumn;
    private DataGridViewTextBoxColumn ResultColumn;
    private ComboBox PlayModeComboBox;
    private DataGridViewTextBoxColumn RankingPlaceColumn;
    private DataGridViewTextBoxColumn RankingTeamColumn;
    private DataGridViewTextBoxColumn RankingGamesCountColumn;
    private DataGridViewTextBoxColumn RankingPointsColumn;
    private DataGridViewTextBoxColumn RankingSetsColumn;
    private DataGridViewTextBoxColumn RankingGoalsColumn;
}