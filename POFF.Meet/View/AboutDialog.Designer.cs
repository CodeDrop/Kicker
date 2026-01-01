namespace POFF.Meet.View;

partial class AboutDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.ProductLabel = new System.Windows.Forms.Label();
        this.VersionLabel = new System.Windows.Forms.Label();
        this.MeetingIdHeaderLabel = new System.Windows.Forms.Label();
        this.MeetingIdLabel = new System.Windows.Forms.Label();
        this.CopyMeetingIdButton = new System.Windows.Forms.Button();
        this.AboutDialogToolTip = new System.Windows.Forms.ToolTip(this.components);
        this.CloseButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // pictureBox1
        // 
        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
        this.pictureBox1.Image = global::POFF.Meet.Properties.Resources.POFF_Meet_jpg;
        this.pictureBox1.Location = new System.Drawing.Point(0, 0);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(228, 230);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox1.TabIndex = 0;
        this.pictureBox1.TabStop = false;
        // 
        // ProductLabel
        // 
        this.ProductLabel.AutoSize = true;
        this.ProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ProductLabel.Location = new System.Drawing.Point(242, 15);
        this.ProductLabel.Name = "ProductLabel";
        this.ProductLabel.Size = new System.Drawing.Size(100, 20);
        this.ProductLabel.TabIndex = 1;
        this.ProductLabel.Text = "POFF Meet";
        // 
        // VersionLabel
        // 
        this.VersionLabel.AutoSize = true;
        this.VersionLabel.Location = new System.Drawing.Point(242, 38);
        this.VersionLabel.Name = "VersionLabel";
        this.VersionLabel.Size = new System.Drawing.Size(48, 13);
        this.VersionLabel.TabIndex = 2;
        this.VersionLabel.Text = "[Version]";
        // 
        // MeetingIdHeaderLabel
        // 
        this.MeetingIdHeaderLabel.AutoSize = true;
        this.MeetingIdHeaderLabel.Location = new System.Drawing.Point(242, 83);
        this.MeetingIdHeaderLabel.Name = "MeetingIdHeaderLabel";
        this.MeetingIdHeaderLabel.Size = new System.Drawing.Size(62, 13);
        this.MeetingIdHeaderLabel.TabIndex = 3;
        this.MeetingIdHeaderLabel.Text = "Meeting ID:";
        // 
        // MeetingIdLabel
        // 
        this.MeetingIdLabel.AutoSize = true;
        this.MeetingIdLabel.Location = new System.Drawing.Point(243, 96);
        this.MeetingIdLabel.Name = "MeetingIdLabel";
        this.MeetingIdLabel.Size = new System.Drawing.Size(65, 13);
        this.MeetingIdLabel.TabIndex = 4;
        this.MeetingIdLabel.Text = "[Meeting ID]";
        // 
        // CopyMeetingIdButton
        // 
        this.CopyMeetingIdButton.Image = global::POFF.Meet.Properties.Resources.copy_icon_png;
        this.CopyMeetingIdButton.Location = new System.Drawing.Point(245, 112);
        this.CopyMeetingIdButton.Name = "CopyMeetingIdButton";
        this.CopyMeetingIdButton.Size = new System.Drawing.Size(32, 32);
        this.CopyMeetingIdButton.TabIndex = 5;
        this.CopyMeetingIdButton.UseVisualStyleBackColor = true;
        this.CopyMeetingIdButton.Click += new System.EventHandler(this.CopyMeetingIdButton_Click);
        // 
        // CloseButton
        // 
        this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.CloseButton.Location = new System.Drawing.Point(374, 195);
        this.CloseButton.Name = "CloseButton";
        this.CloseButton.Size = new System.Drawing.Size(75, 23);
        this.CloseButton.TabIndex = 0;
        this.CloseButton.Text = "Cl&ose";
        this.CloseButton.UseVisualStyleBackColor = true;
        this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
        // 
        // AboutDialog
        // 
        this.AcceptButton = this.CloseButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.CloseButton;
        this.ClientSize = new System.Drawing.Size(461, 230);
        this.Controls.Add(this.CloseButton);
        this.Controls.Add(this.CopyMeetingIdButton);
        this.Controls.Add(this.MeetingIdLabel);
        this.Controls.Add(this.MeetingIdHeaderLabel);
        this.Controls.Add(this.VersionLabel);
        this.Controls.Add(this.ProductLabel);
        this.Controls.Add(this.pictureBox1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AboutDialog";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "About POFF Meet";
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label ProductLabel;
    private System.Windows.Forms.Label VersionLabel;
    private System.Windows.Forms.Label MeetingIdHeaderLabel;
    private System.Windows.Forms.Label MeetingIdLabel;
    private System.Windows.Forms.Button CopyMeetingIdButton;
    private System.Windows.Forms.ToolTip AboutDialogToolTip;
    private System.Windows.Forms.Button CloseButton;
}