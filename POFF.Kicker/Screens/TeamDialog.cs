using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using POFF.Kicker.Types;

namespace POFF.Kicker.Screens;


public class TeamDialog : Form
{

    #region  Windows Form Designer generated code 

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
    private Label _Label1;

    internal virtual Label Label1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label1 = value;
        }
    }
    private Label _Label2;

    internal virtual Label Label2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label2 = value;
        }
    }
    private Label _Label3;

    internal virtual Label Label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label3 = value;
        }
    }
    private TextBox _TeamTextBox;

    internal virtual TextBox TeamTextBox
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TeamTextBox;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TeamTextBox = value;
        }
    }
    private TextBox _Player1TextBox;

    internal virtual TextBox Player1TextBox
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Player1TextBox;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Player1TextBox = value;
        }
    }
    private TextBox _Player2TextBox;

    internal virtual TextBox Player2TextBox
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Player2TextBox;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Player2TextBox = value;
        }
    }
    private Button _AbortButton;

    internal virtual Button AbortButton
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AbortButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _AbortButton = value;
        }
    }
    private Button _OKButton;

    internal virtual Button OKButton
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _OKButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _OKButton = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _TeamTextBox = new TextBox();
        _Label1 = new Label();
        _Label2 = new Label();
        _Player1TextBox = new TextBox();
        _Label3 = new Label();
        _Player2TextBox = new TextBox();
        _AbortButton = new Button();
        _OKButton = new Button();
        SuspendLayout();
        // 
        // TeamTextBox
        // 
        _TeamTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _TeamTextBox.BackColor = Color.NavajoWhite;
        _TeamTextBox.Location = new Point(120, 16);
        _TeamTextBox.Name = "_TeamTextBox";
        _TeamTextBox.Size = new Size(246, 31);
        _TeamTextBox.TabIndex = 1;
        _TeamTextBox.Text = "";
        // 
        // Label1
        // 
        _Label1.Location = new Point(8, 20);
        _Label1.Name = "_Label1";
        _Label1.Size = new Size(104, 23);
        _Label1.TabIndex = 0;
        _Label1.Text = "&Mannschaft";
        // 
        // Label2
        // 
        _Label2.Location = new Point(8, 68);
        _Label2.Name = "_Label2";
        _Label2.Size = new Size(104, 23);
        _Label2.TabIndex = 2;
        _Label2.Text = "Spieler &1";
        // 
        // Player1TextBox
        // 
        _Player1TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _Player1TextBox.BackColor = Color.BlanchedAlmond;
        _Player1TextBox.Location = new Point(120, 64);
        _Player1TextBox.Name = "_Player1TextBox";
        _Player1TextBox.Size = new Size(246, 31);
        _Player1TextBox.TabIndex = 3;
        _Player1TextBox.Text = "";
        // 
        // Label3
        // 
        _Label3.Location = new Point(8, 108);
        _Label3.Name = "_Label3";
        _Label3.Size = new Size(104, 23);
        _Label3.TabIndex = 4;
        _Label3.Text = "Spieler &2";
        // 
        // Player2TextBox
        // 
        _Player2TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        _Player2TextBox.BackColor = Color.BlanchedAlmond;
        _Player2TextBox.Location = new Point(120, 104);
        _Player2TextBox.Name = "_Player2TextBox";
        _Player2TextBox.Size = new Size(246, 31);
        _Player2TextBox.TabIndex = 5;
        _Player2TextBox.Text = "";
        // 
        // AbortButton
        // 
        _AbortButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _AbortButton.BackColor = SystemColors.Control;
        _AbortButton.DialogResult = DialogResult.Cancel;
        _AbortButton.Location = new Point(272, 150);
        _AbortButton.Name = "_AbortButton";
        _AbortButton.Size = new Size(96, 23);
        _AbortButton.TabIndex = 7;
        _AbortButton.Text = "Abbre&chen";
        // 
        // OKButton
        // 
        _OKButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _OKButton.BackColor = SystemColors.Control;
        _OKButton.DialogResult = DialogResult.OK;
        _OKButton.Location = new Point(168, 150);
        _OKButton.Name = "_OKButton";
        _OKButton.Size = new Size(96, 23);
        _OKButton.TabIndex = 6;
        _OKButton.Text = "&OK";
        // 
        // TeamDialog
        // 
        AcceptButton = _OKButton;
        AutoScaleBaseSize = new Size(8, 24);
        CancelButton = _AbortButton;
        ClientSize = new Size(378, 182);
        ControlBox = false;
        Controls.AddRange(new Control[] { _AbortButton, _OKButton, _Label3, _Player2TextBox, _Label2, _Player1TextBox, _Label1, _TeamTextBox });
        Font = new Font("Lucida Sans Unicode", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "TeamDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        ResumeLayout(false);

    }

    #endregion

    public TeamDialog(TeamInfo team)
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        var viewModel = new TeamDialogViewModel(team);
        TeamInfoValue = team;

        // View <-> ViewModel
        TeamTextBox.DataBindings.Add("Text", team, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
        Player1TextBox.DataBindings.Add("Text", team, "Player1", false, DataSourceUpdateMode.OnPropertyChanged);
        Player2TextBox.DataBindings.Add("Text", team, "Player2", false, DataSourceUpdateMode.OnPropertyChanged);

        OKButton.Click += (s, e) => viewModel.AcceptChanges();

    }

    private readonly TeamInfo TeamInfoValue;
    public TeamInfo TeamInfo
    {
        get
        {
            return TeamInfoValue;
        }
    }

}