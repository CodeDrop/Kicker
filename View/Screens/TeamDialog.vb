Imports POFF.Kicker.ViewModel.Screens
Imports POFF.Kicker.ViewModel.Types

Namespace Screens

    Public Class TeamDialog
        Inherits Form

#Region " Windows Form Designer generated code "

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(disposing As Boolean)
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
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents TeamTextBox As TextBox
        Friend WithEvents Player1TextBox As TextBox
        Friend WithEvents Player2TextBox As TextBox
        Friend WithEvents AbortButton As Button
        Friend WithEvents OKButton As Button
        <DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.TeamTextBox = New TextBox()
            Me.Label1 = New Label()
            Me.Label2 = New Label()
            Me.Player1TextBox = New TextBox()
            Me.Label3 = New Label()
            Me.Player2TextBox = New TextBox()
            Me.AbortButton = New Button()
            Me.OKButton = New Button()
            Me.SuspendLayout()
            '
            'TeamTextBox
            '
            Me.TeamTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TeamTextBox.BackColor = System.Drawing.Color.NavajoWhite
            Me.TeamTextBox.Location = New Point(120, 16)
            Me.TeamTextBox.Name = "TeamTextBox"
            Me.TeamTextBox.Size = New Size(246, 31)
            Me.TeamTextBox.TabIndex = 1
            Me.TeamTextBox.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New Point(8, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New Size(104, 23)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "&Mannschaft"
            '
            'Label2
            '
            Me.Label2.Location = New Point(8, 68)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New Size(104, 23)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Spieler &1"
            '
            'Player1TextBox
            '
            Me.Player1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Player1TextBox.BackColor = System.Drawing.Color.BlanchedAlmond
            Me.Player1TextBox.Location = New Point(120, 64)
            Me.Player1TextBox.Name = "Player1TextBox"
            Me.Player1TextBox.Size = New Size(246, 31)
            Me.Player1TextBox.TabIndex = 3
            Me.Player1TextBox.Text = ""
            '
            'Label3
            '
            Me.Label3.Location = New Point(8, 108)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New Size(104, 23)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Spieler &2"
            '
            'Player2TextBox
            '
            Me.Player2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Player2TextBox.BackColor = System.Drawing.Color.BlanchedAlmond
            Me.Player2TextBox.Location = New Point(120, 104)
            Me.Player2TextBox.Name = "Player2TextBox"
            Me.Player2TextBox.Size = New Size(246, 31)
            Me.Player2TextBox.TabIndex = 5
            Me.Player2TextBox.Text = ""
            '
            'AbortButton
            '
            Me.AbortButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.AbortButton.BackColor = System.Drawing.SystemColors.Control
            Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.AbortButton.Location = New Point(272, 150)
            Me.AbortButton.Name = "AbortButton"
            Me.AbortButton.Size = New Size(96, 23)
            Me.AbortButton.TabIndex = 7
            Me.AbortButton.Text = "Abbre&chen"
            '
            'OKButton
            '
            Me.OKButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.OKButton.BackColor = System.Drawing.SystemColors.Control
            Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.OKButton.Location = New Point(168, 150)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.Size = New Size(96, 23)
            Me.OKButton.TabIndex = 6
            Me.OKButton.Text = "&OK"
            '
            'TeamDialog
            '
            Me.AcceptButton = Me.OKButton
            Me.AutoScaleBaseSize = New Size(8, 24)
            Me.CancelButton = Me.AbortButton
            Me.ClientSize = New Size(378, 182)
            Me.ControlBox = False
            Me.Controls.AddRange(New Control() {Me.AbortButton, Me.OKButton, Me.Label3, Me.Player2TextBox, Me.Label2, Me.Player1TextBox, Me.Label1, Me.TeamTextBox})
            Me.Font = New Font("Lucida Sans Unicode", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "TeamDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Sub New(team As TeamInfo)

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Dim viewModel = New TeamDialogViewModel(team)
            TeamInfoValue = team

            ' View <-> ViewModel
            TeamTextBox.DataBindings.Add("Text", team, "Name", False, DataSourceUpdateMode.OnPropertyChanged)
            Player1TextBox.DataBindings.Add("Text", team, "Player1", False, DataSourceUpdateMode.OnPropertyChanged)
            Player2TextBox.DataBindings.Add("Text", team, "Player2", False, DataSourceUpdateMode.OnPropertyChanged)

            AddHandler OKButton.Click, Sub() ViewModel.AcceptChanges()

        End Sub

        Private ReadOnly TeamInfoValue As TeamInfo
        Public ReadOnly Property TeamInfo As TeamInfo
            Get
                Return TeamInfoValue
            End Get
        End Property

    End Class

End Namespace