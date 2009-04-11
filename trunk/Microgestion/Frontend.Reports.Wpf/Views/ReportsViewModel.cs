using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Enumerations;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Frontend.Common.Controls;
using SysQ.Microgestion.Frontend.Common.Extensions;
using Xceed.Wpf.DataGrid;
using System.Windows.Controls;

namespace Frontend.Reports.Wpf.Views
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private ReportsView view;
        private string loginText = string.Empty;
        private string username = string.Empty;
        private const string CerrarSesion = "Cerrar Sesión";
        private const string IniciarSesion = "Iniciar Sesión";
        public DateTime filterDateStart;
        public DateTime filterDateFinish;
        public DateTime filterSMDateStart;
        public DateTime filterSMDateFinish;

        public ReportsViewModel(ReportsView view)
        {
            this.SaleRecords = new ObservableCollection<SaleRecord>();
            this.StockMovementRecords = new ObservableCollection<StockMovementRecord>();

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

            this.Username = UserService.LoggedInUser.ToString();
            this.LoginText = IniciarSesion;

            CommandBinding cmdSearch = new CommandBinding(
                SearchCommand,
                (s, e) =>
                {
                    TabItem tab = view.tabs.SelectedItem as TabItem;
                    if (tab.Equals(view.tabSales))
                        SearchSales();
                    else if (tab.Equals(view.tabStock))
                        SearchStockMovements();
                },
                (s, e) =>
                {
                    e.CanExecute =
                        UserService.CanPerform(SystemAction.Reports) &&
                        FilterDateFinish >= FilterDateStart;
                });

            CommandBinding cmdLogin = new CommandBinding(
                LoginCommand,
                (s, e) => Login());

            CommandBinding cmdPrint = new CommandBinding(
                PrintCommand,
                (s, e) => 
                {
                    TabItem tab = view.tabs.SelectedItem as TabItem;
                    if (tab.Equals(view.tabSales))
                        Print(view.SalesGrid);
                    else if (tab.Equals(view.tabStock))
                        Print(view.StockMovementsGrid);
                },
                (s, e) =>
                {
                    e.CanExecute = UserService.CanPerform(SystemAction.Reports);
                });
                
            Application.Current.MainWindow.CommandBindings.Add(cmdSearch);
            Application.Current.MainWindow.CommandBindings.Add(cmdLogin);
            Application.Current.MainWindow.CommandBindings.Add(cmdPrint);

            this.FilterDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);
            this.FilterDateFinish = DateTime.Now;

            UserService.LoggedInUser = UserService.GetAdminUser();
        }

        public ObservableCollection<SaleRecord> SaleRecords { get; set; }
        public ObservableCollection<StockMovementRecord> StockMovementRecords { get; set; }

        public DateTime FilterDateStart
        {
            get
            {
                var d = view.filterDateStart.SelectedDate;
                if (d.HasValue)
                    filterDateStart = d.Value;
                return filterDateStart;
            }
            set
            {
                var d = value;
                filterDateStart = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                OnPropertyChanged("FilterDateStart");
            }
        }
        public DateTime FilterDateFinish
        {
            get
            {
                var d = view.filterDateFinish.SelectedDate;
                if (d.HasValue)
                    filterDateFinish = d.Value;
                return filterDateFinish;
            }
            set
            {
                var d = value;
                filterDateFinish = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);

                OnPropertyChanged("FilterDateFinish");
            }
        }
        public DateTime FilterSMDateStart
        {
            get
            {
                var d = view.filterSMDateStart.SelectedDate;
                if (d.HasValue)
                    filterSMDateStart = d.Value;
                return filterSMDateStart;
            }
            set
            {
                var d = value;
                filterSMDateStart = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                OnPropertyChanged("FilterSMDateStart");
            }
        }
        public DateTime FilterSMDateFinish
        {
            get
            {
                var d = view.filterSMDateFinish.SelectedDate;
                if (d.HasValue)
                    filterSMDateFinish = d.Value;
                return filterSMDateFinish;
            }
            set
            {
                var d = value;
                filterSMDateFinish = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);

                OnPropertyChanged("FilterSMDateFinish");
            }
        }
        public string LoginText
        {
            get
            {
                return loginText;
            }
            set
            {
                loginText = value;
                OnPropertyChanged("LoginText");
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public static RoutedCommand LoginCommand = new RoutedCommand();
        public static RoutedCommand SearchCommand = new RoutedCommand();
        public static RoutedCommand PrintCommand = new RoutedCommand();

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
            SaleRecords.Clear();

            IEnumerable<SaleDetail> saleDetails = SaleService.SearchSales(FilterDateStart, FilterDateFinish);

            var records = saleDetails
                .Select(d => new SaleRecord
                {
                    InternalId = d.Sale.InternalID,
                    Date = d.Sale.Date,
                    Item = d.Item.Name,
                    ItemType = d.Item.ItemType.Name,
                    Amount = d.Amount,
                    Measurement = d.Item.BaseMeasurement.Abbreviation,
                    Price = d.Price.Value,
                    Subtotal = d.Subtotal,
                    User = d.Sale.User.ToString()
                });

            foreach (var r in records)
                SaleRecords.Add(r);
        }

        private void SearchStockMovements()
        {
            StockMovementRecords.Clear();

            IEnumerable<StockMovementDetail> stockMovementDetails = StockMovementService.SearchMovements(FilterSMDateStart, FilterSMDateFinish);

            var records = stockMovementDetails
                .Select(d => new StockMovementRecord
                {
                    InternalId = d.SaleDetail != null ? d.SaleDetail.Sale.InternalID : 0,
                    Date = d.StockMovement.Date,
                    Item = d.Item.Name,
                    ItemType = d.Item.ItemType.Name,
                    Amount = d.Amount,
                    Measurement = d.Item.BaseMeasurement.Abbreviation,
                    User = d.StockMovement.User.ToString()
                });

            foreach (var r in records)
                StockMovementRecords.Add(r);
        }

        internal void Login()
        {
            try
            {
                if (LoginText == IniciarSesion)
                {
                    LoginView login = new LoginView();
                    if (login.ShowDialog() == true)
                    {
                        this.Username = UserService.LoggedInUser.ToString();
                        this.LoginText = CerrarSesion;
                    }
                }
                else
                {
                    UserService.LoggedInUser = UserService.GetNullUser();
                    this.Username = UserService.LoggedInUser.ToString();
                    this.LoginText = IniciarSesion;
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Print(DataGridControl grid)
        {
            grid.Print("Reporte de Ventas", true, true);
        }

    }

    public class SaleRecord
    {
        public int InternalId { get; set; }
        public DateTime Date { get; set; }
        public int DateDay { get { return Date.Day; } }
        public int DateMonth { get { return Date.Month; } }
        public int DateYear { get { return Date.Year; } }
        public string User { get; set; }
        public string Item { get; set; }
        public string ItemType { get; set; }
        public string Measurement { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
    }
    public class StockMovementRecord
    {
        public int InternalId { get; set; }
        public DateTime Date { get; set; }
        public int DateDay { get { return Date.Day; } }
        public int DateMonth { get { return Date.Month; } }
        public int DateYear { get { return Date.Year; } }
        public string User { get; set; }
        public string Item { get; set; }
        public string Measurement { get; set; }
        public double Amount { get; set; }
        public string ItemType { get; set; }
    }
}
