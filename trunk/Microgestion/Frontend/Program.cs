using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SysQ.Microgestion.Frontend.Forms;

namespace SysQ.Microgestion.Frontend
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Xceed.Editors.Licenser.LicenseKey = "EDN25-L4FC0-AGM08-LHXA";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}
