using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace proba
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }
    }
}



