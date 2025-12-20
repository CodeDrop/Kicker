using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace POFF.Meet.View;

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
            this.TeamsDataGridView = new System.Windows.Forms.DataGridView();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Player2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zurückgezogen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.TeamsDataGridView.Size = new System.Drawing.Size(492, 282);
            this.TeamsDataGridView.TabIndex = 2;
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
            // TeamsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TeamsDataGridView);
            this.Name = "TeamsScreen";
            this.Size = new System.Drawing.Size(492, 282);
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).EndInit();
            this.ResumeLayout(false);

    }
    private DataGridView TeamsDataGridView;
    internal DataGridViewTextBoxColumn Nr;
    internal DataGridViewTextBoxColumn TeamNameColumn;
    internal DataGridViewTextBoxColumn Player1Column;
    internal DataGridViewTextBoxColumn Player2Column;
    internal DataGridViewCheckBoxColumn Zurückgezogen;
}