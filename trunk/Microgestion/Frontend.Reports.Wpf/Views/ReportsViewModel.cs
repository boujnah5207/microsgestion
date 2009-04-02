using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Backend.Entities;

namespace Frontend.Reports.Wpf.Views
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private ReportsView view;

        public ReportsViewModel(ReportsView view)
        {
            this.view = view;

            this.view.Closing += (s, e) =>
            {
                var result = MessageBox.Show(
                    "¿Confirma que desea salir?",
                    "Salir",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    MessageBoxResult.No);

                e.Cancel = (result == MessageBoxResult.No);
            };

            CommandBinding cmdSearchSales = new CommandBinding(
                SearchCommand,
                (s, e) => SearchSales(),
                (s, e) =>
                {
                    e.CanExecute =
                        UserService.CanPerform(SystemAction.SalesReport) &&
                        FilterDateFinish >= FilterDateStart;
                });

            Application.Current.MainWindow.CommandBindings.Add(cmdSearchSales);

            this.FilterDateStart = DateTime.Now;
            this.FilterDateFinish = DateTime.Now;

            UserService.LoggedInUser = UserService.GetAdminUser();
        }

        public ObservableCollection<SaleRecord> SaleRecords { get; set; }

        public DateTime FilterDateStart { get; set; }
        public DateTime FilterDateFinish { get; set; }

        public static RoutedCommand SearchCommand = new RoutedCommand();

        #region INotifyPropertyChanged Members

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void SearchSales()
        {
            IEnumerable<SaleDetail> saleDetails = SaleService.SearchSales(FilterDateStart, FilterDateFinish);

            var records = saleDetails
                .Select(d => new SaleRecord
                {
                    InternalNumber = d.Sale.InternalID,
                    Date = d.Sale.Date,
                    Item = d.Item.Name,
                    Amount = d.Amount,
                    Measurement = d.Item.BaseMeasurement.Abbreviation,
                    Price = d.Price.Value,
                    Subtotal = d.Subtotal,
                    User = d.Sale.User.ToString()
                });
                
            SaleRecords = new ObservableCollection<SaleRecord>(records.ToList());
        }


    }

    public class SaleRecord
    {
        public int InternalNumber { get; set; }
        public DateTime Date { get; set; }
        public int DateDay { get { return Date.Day; } }
        public int DateMonth { get { return Date.Month; } }
        public int DateYear { get { return Date.Year; } }
        public string User { get; set; }
        public string Item { get; set; }
        public string Measurement { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
    }
}
