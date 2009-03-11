using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Blackspot.Microgestion.Frontend.Stock.Wpf.Views;

namespace Blackspot.Microgestion.Frontend.Stock.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginView login = new LoginView();
            var result = login.ShowDialog();

            if (result.HasValue && result.Value == true)
            {
                StockMovementView View = new StockMovementView();
                View.Show();
            }
        }
    }
}
