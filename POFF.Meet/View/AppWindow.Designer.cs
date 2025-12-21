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

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    private TabPage TeamsTabPage;
    private TabPage MatchesTabPage;
    private TabPage ResultsTabPage;
    private TabControl AppTabControl;
    private ListView MatchListView;
    private ColumnHeader Team1ColumnHeader;
    private ColumnHeader Team2ColumnHeader;
    private ImageList MatchImageList;
    private ColumnHeader ResultColumnHeader;
    private ListView StandingListView;
    private ColumnHeader PlaceColumnHeader;
    private ColumnHeader TeamTableColumnHeader;
    private ColumnHeader PointsColumnHeader;
    private ColumnHeader GoalsColumnHeader;
    private ColumnHeader MatchesColumnHeader;
    private ColumnHeader WonSetsColumnHeader;
    private ColumnHeader MatchStatusColumnHeader;

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.AppTabControl = new System.Windows.Forms.TabControl();
            this.TeamsTabPage = new System.Windows.Forms.TabPage();
            this.MatchesTabPage = new System.Windows.Forms.TabPage();
            this.MatchListView = new System.Windows.Forms.ListView();
            this.MatchStatusColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MatchNumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Team1ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Team2ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MatchImageList = new System.Windows.Forms.ImageList(this.components);
            this.ResultsTabPage = new System.Windows.Forms.TabPage();
            this.StandingListView = new System.Windows.Forms.ListView();
            this.PlaceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TeamTableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PointsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WonSetsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GoalsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MatchesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AppMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.TournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddTeamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTeamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardGamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardCopyAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppStatusStrip = new System.Windows.Forms.StatusStrip();
            this.PlayerFilterToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SpacerStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMatchesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMatchesCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayedMatchesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayedMatchesCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TeamsDataGridView = new System.Windows.Forms.DataGridView();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zurückgezogen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AppTabControl.SuspendLayout();
            this.TeamsTabPage.SuspendLayout();
            this.MatchesTabPage.SuspendLayout();
            this.ResultsTabPage.SuspendLayout();
            this.AppMainMenuStrip.SuspendLayout();
            this.AppStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AppTabControl
            // 
            this.AppTabControl.Controls.Add(this.TeamsTabPage);
            this.AppTabControl.Controls.Add(this.MatchesTabPage);
            this.AppTabControl.Controls.Add(this.ResultsTabPage);
            this.AppTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppTabControl.Location = new System.Drawing.Point(0, 24);
            this.AppTabControl.Name = "AppTabControl";
            this.AppTabControl.SelectedIndex = 0;
            this.AppTabControl.Size = new System.Drawing.Size(664, 307);
            this.AppTabControl.TabIndex = 0;
            // 
            // TeamsTabPage
            // 
            this.TeamsTabPage.Controls.Add(this.TeamsDataGridView);
            this.TeamsTabPage.Location = new System.Drawing.Point(4, 27);
            this.TeamsTabPage.Name = "TeamsTabPage";
            this.TeamsTabPage.Size = new System.Drawing.Size(656, 276);
            this.TeamsTabPage.TabIndex = 0;
            this.TeamsTabPage.Text = "Mannschaften";
            // 
            // MatchesTabPage
            // 
            this.MatchesTabPage.Controls.Add(this.MatchListView);
            this.MatchesTabPage.Location = new System.Drawing.Point(4, 22);
            this.MatchesTabPage.Name = "MatchesTabPage";
            this.MatchesTabPage.Size = new System.Drawing.Size(656, 281);
            this.MatchesTabPage.TabIndex = 1;
            this.MatchesTabPage.Text = "Spiele";
            // 
            // MatchListView
            // 
            this.MatchListView.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MatchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MatchStatusColumnHeader,
            this.MatchNumberColumnHeader,
            this.Team1ColumnHeader,
            this.Team2ColumnHeader,
            this.ResultColumnHeader});
            this.MatchListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MatchListView.FullRowSelect = true;
            this.MatchListView.HideSelection = false;
            this.MatchListView.HoverSelection = true;
            this.MatchListView.Location = new System.Drawing.Point(0, 0);
            this.MatchListView.Name = "MatchListView";
            this.MatchListView.Size = new System.Drawing.Size(656, 281);
            this.MatchListView.SmallImageList = this.MatchImageList;
            this.MatchListView.TabIndex = 2;
            this.MatchListView.UseCompatibleStateImageBehavior = false;
            this.MatchListView.View = System.Windows.Forms.View.Details;
            this.MatchListView.DoubleClick += new System.EventHandler(this.MatchListView_DoubleClick);
            // 
            // MatchStatusColumnHeader
            // 
            this.MatchStatusColumnHeader.Text = "";
            this.MatchStatusColumnHeader.Width = 50;
            // 
            // MatchNumberColumnHeader
            // 
            this.MatchNumberColumnHeader.Text = "N°";
            // 
            // Team1ColumnHeader
            // 
            this.Team1ColumnHeader.Text = "Mannschaft 1";
            this.Team1ColumnHeader.Width = 200;
            // 
            // Team2ColumnHeader
            // 
            this.Team2ColumnHeader.Text = "Mannschaft 2";
            this.Team2ColumnHeader.Width = 200;
            // 
            // ResultColumnHeader
            // 
            this.ResultColumnHeader.Text = "Ergebnis";
            this.ResultColumnHeader.Width = 150;
            // 
            // MatchImageList
            // 
            this.MatchImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MatchImageList.ImageStream")));
            this.MatchImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MatchImageList.Images.SetKeyName(0, "");
            this.MatchImageList.Images.SetKeyName(1, "");
            this.MatchImageList.Images.SetKeyName(2, "");
            // 
            // ResultsTabPage
            // 
            this.ResultsTabPage.Controls.Add(this.StandingListView);
            this.ResultsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ResultsTabPage.Name = "ResultsTabPage";
            this.ResultsTabPage.Size = new System.Drawing.Size(656, 281);
            this.ResultsTabPage.TabIndex = 2;
            this.ResultsTabPage.Text = "Tabelle";
            // 
            // StandingListView
            // 
            this.StandingListView.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StandingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PlaceColumnHeader,
            this.TeamTableColumnHeader,
            this.PointsColumnHeader,
            this.WonSetsColumnHeader,
            this.GoalsColumnHeader,
            this.MatchesColumnHeader});
            this.StandingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandingListView.FullRowSelect = true;
            this.StandingListView.HideSelection = false;
            this.StandingListView.HoverSelection = true;
            this.StandingListView.Location = new System.Drawing.Point(0, 0);
            this.StandingListView.MultiSelect = false;
            this.StandingListView.Name = "StandingListView";
            this.StandingListView.Size = new System.Drawing.Size(656, 281);
            this.StandingListView.TabIndex = 1;
            this.StandingListView.UseCompatibleStateImageBehavior = false;
            this.StandingListView.View = System.Windows.Forms.View.Details;
            // 
            // PlaceColumnHeader
            // 
            this.PlaceColumnHeader.Text = "Platz";
            this.PlaceColumnHeader.Width = 50;
            // 
            // TeamTableColumnHeader
            // 
            this.TeamTableColumnHeader.Text = "Mannschaft";
            this.TeamTableColumnHeader.Width = 200;
            // 
            // PointsColumnHeader
            // 
            this.PointsColumnHeader.Text = "Punkte";
            this.PointsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PointsColumnHeader.Width = 65;
            // 
            // WonSetsColumnHeader
            // 
            this.WonSetsColumnHeader.Text = "Sätze";
            this.WonSetsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.WonSetsColumnHeader.Width = 55;
            // 
            // GoalsColumnHeader
            // 
            this.GoalsColumnHeader.Text = "Tore";
            this.GoalsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MatchesColumnHeader
            // 
            this.MatchesColumnHeader.Text = "Spiele";
            this.MatchesColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AppMainMenuStrip
            // 
            this.AppMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TournamentToolStripMenuItem,
            this.ClipboardMenuItem});
            this.AppMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.AppMainMenuStrip.Name = "AppMainMenuStrip";
            this.AppMainMenuStrip.Size = new System.Drawing.Size(664, 24);
            this.AppMainMenuStrip.TabIndex = 1;
            this.AppMainMenuStrip.Text = "MenuStrip1";
            // 
            // TournamentToolStripMenuItem
            // 
            this.TournamentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.toolStripMenuItem1,
            this.AddTeamMenuItem,
            this.RemoveTeamMenuItem,
            this.AppToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.TournamentToolStripMenuItem.Name = "TournamentToolStripMenuItem";
            this.TournamentToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.TournamentToolStripMenuItem.Text = "&Turnier";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(239, 22);
            this.OpenMenuItem.Text = "Öffnen";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenuItem.Size = new System.Drawing.Size(239, 22);
            this.SaveMenuItem.Text = "&Speichern";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(236, 6);
            // 
            // AddTeamMenuItem
            // 
            this.AddTeamMenuItem.Name = "AddTeamMenuItem";
            this.AddTeamMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.AddTeamMenuItem.Size = new System.Drawing.Size(239, 22);
            this.AddTeamMenuItem.Text = "Mannschaft hinzufügen";
            this.AddTeamMenuItem.Click += new System.EventHandler(this.AddTeamMenuItem_Click);
            // 
            // RemoveTeamMenuItem
            // 
            this.RemoveTeamMenuItem.Name = "RemoveTeamMenuItem";
            this.RemoveTeamMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.RemoveTeamMenuItem.Size = new System.Drawing.Size(239, 22);
            this.RemoveTeamMenuItem.Text = "Mannschaft entfernen";
            this.RemoveTeamMenuItem.Click += new System.EventHandler(this.RemoveTeamMenuItem_Click);
            // 
            // AppToolStripMenuItem
            // 
            this.AppToolStripMenuItem.Name = "AppToolStripMenuItem";
            this.AppToolStripMenuItem.Size = new System.Drawing.Size(236, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.ExitToolStripMenuItem.Text = "Be&enden";
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
            this.ClipboardGamesMenuItem.Size = new System.Drawing.Size(279, 22);
            this.ClipboardGamesMenuItem.Text = "Spiele (HTML)";
            this.ClipboardGamesMenuItem.Click += new System.EventHandler(this.ClipboardGamesMenuItem_Click);
            // 
            // ClipboardTableMenuItem
            // 
            this.ClipboardTableMenuItem.Name = "ClipboardTableMenuItem";
            this.ClipboardTableMenuItem.Size = new System.Drawing.Size(279, 22);
            this.ClipboardTableMenuItem.Text = "Tabelle (HTML)";
            this.ClipboardTableMenuItem.Click += new System.EventHandler(this.ClipboardTableMenuItem_Click);
            // 
            // ClipboardCopyAllMenuItem
            // 
            this.ClipboardCopyAllMenuItem.Name = "ClipboardCopyAllMenuItem";
            this.ClipboardCopyAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.ClipboardCopyAllMenuItem.Size = new System.Drawing.Size(279, 22);
            this.ClipboardCopyAllMenuItem.Text = "Beides (HTML)";
            this.ClipboardCopyAllMenuItem.Click += new System.EventHandler(this.ClipboardCopyAllMenuItem_Click);
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
            this.AppStatusStrip.Location = new System.Drawing.Point(0, 331);
            this.AppStatusStrip.Name = "AppStatusStrip";
            this.AppStatusStrip.Size = new System.Drawing.Size(664, 22);
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
            this.SpacerStripStatusLabel.Size = new System.Drawing.Size(450, 17);
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
            // TeamsDataGridView
            // 
            this.TeamsDataGridView.AllowUserToAddRows = false;
            this.TeamsDataGridView.AllowUserToDeleteRows = false;
            this.TeamsDataGridView.AllowUserToResizeRows = false;
            this.TeamsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nr,
            this.TeamNameColumn,
            this.Player1Column,
            this.Player2Column,
            this.Zurückgezogen});
            this.TeamsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.TeamsDataGridView.MultiSelect = false;
            this.TeamsDataGridView.Name = "TeamsDataGridView";
            this.TeamsDataGridView.ReadOnly = true;
            this.TeamsDataGridView.RowHeadersVisible = false;
            this.TeamsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TeamsDataGridView.Size = new System.Drawing.Size(656, 276);
            this.TeamsDataGridView.TabIndex = 3;
            this.TeamsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TeamsDataGridView_CellFormatting);
            this.TeamsDataGridView.SelectionChanged += new System.EventHandler(this.TeamsDataGridView_SelectionChanged);
            this.TeamsDataGridView.DoubleClick += new System.EventHandler(this.TeamsDataGridView_DoubleClick);
            // 
            // Nr
            // 
            this.Nr.HeaderText = "Nr";
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            this.Nr.Width = 40;
            // 
            // TeamNameColumn
            // 
            this.TeamNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamNameColumn.DataPropertyName = "Name";
            this.TeamNameColumn.FillWeight = 50F;
            this.TeamNameColumn.HeaderText = "Mannschaft";
            this.TeamNameColumn.Name = "TeamNameColumn";
            this.TeamNameColumn.ReadOnly = true;
            // 
            // Player1Column
            // 
            this.Player1Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Player1Column.DataPropertyName = "Player1";
            this.Player1Column.FillWeight = 25F;
            this.Player1Column.HeaderText = "Spieler 1";
            this.Player1Column.Name = "Player1Column";
            this.Player1Column.ReadOnly = true;
            // 
            // Player2Column
            // 
            this.Player2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Player2Column.DataPropertyName = "Player2";
            this.Player2Column.FillWeight = 25F;
            this.Player2Column.HeaderText = "Spieler 2";
            this.Player2Column.Name = "Player2Column";
            this.Player2Column.ReadOnly = true;
            // 
            // Zurückgezogen
            // 
            this.Zurückgezogen.DataPropertyName = "Withdrawn";
            this.Zurückgezogen.HeaderText = "Zurückgezogen";
            this.Zurückgezogen.Name = "Zurückgezogen";
            this.Zurückgezogen.ReadOnly = true;
            this.Zurückgezogen.Visible = false;
            // 
            // AppWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 24);
            this.ClientSize = new System.Drawing.Size(664, 353);
            this.Controls.Add(this.AppTabControl);
            this.Controls.Add(this.AppMainMenuStrip);
            this.Controls.Add(this.AppStatusStrip);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppWindow";
            this.Text = "POFF Turnier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppWindow_FormClosing);
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.AppTabControl.ResumeLayout(false);
            this.TeamsTabPage.ResumeLayout(false);
            this.MatchesTabPage.ResumeLayout(false);
            this.ResultsTabPage.ResumeLayout(false);
            this.AppMainMenuStrip.ResumeLayout(false);
            this.AppMainMenuStrip.PerformLayout();
            this.AppStatusStrip.ResumeLayout(false);
            this.AppStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    private MenuStrip AppMainMenuStrip;
    private ToolStripMenuItem TournamentToolStripMenuItem;
    private ToolStripMenuItem AddTeamMenuItem;
    private ToolStripMenuItem SaveMenuItem;
    private ToolStripSeparator AppToolStripMenuItem;
    private ToolStripMenuItem ExitToolStripMenuItem;
    private ColumnHeader MatchNumberColumnHeader;
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
    private DataGridView TeamsDataGridView;
    internal DataGridViewTextBoxColumn Nr;
    internal DataGridViewTextBoxColumn TeamNameColumn;
    internal DataGridViewTextBoxColumn Player1Column;
    internal DataGridViewTextBoxColumn Player2Column;
    internal DataGridViewCheckBoxColumn Zurückgezogen;
}