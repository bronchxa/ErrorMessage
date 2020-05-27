using System;
using System.Windows.Forms;

namespace ErrorMessage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args != null && args.Length == 2)
                Application.Run(new ErrorMsgFrm(args[0], args[1]));
            else
                Application.Run(new ErrorMsgFrm());
        }
    }
}
