using System.Windows.Forms;

namespace POFF.Meet.View;

public partial class AboutDialog : Form
{
    public AboutDialog()
    {
        InitializeComponent();

        VersionLabel.Text = Application.ProductVersion;
    }

    public string MeetingId 
    { 
        set { MeetingIdLabel.Text = value; }
    }

    private void CopyMeetingIdButton_Click(object sender, System.EventArgs e)
    {
        Clipboard.SetText(MeetingIdLabel.Text);
        AboutDialogToolTip.Show("Meeting ID copied to clipboard", MeetingIdLabel, 1000);
    }

    private void CloseButton_Click(object sender, System.EventArgs e)
    {
        Close();
    }
}
