Namespace Screens

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TeamsScreen
        Inherits System.Windows.Forms.UserControl

        'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Wird vom Windows Form-Designer benötigt.
        Private components As System.ComponentModel.IContainer

        'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.TeamsDataGridView = New System.Windows.Forms.DataGridView()
            Me.TeamContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.DeleteTeamMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.WithdrawTeamMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.TeamNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Player1Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Player2Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Zurückgezogen = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            CType(Me.TeamsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TeamContextMenuStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'TeamsDataGridView
            '
            Me.TeamsDataGridView.AllowUserToAddRows = False
            Me.TeamsDataGridView.AllowUserToDeleteRows = False
            Me.TeamsDataGridView.AllowUserToResizeRows = False
            Me.TeamsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.TeamsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TeamNameColumn, Me.Player1Column, Me.Player2Column, Me.Zurückgezogen})
            Me.TeamsDataGridView.ContextMenuStrip = Me.TeamContextMenuStrip
            Me.TeamsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TeamsDataGridView.Location = New System.Drawing.Point(0, 0)
            Me.TeamsDataGridView.MultiSelect = False
            Me.TeamsDataGridView.Name = "TeamsDataGridView"
            Me.TeamsDataGridView.ReadOnly = True
            Me.TeamsDataGridView.RowHeadersVisible = False
            Me.TeamsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.TeamsDataGridView.Size = New System.Drawing.Size(492, 282)
            Me.TeamsDataGridView.TabIndex = 2
            '
            'TeamContextMenuStrip
            '
            Me.TeamContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WithdrawTeamMenuItem, Me.DeleteTeamMenuItem})
            Me.TeamContextMenuStrip.Name = "TeamContextMenuStrip"
            Me.TeamContextMenuStrip.Size = New System.Drawing.Size(146, 48)
            '
            'DeleteTeamMenuItem
            '
            Me.DeleteTeamMenuItem.Name = "DeleteTeamMenuItem"
            Me.DeleteTeamMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
            Me.DeleteTeamMenuItem.Size = New System.Drawing.Size(180, 22)
            Me.DeleteTeamMenuItem.Text = "Löschen"
            '
            'WithdrawTeamMenuItem
            '
            Me.WithdrawTeamMenuItem.Name = "WithdrawTeamMenuItem"
            Me.WithdrawTeamMenuItem.Size = New System.Drawing.Size(180, 22)
            Me.WithdrawTeamMenuItem.Text = "Zurückziehen"
            '
            'TeamNameColumn
            '
            Me.TeamNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.TeamNameColumn.DataPropertyName = "Name"
            Me.TeamNameColumn.FillWeight = 50.0!
            Me.TeamNameColumn.HeaderText = "Mannschaft"
            Me.TeamNameColumn.Name = "TeamNameColumn"
            Me.TeamNameColumn.ReadOnly = True
            '
            'Player1Column
            '
            Me.Player1Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.Player1Column.DataPropertyName = "Player1"
            Me.Player1Column.FillWeight = 25.0!
            Me.Player1Column.HeaderText = "Spieler 1"
            Me.Player1Column.Name = "Player1Column"
            Me.Player1Column.ReadOnly = True
            '
            'Player2Column
            '
            Me.Player2Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.Player2Column.DataPropertyName = "Player2"
            Me.Player2Column.FillWeight = 25.0!
            Me.Player2Column.HeaderText = "Spieler 2"
            Me.Player2Column.Name = "Player2Column"
            Me.Player2Column.ReadOnly = True
            '
            'Zurückgezogen
            '
            Me.Zurückgezogen.DataPropertyName = "Withdrawn"
            Me.Zurückgezogen.HeaderText = "Zurückgezogen"
            Me.Zurückgezogen.Name = "Zurückgezogen"
            Me.Zurückgezogen.ReadOnly = True
            Me.Zurückgezogen.Visible = False
            '
            'TeamsScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TeamsDataGridView)
            Me.Name = "TeamsScreen"
            Me.Size = New System.Drawing.Size(492, 282)
            CType(Me.TeamsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TeamContextMenuStrip.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents TeamsDataGridView As System.Windows.Forms.DataGridView
        Private WithEvents TeamContextMenuStrip As System.Windows.Forms.ContextMenuStrip
        Private WithEvents DeleteTeamMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents WithdrawTeamMenuItem As ToolStripMenuItem
        Friend WithEvents TeamNameColumn As DataGridViewTextBoxColumn
        Friend WithEvents Player1Column As DataGridViewTextBoxColumn
        Friend WithEvents Player2Column As DataGridViewTextBoxColumn
        Friend WithEvents Zurückgezogen As DataGridViewCheckBoxColumn
    End Class

End Namespace