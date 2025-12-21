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
        this.TeamsScreenContent = new POFF.Meet.View.TeamsScreen();
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
        this.AppTabControl.SuspendLayout();
        this.TeamsTabPage.SuspendLayout();
        this.MatchesTabPage.SuspendLayout();
        this.ResultsTabPage.SuspendLayout();
        this.AppMainMenuStrip.SuspendLayout();
        this.AppStatusStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // _AppTabControl
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
        // _TeamsTabPage
        // 
        this.TeamsTabPage.Controls.Add(this.TeamsScreenContent);
        this.TeamsTabPage.Location = new System.Drawing.Point(4, 27);
        this.TeamsTabPage.Name = "TeamsTabPage";
        this.TeamsTabPage.Size = new System.Drawing.Size(656, 276);
        this.TeamsTabPage.TabIndex = 0;
        this.TeamsTabPage.Text = "Mannschaften";
        // 
        // _TeamsScreenContent
        // 
        this.TeamsScreenContent.Dock = System.Windows.Forms.DockStyle.Fill;
        this.TeamsScreenContent.Location = new System.Drawing.Point(0, 0);
        this.TeamsScreenContent.Name = "TeamsScreenContent";
        this.TeamsScreenContent.Size = new System.Drawing.Size(656, 276);
        this.TeamsScreenContent.TabIndex = 0;
        // 
        // _MatchesTabPage
        // 
        this.MatchesTabPage.Controls.Add(this.MatchListView);
        this.MatchesTabPage.Location = new System.Drawing.Point(4, 22);
        this.MatchesTabPage.Name = "MatchesTabPage";
        this.MatchesTabPage.Size = new System.Drawing.Size(656, 281);
        this.MatchesTabPage.TabIndex = 1;
        this.MatchesTabPage.Text = "Spiele";
        // 
        // _MatchListView
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
        // _MatchStatusColumnHeader
        // 
        this.MatchStatusColumnHeader.Text = "";
        this.MatchStatusColumnHeader.Width = 50;
        // 
        // _MatchNumberColumnHeader
        // 
        this.MatchNumberColumnHeader.Text = "N°";
        // 
        // _Team1ColumnHeader
        // 
        this.Team1ColumnHeader.Text = "Mannschaft 1";
        this.Team1ColumnHeader.Width = 200;
        // 
        // _Team2ColumnHeader
        // 
        this.Team2ColumnHeader.Text = "Mannschaft 2";
        this.Team2ColumnHeader.Width = 200;
        // 
        // _ResultColumnHeader
        // 
        this.ResultColumnHeader.Text = "Ergebnis";
        this.ResultColumnHeader.Width = 150;
        // 
        // _MatchImageList
        // 
        this.MatchImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_MatchImageList.ImageStream")));
        this.MatchImageList.TransparentColor = System.Drawing.Color.Transparent;
        this.MatchImageList.Images.SetKeyName(0, "");
        this.MatchImageList.Images.SetKeyName(1, "");
        this.MatchImageList.Images.SetKeyName(2, "");
        // 
        // _ResultsTabPage
        // 
        this.ResultsTabPage.Controls.Add(this.StandingListView);
        this.ResultsTabPage.Location = new System.Drawing.Point(4, 22);
        this.ResultsTabPage.Name = "ResultsTabPage";
        this.ResultsTabPage.Size = new System.Drawing.Size(656, 281);
        this.ResultsTabPage.TabIndex = 2;
        this.ResultsTabPage.Text = "Tabelle";
        // 
        // _StandingListView
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
        // _PlaceColumnHeader
        // 
        this.PlaceColumnHeader.Text = "Platz";
        this.PlaceColumnHeader.Width = 50;
        // 
        // _TeamTableColumnHeader
        // 
        this.TeamTableColumnHeader.Text = "Mannschaft";
        this.TeamTableColumnHeader.Width = 200;
        // 
        // _PointsColumnHeader
        // 
        this.PointsColumnHeader.Text = "Punkte";
        this.PointsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.PointsColumnHeader.Width = 65;
        // 
        // _WonSetsColumnHeader
        // 
        this.WonSetsColumnHeader.Text = "Sätze";
        this.WonSetsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.WonSetsColumnHeader.Width = 55;
        // 
        // _GoalsColumnHeader
        // 
        this.GoalsColumnHeader.Text = "Tore";
        this.GoalsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // _MatchesColumnHeader
        // 
        this.MatchesColumnHeader.Text = "Spiele";
        this.MatchesColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // _AppMainMenuStrip
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
        // _TournamentToolStripMenuItem
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
        // _AppToolStripMenuItem
        // 
        this.AppToolStripMenuItem.Name = "AppToolStripMenuItem";
        this.AppToolStripMenuItem.Size = new System.Drawing.Size(236, 6);
        // 
        // _ExitToolStripMenuItem
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
        // _AppStatusStrip
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
        // _PlayerFilterToolStripDropDownButton
        // 
        this.PlayerFilterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.PlayerFilterToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("_PlayerFilterToolStripDropDownButton.Image")));
        this.PlayerFilterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.PlayerFilterToolStripDropDownButton.Name = "PlayerFilterToolStripDropDownButton";
        this.PlayerFilterToolStripDropDownButton.Size = new System.Drawing.Size(86, 20);
        this.PlayerFilterToolStripDropDownButton.Text = "(Team Filter)";
        this.PlayerFilterToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlayerFilterDropDownButton_ItemClicked);
        // 
        // _SpacerStripStatusLabel
        // 
        this.SpacerStripStatusLabel.Name = "SpacerStripStatusLabel";
        this.SpacerStripStatusLabel.Size = new System.Drawing.Size(450, 17);
        this.SpacerStripStatusLabel.Spring = true;
        // 
        // _TotalMatchesToolStripStatusLabel
        // 
        this.TotalMatchesToolStripStatusLabel.Name = "TotalMatchesToolStripStatusLabel";
        this.TotalMatchesToolStripStatusLabel.Size = new System.Drawing.Size(41, 17);
        this.TotalMatchesToolStripStatusLabel.Text = "Spiele:";
        // 
        // _TotalMatchesCountToolStripStatusLabel
        // 
        this.TotalMatchesCountToolStripStatusLabel.Name = "TotalMatchesCountToolStripStatusLabel";
        this.TotalMatchesCountToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
        this.TotalMatchesCountToolStripStatusLabel.Text = ".";
        // 
        // _PlayedMatchesToolStripStatusLabel
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
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    private MenuStrip AppMainMenuStrip;
    private ToolStripMenuItem TournamentToolStripMenuItem;
    private ToolStripMenuItem AddTeamMenuItem;
    private ToolStripMenuItem SaveMenuItem;
    private ToolStripSeparator AppToolStripMenuItem;
    private ToolStripMenuItem ExitToolStripMenuItem;
    private View.TeamsScreen TeamsScreenContent;
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
}