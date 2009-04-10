using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Blackspot.Microgestion.Frontend.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ShowMessageBox(this Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK);
        }
    }
}
