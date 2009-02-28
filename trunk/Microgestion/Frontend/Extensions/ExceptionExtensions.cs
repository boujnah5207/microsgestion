using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blackspot.Microgestion.Frontend.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ShowMessageBox(this Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }
    }
}
