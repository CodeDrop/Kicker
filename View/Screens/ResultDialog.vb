Imports POFF.Kicker.Model
Imports POFF.Kicker.ViewModel.Screens

Namespace Screens

    Public Class ResultDialog
        Inherits Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

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
        Friend WithEvents OKButton As Button
        Friend WithEvents AbortButton As Button
        Friend WithEvents SetResultImageList As ImageList
        Private WithEvents SetResultDataGrid As DataGrid
        Friend WithEvents DataGridTableStyle1 As DataGridTableStyle
        Friend WithEvents DataGridTextBoxColumn1 As DataGridTextBoxColumn
        Friend WithEvents DataGridTextBoxColumn2 As DataGridTextBoxColumn
        Friend WithEvents VersusLabel As Label
        Friend WithEvents Team2Label As Label
        Friend WithEvents Team1Label As Label
        <DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New ComponentModel.Container()
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ResultDialog))
            Me.OKButton = New Button()
            Me.AbortButton = New Button()
            Me.SetResultImageList = New ImageList(Me.components)
            Me.SetResultDataGrid = New DataGrid()
            Me.DataGridTableStyle1 = New DataGridTableStyle()
            Me.DataGridTextBoxColumn1 = New DataGridTextBoxColumn()
            Me.DataGridTextBoxColumn2 = New DataGridTextBoxColumn()
            Me.VersusLabel = New Label()
            Me.Team2Label = New Label()
            Me.Team1Label = New Label()
            CType(Me.SetResultDataGrid, ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'OKButton
            '
            Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
            Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.OKButton.Location = New Point(144, 232)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.Size = New Size(96, 23)
            Me.OKButton.TabIndex = 6
            Me.OKButton.Text = "&OK"
            '
            'AbortButton
            '
            Me.AbortButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
            Me.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.AbortButton.Location = New Point(248, 232)
            Me.AbortButton.Name = "AbortButton"
            Me.AbortButton.Size = New Size(96, 23)
            Me.AbortButton.TabIndex = 7
            Me.AbortButton.Text = "Abbre&chen"
            '
            'SetResultImageList
            '
            Me.SetResultImageList.ImageStream = CType(resources.GetObject("SetResultImageList.ImageStream"), ImageListStreamer)
            Me.SetResultImageList.TransparentColor = System.Drawing.Color.Transparent
            Me.SetResultImageList.Images.SetKeyName(0, "")
            '
            'SetResultDataGrid
            '
            Me.SetResultDataGrid.AllowSorting = False
            Me.SetResultDataGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), AnchorStyles)
            Me.SetResultDataGrid.CaptionFont = New Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SetResultDataGrid.CaptionVisible = False
            Me.SetResultDataGrid.DataMember = ""
            Me.SetResultDataGrid.Font = New Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SetResultDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.SetResultDataGrid.Location = New Point(80, 128)
            Me.SetResultDataGrid.Name = "SetResultDataGrid"
            Me.SetResultDataGrid.PreferredRowHeight = 14
            Me.SetResultDataGrid.RowHeadersVisible = False
            Me.SetResultDataGrid.RowHeaderWidth = 0
            Me.SetResultDataGrid.Size = New Size(187, 96)
            Me.SetResultDataGrid.TabIndex = 14
            Me.SetResultDataGrid.TableStyles.AddRange(New DataGridTableStyle() {Me.DataGridTableStyle1})
            '
            'DataGridTableStyle1
            '
            Me.DataGridTableStyle1.ColumnHeadersVisible = False
            Me.DataGridTableStyle1.DataGrid = Me.SetResultDataGrid
            Me.DataGridTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2})
            Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGridTableStyle1.MappingName = "SetResult"
            Me.DataGridTableStyle1.PreferredColumnWidth = 186
            Me.DataGridTableStyle1.RowHeaderWidth = 0
            '
            'DataGridTextBoxColumn1
            '
            Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.DataGridTextBoxColumn1.Format = ""
            Me.DataGridTextBoxColumn1.FormatInfo = Nothing
            Me.DataGridTextBoxColumn1.HeaderText = "Heim"
            Me.DataGridTextBoxColumn1.MappingName = "Home"
            Me.DataGridTextBoxColumn1.Width = 45
            '
            'DataGridTextBoxColumn2
            '
            Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.DataGridTextBoxColumn2.Format = ""
            Me.DataGridTextBoxColumn2.FormatInfo = Nothing
            Me.DataGridTextBoxColumn2.HeaderText = "Gast"
            Me.DataGridTextBoxColumn2.MappingName = "Guest"
            Me.DataGridTextBoxColumn2.Width = 45
            '
            'VersusLabel
            '
            Me.VersusLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.VersusLabel.BackColor = System.Drawing.Color.Transparent
            Me.VersusLabel.Font = New Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.VersusLabel.Location = New Point(112, 48)
            Me.VersusLabel.Name = "VersusLabel"
            Me.VersusLabel.Size = New Size(120, 23)
            Me.VersusLabel.TabIndex = 15
            Me.VersusLabel.Text = "gegen"
            Me.VersusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Team2Label
            '
            Me.Team2Label.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Team2Label.BackColor = System.Drawing.Color.NavajoWhite
            Me.Team2Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Team2Label.Font = New Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Team2Label.Location = New Point(40, 80)
            Me.Team2Label.Name = "Team2Label"
            Me.Team2Label.Size = New Size(303, 32)
            Me.Team2Label.TabIndex = 17
            Me.Team2Label.Text = "[Mannschaft 2]"
            Me.Team2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Team1Label
            '
            Me.Team1Label.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Team1Label.BackColor = System.Drawing.Color.NavajoWhite
            Me.Team1Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Team1Label.Font = New Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Team1Label.Location = New Point(8, 8)
            Me.Team1Label.Name = "Team1Label"
            Me.Team1Label.Size = New Size(304, 32)
            Me.Team1Label.TabIndex = 16
            Me.Team1Label.Text = "[Mannschaft 1]"
            Me.Team1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ResultDialog
            '
            Me.AcceptButton = Me.OKButton
            Me.AutoScaleBaseSize = New Size(8, 24)
            Me.CancelButton = Me.AbortButton
            Me.ClientSize = New Size(354, 262)
            Me.ControlBox = False
            Me.Controls.Add(Me.VersusLabel)
            Me.Controls.Add(Me.Team2Label)
            Me.Controls.Add(Me.Team1Label)
            Me.Controls.Add(Me.SetResultDataGrid)
            Me.Controls.Add(Me.AbortButton)
            Me.Controls.Add(Me.OKButton)
            Me.Font = New Font("Lucida Sans Unicode", 11.25!)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "ResultDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            CType(Me.SetResultDataGrid, ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Sub New(match As Match)
            MyClass.New()
            ViewModel = New ResultDialogViewModel(match)

            Team1Label.DataBindings.Add("Text", ViewModel, "Team1")
            Team2Label.DataBindings.Add("Text", ViewModel, "Team2")
            SetResultDataGrid.DataSource = ViewModel.SetResultInputs

            AddHandler OKButton.Click, Sub() ViewModel.FillResult()
        End Sub

        Private ReadOnly ViewModel As ResultDialogViewModel

        Private ReadOnly ResultValue As Result
        Public ReadOnly Property Result() As Result
            Get
                Return ViewModel.Result
            End Get
        End Property

    End Class

End Namespace