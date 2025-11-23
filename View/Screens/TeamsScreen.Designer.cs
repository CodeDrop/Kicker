using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace POFF.Kicker.View.Screens
{
    public partial class TeamsScreen : UserControl
    {

        // UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;

        // Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        // Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        // Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TeamsDataGridView = new DataGridView();
            TeamsDataGridView.DoubleClick += new EventHandler(TeamsDataGridView_DoubleClick);
            TeamsDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(TeamsDataGridView_CellFormatting);
            TeamsDataGridView.CellMouseDown += new DataGridViewCellMouseEventHandler(TeamsDataGridView_CellMouseDown);
            TeamContextMenuStrip = new ContextMenuStrip(components);
            TeamContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(TeamContextMenu_Popup);
            WithdrawTeamMenuItem = new ToolStripMenuItem();
            WithdrawTeamMenuItem.Click += new EventHandler(WithdrawTeamMenuItem_Click);
            DeleteTeamMenuItem = new ToolStripMenuItem();
            DeleteTeamMenuItem.Click += new EventHandler(DeleteTeamMenuItem_Click);
            Nr = new DataGridViewTextBoxColumn();
            TeamNameColumn = new DataGridViewTextBoxColumn();
            Player1Column = new DataGridViewTextBoxColumn();
            Player2Column = new DataGridViewTextBoxColumn();
            Zurückgezogen = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)TeamsDataGridView).BeginInit();
            TeamContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TeamsDataGridView
            // 
            TeamsDataGridView.AllowUserToAddRows = false;
            TeamsDataGridView.AllowUserToDeleteRows = false;
            TeamsDataGridView.AllowUserToResizeRows = false;
            TeamsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TeamsDataGridView.Columns.AddRange(new DataGridViewColumn[] { Nr, TeamNameColumn, Player1Column, Player2Column, Zurückgezogen });
            TeamsDataGridView.ContextMenuStrip = TeamContextMenuStrip;
            TeamsDataGridView.Dock = DockStyle.Fill;
            TeamsDataGridView.Location = new Point(0, 0);
            TeamsDataGridView.MultiSelect = false;
            TeamsDataGridView.Name = "TeamsDataGridView";
            TeamsDataGridView.ReadOnly = true;
            TeamsDataGridView.RowHeadersVisible = false;
            TeamsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TeamsDataGridView.Size = new Size(492, 282);
            TeamsDataGridView.TabIndex = 2;
            // 
            // TeamContextMenuStrip
            // 
            TeamContextMenuStrip.Items.AddRange(new ToolStripItem[] { WithdrawTeamMenuItem, DeleteTeamMenuItem });
            TeamContextMenuStrip.Name = "TeamContextMenuStrip";
            TeamContextMenuStrip.Size = new Size(147, 48);
            // 
            // WithdrawTeamMenuItem
            // 
            WithdrawTeamMenuItem.Name = "WithdrawTeamMenuItem";
            WithdrawTeamMenuItem.Size = new Size(146, 22);
            WithdrawTeamMenuItem.Text = "Zurückziehen";
            // 
            // DeleteTeamMenuItem
            // 
            DeleteTeamMenuItem.Name = "DeleteTeamMenuItem";
            DeleteTeamMenuItem.ShortcutKeys = Keys.Delete;
            DeleteTeamMenuItem.Size = new Size(146, 22);
            DeleteTeamMenuItem.Text = "Löschen";
            // 
            // Nr
            // 
            Nr.HeaderText = "Nr";
            Nr.Name = "Nr";
            Nr.ReadOnly = true;
            Nr.Width = 40;
            // 
            // TeamNameColumn
            // 
            TeamNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TeamNameColumn.DataPropertyName = "Name";
            TeamNameColumn.FillWeight = 50.0f;
            TeamNameColumn.HeaderText = "Mannschaft";
            TeamNameColumn.Name = "TeamNameColumn";
            TeamNameColumn.ReadOnly = true;
            // 
            // Player1Column
            // 
            Player1Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Player1Column.DataPropertyName = "Player1";
            Player1Column.FillWeight = 25.0f;
            Player1Column.HeaderText = "Spieler 1";
            Player1Column.Name = "Player1Column";
            Player1Column.ReadOnly = true;
            // 
            // Player2Column
            // 
            Player2Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Player2Column.DataPropertyName = "Player2";
            Player2Column.FillWeight = 25.0f;
            Player2Column.HeaderText = "Spieler 2";
            Player2Column.Name = "Player2Column";
            Player2Column.ReadOnly = true;
            // 
            // Zurückgezogen
            // 
            Zurückgezogen.DataPropertyName = "Withdrawn";
            Zurückgezogen.HeaderText = "Zurückgezogen";
            Zurückgezogen.Name = "Zurückgezogen";
            Zurückgezogen.ReadOnly = true;
            Zurückgezogen.Visible = false;
            // 
            // TeamsScreen
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TeamsDataGridView);
            Name = "TeamsScreen";
            Size = new Size(492, 282);
            ((System.ComponentModel.ISupportInitialize)TeamsDataGridView).EndInit();
            TeamContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);

        }
        private DataGridView TeamsDataGridView;
        private ContextMenuStrip TeamContextMenuStrip;
        private ToolStripMenuItem DeleteTeamMenuItem;
        internal ToolStripMenuItem WithdrawTeamMenuItem;
        internal DataGridViewTextBoxColumn Nr;
        internal DataGridViewTextBoxColumn TeamNameColumn;
        internal DataGridViewTextBoxColumn Player1Column;
        internal DataGridViewTextBoxColumn Player2Column;
        internal DataGridViewCheckBoxColumn Zurückgezogen;
    }

}