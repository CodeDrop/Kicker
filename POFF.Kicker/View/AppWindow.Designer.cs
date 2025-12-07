using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace POFF.Kicker.View;

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
    private TabPage _TeamsTabPage;

    internal virtual TabPage TeamsTabPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TeamsTabPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TeamsTabPage = value;
        }
    }
    private TabPage _MatchesTabPage;

    internal virtual TabPage MatchesTabPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MatchesTabPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _MatchesTabPage = value;
        }
    }
    private TabPage _ResultsTabPage;

    internal virtual TabPage ResultsTabPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ResultsTabPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ResultsTabPage = value;
        }
    }
    private TabControl _AppTabControl;

    internal virtual TabControl AppTabControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AppTabControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _AppTabControl = value;
        }
    }
    private ListView _MatchListView;

    internal virtual ListView MatchListView
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MatchListView;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_MatchListView != null)
            {
                _MatchListView.DoubleClick -= MatchListView_DoubleClick;
            }

            _MatchListView = value;
            if (_MatchListView != null)
            {
                _MatchListView.DoubleClick += MatchListView_DoubleClick;
            }
        }
    }
    private ColumnHeader _Team1ColumnHeader;

    internal virtual ColumnHeader Team1ColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Team1ColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Team1ColumnHeader = value;
        }
    }
    private ColumnHeader _Team2ColumnHeader;

    internal virtual ColumnHeader Team2ColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Team2ColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Team2ColumnHeader = value;
        }
    }
    private ImageList _MatchImageList;

    internal virtual ImageList MatchImageList
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MatchImageList;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _MatchImageList = value;
        }
    }
    private ColumnHeader _ResultColumnHeader;

    internal virtual ColumnHeader ResultColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ResultColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ResultColumnHeader = value;
        }
    }
    private ListView _StandingListView;

    internal virtual ListView StandingListView
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _StandingListView;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _StandingListView = value;
        }
    }
    private ColumnHeader _PlaceColumnHeader;

    internal virtual ColumnHeader PlaceColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PlaceColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PlaceColumnHeader = value;
        }
    }
    private ColumnHeader _TeamTableColumnHeader;

    internal virtual ColumnHeader TeamTableColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TeamTableColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TeamTableColumnHeader = value;
        }
    }
    private ColumnHeader _PointsColumnHeader;

    internal virtual ColumnHeader PointsColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PointsColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PointsColumnHeader = value;
        }
    }
    private ColumnHeader _GoalsColumnHeader;

    internal virtual ColumnHeader GoalsColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _GoalsColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _GoalsColumnHeader = value;
        }
    }
    private ColumnHeader _MatchesColumnHeader;

    internal virtual ColumnHeader MatchesColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MatchesColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _MatchesColumnHeader = value;
        }
    }
    private ColumnHeader _WonSetsColumnHeader;

    internal virtual ColumnHeader WonSetsColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _WonSetsColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _WonSetsColumnHeader = value;
        }
    }
    private ColumnHeader _MatchStatusColumnHeader;

    internal virtual ColumnHeader MatchStatusColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MatchStatusColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _MatchStatusColumnHeader = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this._AppTabControl = new System.Windows.Forms.TabControl();
            this._TeamsTabPage = new System.Windows.Forms.TabPage();
            this._TeamsScreenContent = new POFF.Kicker.View.TeamsScreen();
            this._MatchesTabPage = new System.Windows.Forms.TabPage();
            this._MatchListView = new System.Windows.Forms.ListView();
            this._MatchStatusColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._MatchNumberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._Team1ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._Team2ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._ResultColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._MatchImageList = new System.Windows.Forms.ImageList(this.components);
            this._ResultsTabPage = new System.Windows.Forms.TabPage();
            this._StandingListView = new System.Windows.Forms.ListView();
            this._PlaceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._TeamTableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._PointsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._WonSetsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._GoalsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._MatchesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._AppMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this._TournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._NewTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CreatePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._AppToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this._ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._OptionMatchDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardGamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._AppStatusStrip = new System.Windows.Forms.StatusStrip();
            this._PlayerFilterToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._SpacerStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._TotalMatchesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._TotalMatchesCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._PlayedMatchesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._PlayedMatchesCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._AppTabControl.SuspendLayout();
            this._TeamsTabPage.SuspendLayout();
            this._MatchesTabPage.SuspendLayout();
            this._ResultsTabPage.SuspendLayout();
            this._AppMainMenuStrip.SuspendLayout();
            this._AppStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _AppTabControl
            // 
            this._AppTabControl.Controls.Add(this._TeamsTabPage);
            this._AppTabControl.Controls.Add(this._MatchesTabPage);
            this._AppTabControl.Controls.Add(this._ResultsTabPage);
            this._AppTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._AppTabControl.Location = new System.Drawing.Point(0, 24);
            this._AppTabControl.Name = "_AppTabControl";
            this._AppTabControl.SelectedIndex = 0;
            this._AppTabControl.Size = new System.Drawing.Size(664, 307);
            this._AppTabControl.TabIndex = 0;
            // 
            // _TeamsTabPage
            // 
            this._TeamsTabPage.Controls.Add(this._TeamsScreenContent);
            this._TeamsTabPage.Location = new System.Drawing.Point(4, 27);
            this._TeamsTabPage.Name = "_TeamsTabPage";
            this._TeamsTabPage.Size = new System.Drawing.Size(656, 276);
            this._TeamsTabPage.TabIndex = 0;
            this._TeamsTabPage.Text = "Mannschaften";
            // 
            // _TeamsScreenContent
            // 
            this._TeamsScreenContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TeamsScreenContent.Location = new System.Drawing.Point(0, 0);
            this._TeamsScreenContent.Name = "_TeamsScreenContent";
            this._TeamsScreenContent.Size = new System.Drawing.Size(656, 276);
            this._TeamsScreenContent.TabIndex = 0;
            // 
            // _MatchesTabPage
            // 
            this._MatchesTabPage.Controls.Add(this._MatchListView);
            this._MatchesTabPage.Location = new System.Drawing.Point(4, 22);
            this._MatchesTabPage.Name = "_MatchesTabPage";
            this._MatchesTabPage.Size = new System.Drawing.Size(656, 281);
            this._MatchesTabPage.TabIndex = 1;
            this._MatchesTabPage.Text = "Spiele";
            // 
            // _MatchListView
            // 
            this._MatchListView.BackColor = System.Drawing.Color.LightSteelBlue;
            this._MatchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._MatchStatusColumnHeader,
            this._MatchNumberColumnHeader,
            this._Team1ColumnHeader,
            this._Team2ColumnHeader,
            this._ResultColumnHeader});
            this._MatchListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MatchListView.FullRowSelect = true;
            this._MatchListView.HideSelection = false;
            this._MatchListView.HoverSelection = true;
            this._MatchListView.Location = new System.Drawing.Point(0, 0);
            this._MatchListView.Name = "_MatchListView";
            this._MatchListView.Size = new System.Drawing.Size(656, 281);
            this._MatchListView.SmallImageList = this._MatchImageList;
            this._MatchListView.TabIndex = 2;
            this._MatchListView.UseCompatibleStateImageBehavior = false;
            this._MatchListView.View = System.Windows.Forms.View.Details;
            this._MatchListView.DoubleClick += new System.EventHandler(this.MatchListView_DoubleClick);
            // 
            // _MatchStatusColumnHeader
            // 
            this._MatchStatusColumnHeader.Text = "";
            this._MatchStatusColumnHeader.Width = 50;
            // 
            // _MatchNumberColumnHeader
            // 
            this._MatchNumberColumnHeader.Text = "N°";
            // 
            // _Team1ColumnHeader
            // 
            this._Team1ColumnHeader.Text = "Mannschaft 1";
            this._Team1ColumnHeader.Width = 200;
            // 
            // _Team2ColumnHeader
            // 
            this._Team2ColumnHeader.Text = "Mannschaft 2";
            this._Team2ColumnHeader.Width = 200;
            // 
            // _ResultColumnHeader
            // 
            this._ResultColumnHeader.Text = "Ergebnis";
            this._ResultColumnHeader.Width = 150;
            // 
            // _MatchImageList
            // 
            this._MatchImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_MatchImageList.ImageStream")));
            this._MatchImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._MatchImageList.Images.SetKeyName(0, "");
            this._MatchImageList.Images.SetKeyName(1, "");
            this._MatchImageList.Images.SetKeyName(2, "");
            // 
            // _ResultsTabPage
            // 
            this._ResultsTabPage.Controls.Add(this._StandingListView);
            this._ResultsTabPage.Location = new System.Drawing.Point(4, 22);
            this._ResultsTabPage.Name = "_ResultsTabPage";
            this._ResultsTabPage.Size = new System.Drawing.Size(656, 281);
            this._ResultsTabPage.TabIndex = 2;
            this._ResultsTabPage.Text = "Tabelle";
            // 
            // _StandingListView
            // 
            this._StandingListView.BackColor = System.Drawing.Color.LightSteelBlue;
            this._StandingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._PlaceColumnHeader,
            this._TeamTableColumnHeader,
            this._PointsColumnHeader,
            this._WonSetsColumnHeader,
            this._GoalsColumnHeader,
            this._MatchesColumnHeader});
            this._StandingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._StandingListView.FullRowSelect = true;
            this._StandingListView.HideSelection = false;
            this._StandingListView.HoverSelection = true;
            this._StandingListView.Location = new System.Drawing.Point(0, 0);
            this._StandingListView.MultiSelect = false;
            this._StandingListView.Name = "_StandingListView";
            this._StandingListView.Size = new System.Drawing.Size(656, 281);
            this._StandingListView.TabIndex = 1;
            this._StandingListView.UseCompatibleStateImageBehavior = false;
            this._StandingListView.View = System.Windows.Forms.View.Details;
            // 
            // _PlaceColumnHeader
            // 
            this._PlaceColumnHeader.Text = "Platz";
            this._PlaceColumnHeader.Width = 50;
            // 
            // _TeamTableColumnHeader
            // 
            this._TeamTableColumnHeader.Text = "Mannschaft";
            this._TeamTableColumnHeader.Width = 200;
            // 
            // _PointsColumnHeader
            // 
            this._PointsColumnHeader.Text = "Punkte";
            this._PointsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._PointsColumnHeader.Width = 65;
            // 
            // _WonSetsColumnHeader
            // 
            this._WonSetsColumnHeader.Text = "Sätze";
            this._WonSetsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._WonSetsColumnHeader.Width = 55;
            // 
            // _GoalsColumnHeader
            // 
            this._GoalsColumnHeader.Text = "Tore";
            this._GoalsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _MatchesColumnHeader
            // 
            this._MatchesColumnHeader.Text = "Spiele";
            this._MatchesColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _AppMainMenuStrip
            // 
            this._AppMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._TournamentToolStripMenuItem,
            this.ClipboardMenuItem,
            this._OptionsToolStripMenuItem});
            this._AppMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this._AppMainMenuStrip.Name = "_AppMainMenuStrip";
            this._AppMainMenuStrip.Size = new System.Drawing.Size(664, 24);
            this._AppMainMenuStrip.TabIndex = 1;
            this._AppMainMenuStrip.Text = "MenuStrip1";
            // 
            // _TournamentToolStripMenuItem
            // 
            this._TournamentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._NewTeamToolStripMenuItem,
            this._CreatePlaylistToolStripMenuItem,
            this._SaveToolStripMenuItem,
            this._AppToolStripMenuItem,
            this._ExitToolStripMenuItem});
            this._TournamentToolStripMenuItem.Name = "_TournamentToolStripMenuItem";
            this._TournamentToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this._TournamentToolStripMenuItem.Text = "&Turnier";
            // 
            // _NewTeamToolStripMenuItem
            // 
            this._NewTeamToolStripMenuItem.Name = "_NewTeamToolStripMenuItem";
            this._NewTeamToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._NewTeamToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this._NewTeamToolStripMenuItem.Text = "&Neue Mannschaft";
            this._NewTeamToolStripMenuItem.Click += new System.EventHandler(this.NewTeamMenuItem_Click);
            // 
            // _CreatePlaylistToolStripMenuItem
            // 
            this._CreatePlaylistToolStripMenuItem.Name = "_CreatePlaylistToolStripMenuItem";
            this._CreatePlaylistToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._CreatePlaylistToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this._CreatePlaylistToolStripMenuItem.Text = "Spiel&plan erstellen";
            this._CreatePlaylistToolStripMenuItem.Click += new System.EventHandler(this.CreateAgendaMenuItem_Click);
            // 
            // _SaveToolStripMenuItem
            // 
            this._SaveToolStripMenuItem.Name = "_SaveToolStripMenuItem";
            this._SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._SaveToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this._SaveToolStripMenuItem.Text = "&Speichern";
            // 
            // _AppToolStripMenuItem
            // 
            this._AppToolStripMenuItem.Name = "_AppToolStripMenuItem";
            this._AppToolStripMenuItem.Size = new System.Drawing.Size(210, 6);
            // 
            // _ExitToolStripMenuItem
            // 
            this._ExitToolStripMenuItem.Name = "_ExitToolStripMenuItem";
            this._ExitToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this._ExitToolStripMenuItem.Text = "Be&enden";
            // 
            // _OptionsToolStripMenuItem
            // 
            this._OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._OptionMatchDaysToolStripMenuItem});
            this._OptionsToolStripMenuItem.Name = "_OptionsToolStripMenuItem";
            this._OptionsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this._OptionsToolStripMenuItem.Text = "Optionen";
            // 
            // _OptionMatchDaysToolStripMenuItem
            // 
            this._OptionMatchDaysToolStripMenuItem.CheckOnClick = true;
            this._OptionMatchDaysToolStripMenuItem.Name = "_OptionMatchDaysToolStripMenuItem";
            this._OptionMatchDaysToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this._OptionMatchDaysToolStripMenuItem.Text = "Spieltage";
            // 
            // ClipboardMenuItem
            // 
            this.ClipboardMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClipboardTableMenuItem,
            this.ClipboardGamesMenuItem});
            this.ClipboardMenuItem.Name = "ClipboardMenuItem";
            this.ClipboardMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ClipboardMenuItem.Text = "Clipboard";
            // 
            // ClipboardTableMenuItem
            // 
            this.ClipboardTableMenuItem.Name = "ClipboardTableMenuItem";
            this.ClipboardTableMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ClipboardTableMenuItem.Text = "Tabelle (HTML)";
            // 
            // ClipboardGamesMenuItem
            // 
            this.ClipboardGamesMenuItem.Name = "ClipboardGamesMenuItem";
            this.ClipboardGamesMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ClipboardGamesMenuItem.Text = "Spiele (HTML)";
            // 
            // _AppStatusStrip
            // 
            this._AppStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._PlayerFilterToolStripDropDownButton,
            this._SpacerStripStatusLabel,
            this._TotalMatchesToolStripStatusLabel,
            this._TotalMatchesCountToolStripStatusLabel,
            this._PlayedMatchesToolStripStatusLabel,
            this._PlayedMatchesCountToolStripStatusLabel});
            this._AppStatusStrip.Location = new System.Drawing.Point(0, 331);
            this._AppStatusStrip.Name = "_AppStatusStrip";
            this._AppStatusStrip.Size = new System.Drawing.Size(664, 22);
            this._AppStatusStrip.TabIndex = 2;
            this._AppStatusStrip.Text = "StatusStrip1";
            // 
            // _PlayerFilterToolStripDropDownButton
            // 
            this._PlayerFilterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._PlayerFilterToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("_PlayerFilterToolStripDropDownButton.Image")));
            this._PlayerFilterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._PlayerFilterToolStripDropDownButton.Name = "_PlayerFilterToolStripDropDownButton";
            this._PlayerFilterToolStripDropDownButton.Size = new System.Drawing.Size(86, 20);
            this._PlayerFilterToolStripDropDownButton.Text = "(Team Filter)";
            // 
            // _SpacerStripStatusLabel
            // 
            this._SpacerStripStatusLabel.Name = "_SpacerStripStatusLabel";
            this._SpacerStripStatusLabel.Size = new System.Drawing.Size(450, 17);
            this._SpacerStripStatusLabel.Spring = true;
            // 
            // _TotalMatchesToolStripStatusLabel
            // 
            this._TotalMatchesToolStripStatusLabel.Name = "_TotalMatchesToolStripStatusLabel";
            this._TotalMatchesToolStripStatusLabel.Size = new System.Drawing.Size(41, 17);
            this._TotalMatchesToolStripStatusLabel.Text = "Spiele:";
            // 
            // _TotalMatchesCountToolStripStatusLabel
            // 
            this._TotalMatchesCountToolStripStatusLabel.Name = "_TotalMatchesCountToolStripStatusLabel";
            this._TotalMatchesCountToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this._TotalMatchesCountToolStripStatusLabel.Text = ".";
            // 
            // _PlayedMatchesToolStripStatusLabel
            // 
            this._PlayedMatchesToolStripStatusLabel.Name = "_PlayedMatchesToolStripStatusLabel";
            this._PlayedMatchesToolStripStatusLabel.Size = new System.Drawing.Size(52, 17);
            this._PlayedMatchesToolStripStatusLabel.Text = "Gespielt:";
            // 
            // _PlayedMatchesCountToolStripStatusLabel
            // 
            this._PlayedMatchesCountToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this._PlayedMatchesCountToolStripStatusLabel.Name = "_PlayedMatchesCountToolStripStatusLabel";
            this._PlayedMatchesCountToolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this._PlayedMatchesCountToolStripStatusLabel.Text = ".";
            // 
            // AppWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 24);
            this.ClientSize = new System.Drawing.Size(664, 353);
            this.Controls.Add(this._AppTabControl);
            this.Controls.Add(this._AppMainMenuStrip);
            this.Controls.Add(this._AppStatusStrip);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppWindow";
            this.Text = "POFF Kicker";
            this._AppTabControl.ResumeLayout(false);
            this._TeamsTabPage.ResumeLayout(false);
            this._MatchesTabPage.ResumeLayout(false);
            this._ResultsTabPage.ResumeLayout(false);
            this._AppMainMenuStrip.ResumeLayout(false);
            this._AppMainMenuStrip.PerformLayout();
            this._AppStatusStrip.ResumeLayout(false);
            this._AppStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    private MenuStrip _AppMainMenuStrip;

    internal virtual MenuStrip AppMainMenuStrip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AppMainMenuStrip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _AppMainMenuStrip = value;
        }
    }
    private ToolStripMenuItem _TournamentToolStripMenuItem;

    internal virtual ToolStripMenuItem TournamentToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TournamentToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TournamentToolStripMenuItem = value;
        }
    }
    private ToolStripMenuItem _NewTeamToolStripMenuItem;

    internal virtual ToolStripMenuItem NewTeamToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NewTeamToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NewTeamToolStripMenuItem != null)
            {
                _NewTeamToolStripMenuItem.Click -= NewTeamMenuItem_Click;
            }

            _NewTeamToolStripMenuItem = value;
            if (_NewTeamToolStripMenuItem != null)
            {
                _NewTeamToolStripMenuItem.Click += NewTeamMenuItem_Click;
            }
        }
    }
    private ToolStripMenuItem _CreatePlaylistToolStripMenuItem;

    internal virtual ToolStripMenuItem CreatePlaylistToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _CreatePlaylistToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_CreatePlaylistToolStripMenuItem != null)
            {
                _CreatePlaylistToolStripMenuItem.Click -= CreateAgendaMenuItem_Click;
            }

            _CreatePlaylistToolStripMenuItem = value;
            if (_CreatePlaylistToolStripMenuItem != null)
            {
                _CreatePlaylistToolStripMenuItem.Click += CreateAgendaMenuItem_Click;
            }
        }
    }
    private ToolStripMenuItem _SaveToolStripMenuItem;

    internal virtual ToolStripMenuItem SaveToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SaveToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SaveToolStripMenuItem = value;
        }
    }
    private ToolStripSeparator _AppToolStripMenuItem;

    internal virtual ToolStripSeparator AppToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AppToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _AppToolStripMenuItem = value;
        }
    }
    private ToolStripMenuItem _ExitToolStripMenuItem;

    internal virtual ToolStripMenuItem ExitToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ExitToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ExitToolStripMenuItem = value;
        }
    }
    private View.TeamsScreen _TeamsScreenContent;

    internal virtual View.TeamsScreen TeamsScreenContent
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TeamsScreenContent;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TeamsScreenContent = value;
        }
    }

    private ColumnHeader _MatchNumberColumnHeader;

    internal virtual ColumnHeader MatchNumberColumnHeader
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _MatchNumberColumnHeader;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _MatchNumberColumnHeader = value;
        }
    }
    private StatusStrip _AppStatusStrip;

    private StatusStrip AppStatusStrip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AppStatusStrip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _AppStatusStrip = value;
        }
    }
    private ToolStripStatusLabel _TotalMatchesToolStripStatusLabel;

    private ToolStripStatusLabel TotalMatchesToolStripStatusLabel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TotalMatchesToolStripStatusLabel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TotalMatchesToolStripStatusLabel = value;
        }
    }
    private ToolStripStatusLabel _PlayedMatchesToolStripStatusLabel;

    private ToolStripStatusLabel PlayedMatchesToolStripStatusLabel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PlayedMatchesToolStripStatusLabel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PlayedMatchesToolStripStatusLabel = value;
        }
    }
    private ToolStripStatusLabel _SpacerStripStatusLabel;

    private ToolStripStatusLabel SpacerStripStatusLabel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SpacerStripStatusLabel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SpacerStripStatusLabel = value;
        }
    }
    private ToolStripStatusLabel _PlayedMatchesCountToolStripStatusLabel;

    private ToolStripStatusLabel PlayedMatchesCountToolStripStatusLabel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PlayedMatchesCountToolStripStatusLabel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PlayedMatchesCountToolStripStatusLabel = value;
        }
    }
    private ToolStripStatusLabel _TotalMatchesCountToolStripStatusLabel;

    private ToolStripStatusLabel TotalMatchesCountToolStripStatusLabel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TotalMatchesCountToolStripStatusLabel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TotalMatchesCountToolStripStatusLabel = value;
        }
    }
    private ToolStripMenuItem _OptionsToolStripMenuItem;

    internal virtual ToolStripMenuItem OptionsToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _OptionsToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _OptionsToolStripMenuItem = value;
        }
    }
    private ToolStripMenuItem _OptionMatchDaysToolStripMenuItem;

    internal virtual ToolStripMenuItem OptionMatchDaysToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _OptionMatchDaysToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _OptionMatchDaysToolStripMenuItem = value;
        }
    }
    private ToolStripDropDownButton _PlayerFilterToolStripDropDownButton;
    private ToolStripMenuItem ClipboardMenuItem;
    private ToolStripMenuItem ClipboardTableMenuItem;
    private ToolStripMenuItem ClipboardGamesMenuItem;

    private ToolStripDropDownButton PlayerFilterToolStripDropDownButton
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PlayerFilterToolStripDropDownButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PlayerFilterToolStripDropDownButton = value;
        }
    }
}