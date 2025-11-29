using System;
using System.Windows.Forms;

namespace POFF.Kicker.View
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new AppWindow());
        }
    }
}
