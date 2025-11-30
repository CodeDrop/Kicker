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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
        _AppTabControl = new TabControl();
        _TeamsTabPage = new TabPage();
        _TeamsScreenContent = new View.TeamsScreen();
        _MatchesTabPage = new TabPage();
        _MatchListView = new ListView();
        _MatchListView.DoubleClick += new EventHandler(MatchListView_DoubleClick);
        _MatchStatusColumnHeader = new ColumnHeader();
        _MatchNumberColumnHeader = new ColumnHeader();
        _Team1ColumnHeader = new ColumnHeader();
        _Team2ColumnHeader = new ColumnHeader();
        _ResultColumnHeader = new ColumnHeader();
        _MatchImageList = new ImageList(components);
        _ResultsTabPage = new TabPage();
        _StandingListView = new ListView();
        _PlaceColumnHeader = new ColumnHeader();
        _TeamTableColumnHeader = new ColumnHeader();
        _PointsColumnHeader = new ColumnHeader();
        _WonSetsColumnHeader = new ColumnHeader();
        _GoalsColumnHeader = new ColumnHeader();
        _MatchesColumnHeader = new ColumnHeader();
        _AppMainMenuStrip = new MenuStrip();
        _TournamentToolStripMenuItem = new ToolStripMenuItem();
        _NewTeamToolStripMenuItem = new ToolStripMenuItem();
        _NewTeamToolStripMenuItem.Click += new EventHandler(NewTeamMenuItem_Click);
        _CreatePlaylistToolStripMenuItem = new ToolStripMenuItem();
        _CreatePlaylistToolStripMenuItem.Click += new EventHandler(CreateAgendaMenuItem_Click);
        _CopyToolStripMenuItem = new ToolStripMenuItem();
        _SaveToolStripMenuItem = new ToolStripMenuItem();
        _AppToolStripMenuItem = new ToolStripSeparator();
        _ExitToolStripMenuItem = new ToolStripMenuItem();
        _OptionsToolStripMenuItem = new ToolStripMenuItem();
        _OptionMatchDaysToolStripMenuItem = new ToolStripMenuItem();
        _AppStatusStrip = new StatusStrip();
        _SpacerStripStatusLabel = new ToolStripStatusLabel();
        _TotalMatchesToolStripStatusLabel = new ToolStripStatusLabel();
        _TotalMatchesCountToolStripStatusLabel = new ToolStripStatusLabel();
        _PlayedMatchesToolStripStatusLabel = new ToolStripStatusLabel();
        _PlayedMatchesCountToolStripStatusLabel = new ToolStripStatusLabel();
        _PlayerFilterToolStripDropDownButton = new ToolStripDropDownButton();
        _AppTabControl.SuspendLayout();
        _TeamsTabPage.SuspendLayout();
        _MatchesTabPage.SuspendLayout();
        _ResultsTabPage.SuspendLayout();
        _AppMainMenuStrip.SuspendLayout();
        _AppStatusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // AppTabControl
        // 
        _AppTabControl.Controls.Add(_TeamsTabPage);
        _AppTabControl.Controls.Add(_MatchesTabPage);
        _AppTabControl.Controls.Add(_ResultsTabPage);
        _AppTabControl.Dock = DockStyle.Fill;
        _AppTabControl.Location = new Point(0, 24);
        _AppTabControl.Name = "_AppTabControl";
        _AppTabControl.SelectedIndex = 0;
        _AppTabControl.Size = new Size(664, 307);
        _AppTabControl.TabIndex = 0;
        // 
        // TeamsTabPage
        // 
        _TeamsTabPage.Controls.Add(_TeamsScreenContent);
        _TeamsTabPage.Location = new Point(4, 27);
        _TeamsTabPage.Name = "_TeamsTabPage";
        _TeamsTabPage.Size = new Size(656, 276);
        _TeamsTabPage.TabIndex = 0;
        _TeamsTabPage.Text = "Mannschaften";
        // 
        // TeamsScreenContent
        // 
        _TeamsScreenContent.Dock = DockStyle.Fill;
        _TeamsScreenContent.Location = new Point(0, 0);
        _TeamsScreenContent.Name = "_TeamsScreenContent";
        _TeamsScreenContent.Size = new Size(656, 276);
        _TeamsScreenContent.TabIndex = 0;
        // 
        // MatchesTabPage
        // 
        _MatchesTabPage.Controls.Add(_MatchListView);
        _MatchesTabPage.Location = new Point(4, 22);
        _MatchesTabPage.Name = "_MatchesTabPage";
        _MatchesTabPage.Size = new Size(656, 281);
        _MatchesTabPage.TabIndex = 1;
        _MatchesTabPage.Text = "Spiele";
        // 
        // MatchListView
        // 
        _MatchListView.BackColor = Color.LightSteelBlue;
        _MatchListView.Columns.AddRange(new ColumnHeader[] { _MatchStatusColumnHeader, _MatchNumberColumnHeader, _Team1ColumnHeader, _Team2ColumnHeader, _ResultColumnHeader });
        _MatchListView.Dock = DockStyle.Fill;
        _MatchListView.FullRowSelect = true;
        _MatchListView.HideSelection = false;
        _MatchListView.HoverSelection = true;
        _MatchListView.Location = new Point(0, 0);
        _MatchListView.Name = "_MatchListView";
        _MatchListView.Size = new Size(656, 281);
        _MatchListView.SmallImageList = _MatchImageList;
        _MatchListView.TabIndex = 2;
        _MatchListView.UseCompatibleStateImageBehavior = false;
        _MatchListView.View = System.Windows.Forms.View.Details;
        // 
        // MatchStatusColumnHeader
        // 
        _MatchStatusColumnHeader.Text = "";
        _MatchStatusColumnHeader.Width = 50;
        // 
        // MatchNumberColumnHeader
        // 
        _MatchNumberColumnHeader.Text = "N°";
        // 
        // Team1ColumnHeader
        // 
        _Team1ColumnHeader.Text = "Mannschaft 1";
        _Team1ColumnHeader.Width = 200;
        // 
        // Team2ColumnHeader
        // 
        _Team2ColumnHeader.Text = "Mannschaft 2";
        _Team2ColumnHeader.Width = 200;
        // 
        // ResultColumnHeader
        // 
        _ResultColumnHeader.Text = "Ergebnis";
        _ResultColumnHeader.Width = 150;
        // 
        // MatchImageList
        // 
        _MatchImageList.ImageStream = (ImageListStreamer)resources.GetObject("MatchImageList.ImageStream");
        _MatchImageList.TransparentColor = Color.Transparent;
        _MatchImageList.Images.SetKeyName(0, "");
        _MatchImageList.Images.SetKeyName(1, "");
        _MatchImageList.Images.SetKeyName(2, "");
        // 
        // ResultsTabPage
        // 
        _ResultsTabPage.Controls.Add(_StandingListView);
        _ResultsTabPage.Location = new Point(4, 22);
        _ResultsTabPage.Name = "_ResultsTabPage";
        _ResultsTabPage.Size = new Size(656, 281);
        _ResultsTabPage.TabIndex = 2;
        _ResultsTabPage.Text = "Tabelle";
        // 
        // StandingListView
        // 
        _StandingListView.BackColor = Color.LightSteelBlue;
        _StandingListView.Columns.AddRange(new ColumnHeader[] { _PlaceColumnHeader, _TeamTableColumnHeader, _PointsColumnHeader, _WonSetsColumnHeader, _GoalsColumnHeader, _MatchesColumnHeader });
        _StandingListView.Dock = DockStyle.Fill;
        _StandingListView.FullRowSelect = true;
        _StandingListView.HideSelection = false;
        _StandingListView.HoverSelection = true;
        _StandingListView.Location = new Point(0, 0);
        _StandingListView.MultiSelect = false;
        _StandingListView.Name = "_StandingListView";
        _StandingListView.Size = new Size(656, 281);
        _StandingListView.TabIndex = 1;
        _StandingListView.UseCompatibleStateImageBehavior = false;
        _StandingListView.View = System.Windows.Forms.View.Details;
        // 
        // PlaceColumnHeader
        // 
        _PlaceColumnHeader.Text = "Platz";
        _PlaceColumnHeader.Width = 50;
        // 
        // TeamTableColumnHeader
        // 
        _TeamTableColumnHeader.Text = "Mannschaft";
        _TeamTableColumnHeader.Width = 200;
        // 
        // PointsColumnHeader
        // 
        _PointsColumnHeader.Text = "Punkte";
        _PointsColumnHeader.TextAlign = HorizontalAlignment.Right;
        _PointsColumnHeader.Width = 65;
        // 
        // WonSetsColumnHeader
        // 
        _WonSetsColumnHeader.Text = "Sätze";
        _WonSetsColumnHeader.TextAlign = HorizontalAlignment.Right;
        _WonSetsColumnHeader.Width = 55;
        // 
        // GoalsColumnHeader
        // 
        _GoalsColumnHeader.Text = "Tore";
        _GoalsColumnHeader.TextAlign = HorizontalAlignment.Right;
        // 
        // MatchesColumnHeader
        // 
        _MatchesColumnHeader.Text = "Spiele";
        _MatchesColumnHeader.TextAlign = HorizontalAlignment.Right;
        // 
        // AppMainMenuStrip
        // 
        _AppMainMenuStrip.Items.AddRange(new ToolStripItem[] { _TournamentToolStripMenuItem, _OptionsToolStripMenuItem });
        _AppMainMenuStrip.Location = new Point(0, 0);
        _AppMainMenuStrip.Name = "_AppMainMenuStrip";
        _AppMainMenuStrip.Size = new Size(664, 24);
        _AppMainMenuStrip.TabIndex = 1;
        _AppMainMenuStrip.Text = "MenuStrip1";
        // 
        // TournamentToolStripMenuItem
        // 
        _TournamentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _NewTeamToolStripMenuItem, _CreatePlaylistToolStripMenuItem, _CopyToolStripMenuItem, _SaveToolStripMenuItem, _AppToolStripMenuItem, _ExitToolStripMenuItem });
        _TournamentToolStripMenuItem.Name = "_TournamentToolStripMenuItem";
        _TournamentToolStripMenuItem.Size = new Size(57, 20);
        _TournamentToolStripMenuItem.Text = "&Turnier";
        // 
        // NewTeamToolStripMenuItem
        // 
        _NewTeamToolStripMenuItem.Name = "_NewTeamToolStripMenuItem";
        _NewTeamToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        _NewTeamToolStripMenuItem.Size = new Size(292, 22);
        _NewTeamToolStripMenuItem.Text = "&Neue Mannschaft";
        // 
        // CreatePlaylistToolStripMenuItem
        // 
        _CreatePlaylistToolStripMenuItem.Name = "_CreatePlaylistToolStripMenuItem";
        _CreatePlaylistToolStripMenuItem.ShortcutKeys = Keys.F5;
        _CreatePlaylistToolStripMenuItem.Size = new Size(292, 22);
        _CreatePlaylistToolStripMenuItem.Text = "Spiel&plan erstellen";
        // 
        // CopyToolStripMenuItem
        // 
        _CopyToolStripMenuItem.Name = "_CopyToolStripMenuItem";
        _CopyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
        _CopyToolStripMenuItem.Size = new Size(292, 22);
        _CopyToolStripMenuItem.Text = "Kopieren (HTML)";
        // 
        // SaveToolStripMenuItem
        // 
        _SaveToolStripMenuItem.Name = "_SaveToolStripMenuItem";
        _SaveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        _SaveToolStripMenuItem.Size = new Size(292, 22);
        _SaveToolStripMenuItem.Text = "&Speichern";
        // 
        // AppToolStripMenuItem
        // 
        _AppToolStripMenuItem.Name = "_AppToolStripMenuItem";
        _AppToolStripMenuItem.Size = new Size(289, 6);
        // 
        // ExitToolStripMenuItem
        // 
        _ExitToolStripMenuItem.Name = "_ExitToolStripMenuItem";
        _ExitToolStripMenuItem.Size = new Size(292, 22);
        _ExitToolStripMenuItem.Text = "Be&enden";
        // 
        // OptionsToolStripMenuItem
        // 
        _OptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _OptionMatchDaysToolStripMenuItem });
        _OptionsToolStripMenuItem.Name = "_OptionsToolStripMenuItem";
        _OptionsToolStripMenuItem.Size = new Size(69, 20);
        _OptionsToolStripMenuItem.Text = "Optionen";
        // 
        // OptionMatchDaysToolStripMenuItem
        // 
        _OptionMatchDaysToolStripMenuItem.CheckOnClick = true;
        _OptionMatchDaysToolStripMenuItem.Name = "_OptionMatchDaysToolStripMenuItem";
        _OptionMatchDaysToolStripMenuItem.Size = new Size(122, 22);
        _OptionMatchDaysToolStripMenuItem.Text = "Spieltage";
        // 
        // AppStatusStrip
        // 
        _AppStatusStrip.Items.AddRange(new ToolStripItem[] { _PlayerFilterToolStripDropDownButton, _SpacerStripStatusLabel, _TotalMatchesToolStripStatusLabel, _TotalMatchesCountToolStripStatusLabel, _PlayedMatchesToolStripStatusLabel, _PlayedMatchesCountToolStripStatusLabel });
        _AppStatusStrip.Location = new Point(0, 331);
        _AppStatusStrip.Name = "_AppStatusStrip";
        _AppStatusStrip.Size = new Size(664, 22);
        _AppStatusStrip.TabIndex = 2;
        _AppStatusStrip.Text = "StatusStrip1";
        // 
        // SpacerStripStatusLabel
        // 
        _SpacerStripStatusLabel.Name = "_SpacerStripStatusLabel";
        _SpacerStripStatusLabel.Size = new Size(476, 17);
        _SpacerStripStatusLabel.Spring = true;
        // 
        // TotalMatchesToolStripStatusLabel
        // 
        _TotalMatchesToolStripStatusLabel.Name = "_TotalMatchesToolStripStatusLabel";
        _TotalMatchesToolStripStatusLabel.Size = new Size(41, 17);
        _TotalMatchesToolStripStatusLabel.Text = "Spiele:";
        // 
        // TotalMatchesCountToolStripStatusLabel
        // 
        _TotalMatchesCountToolStripStatusLabel.Name = "_TotalMatchesCountToolStripStatusLabel";
        _TotalMatchesCountToolStripStatusLabel.Size = new Size(10, 17);
        _TotalMatchesCountToolStripStatusLabel.Text = ".";
        // 
        // PlayedMatchesToolStripStatusLabel
        // 
        _PlayedMatchesToolStripStatusLabel.Name = "_PlayedMatchesToolStripStatusLabel";
        _PlayedMatchesToolStripStatusLabel.Size = new Size(52, 17);
        _PlayedMatchesToolStripStatusLabel.Text = "Gespielt:";
        // 
        // PlayedMatchesCountToolStripStatusLabel
        // 
        _PlayedMatchesCountToolStripStatusLabel.BorderStyle = Border3DStyle.SunkenInner;
        _PlayedMatchesCountToolStripStatusLabel.Name = "_PlayedMatchesCountToolStripStatusLabel";
        _PlayedMatchesCountToolStripStatusLabel.Size = new Size(10, 17);
        _PlayedMatchesCountToolStripStatusLabel.Text = ".";
        // 
        // PlayerFilterToolStripDropDownButton
        // 
        _PlayerFilterToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        _PlayerFilterToolStripDropDownButton.Image = (Image)resources.GetObject("PlayerFilterToolStripDropDownButton.Image");
        _PlayerFilterToolStripDropDownButton.ImageTransparentColor = Color.Magenta;
        _PlayerFilterToolStripDropDownButton.Name = "_PlayerFilterToolStripDropDownButton";
        _PlayerFilterToolStripDropDownButton.Size = new Size(86, 20);
        _PlayerFilterToolStripDropDownButton.Text = "(Team Filter)";
        // 
        // AppWindow
        // 
        AutoScaleBaseSize = new Size(8, 24);
        ClientSize = new Size(664, 353);
        Controls.Add(_AppTabControl);
        Controls.Add(_AppMainMenuStrip);
        Controls.Add(_AppStatusStrip);
        Font = new Font("Lucida Sans Unicode", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "AppWindow";
        Text = "POFF Kicker";
        _AppTabControl.ResumeLayout(false);
        _TeamsTabPage.ResumeLayout(false);
        _MatchesTabPage.ResumeLayout(false);
        _ResultsTabPage.ResumeLayout(false);
        _AppMainMenuStrip.ResumeLayout(false);
        _AppMainMenuStrip.PerformLayout();
        _AppStatusStrip.ResumeLayout(false);
        _AppStatusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

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
    private ToolStripMenuItem _CopyToolStripMenuItem;

    internal virtual ToolStripMenuItem CopyToolStripMenuItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _CopyToolStripMenuItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _CopyToolStripMenuItem = value;
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