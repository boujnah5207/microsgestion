using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using SysQ.Microgestion.Frontend.Stock.Wpf.Views;

namespace SysQ.Microgestion.Frontend.Stock.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGF31-X8X57-07B1P-C85A";
            base.OnStartup(e);
        }
    }
}
