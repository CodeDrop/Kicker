using POFF.Kicker.View;
using System;
using System.Windows.Forms;

namespace POFF.Kicker;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AppWindow());
    }
}
