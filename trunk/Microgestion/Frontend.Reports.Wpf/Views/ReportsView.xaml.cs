using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.DataGrid;

namespace Frontend.Reports.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : Window
    {
        private ReportsViewModel vm;

        public ReportsView()
        {
            InitializeComponent();

            vm = new ReportsViewModel(this);
            DataContext = vm;

            this.SalesGrid.View.FixedFooters.Add((DataTemplate)this.FindResource("tableViewFixedFooter1"));
            this.SalesGrid.DefaultGroupConfiguration = (GroupConfiguration)this.FindResource("tableViewGroupConfiguration1");

            this.StockMovementsGrid.View.FixedFooters.Add((DataTemplate)this.FindResource("tableViewFixedFooter2"));
            this.StockMovementsGrid.DefaultGroupConfiguration = (GroupConfiguration)this.FindResource("tableViewGroupConfiguration2");

            vm.Login();
        }
    }
}
