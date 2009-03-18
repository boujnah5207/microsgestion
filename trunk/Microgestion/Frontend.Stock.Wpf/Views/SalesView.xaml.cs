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

namespace Blackspot.Microgestion.Frontend.Sales.Wpf.Views
{
    /// <summary>
    /// Interaction logic for SalesView.xaml
    /// </summary>
    public partial class SalesView : Window
    {
        private SalesViewModel vm;

        public SalesView()
        {
            InitializeComponent();

            vm = new SalesViewModel(this);
            DataContext = vm;

            vm.Login();

        }
    }
}
