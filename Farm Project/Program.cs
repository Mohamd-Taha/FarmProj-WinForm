using Farm_Project.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farm_Project
{
    static class Program
    {
        public static bool OpenHome_ScreenOnClose { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenHome_ScreenOnClose = false;
            var lg = new login();
           lg.Show();
          Application.Run();

            /*
            if (OpenHome_ScreenOnClose)
            {
                Application.Run(new Money_Transactions());
            }
            */
        }
    }
}
