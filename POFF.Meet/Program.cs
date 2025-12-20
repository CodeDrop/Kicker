using POFF.Meet.View;
using System;
using System.Windows.Forms;

namespace POFF.Meet;

public class Program
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AppWindow());
    }
}
