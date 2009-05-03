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
            this.ItemRecords = new ObservableCollection<ItemRecord>();

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

            BindCommands();

            UserService.LoggedInUser = UserService.GetAdminUser();

            FillFilters();

        }

        public ObservableCollection<SaleRecord> SaleRecords { get; set; }
        public ObservableCollection<StockMovementRecord> StockMovementRecords { get; set; }
        public ObservableCollection<ItemRecord> ItemRecords { get; set; }
        public ObservableCollection<KeyValuePair<Guid,String>> ItemsFilter { get; set; }
        public ObservableCollection<KeyValuePair<Guid, String>> ItemTypesFilter { get; set; }

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
                filterDateStart = value;
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
                filterDateFinish = value;

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
                filterSMDateStart = value;
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
                filterSMDateFinish = value;
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

        private void BindCommands()
        {
            CommandBinding cmdSearch = new CommandBinding(
                SearchCommand,
                (s, e) =>
                {
                    TabItem tab = view.tabs.SelectedItem as TabItem;
                    if (tab.Equals(view.tabSales))
                        SearchSales();
                    else if (tab.Equals(view.tabStock))
                        SearchStockMovements();
                    else if (tab.Equals(view.tabItems))
                        SearchItems();
                },
                (s, e) =>
                {
                    e.CanExecute = UserService.CanPerform(SystemAction.Reports);
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
                    else if (tab.Equals(view.tabItems))
                        Print(view.ItemsGrid);
                },
                (s, e) =>
                {
                    e.CanExecute = UserService.CanPerform(SystemAction.Reports);
                });

            Application.Current.MainWindow.CommandBindings.Add(cmdSearch);
            Application.Current.MainWindow.CommandBindings.Add(cmdLogin);
            Application.Current.MainWindow.CommandBindings.Add(cmdPrint);
        }

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
                    Comment = d.StockMovement.Comment,
                    Item = d.Item.Name,
                    ItemType = d.Item.ItemType.Name,
                    Amount = d.Amount,
                    Measurement = d.Item.BaseMeasurement.Abbreviation,
                    User = d.StockMovement.User.ToString()
                });

            foreach (var r in records)
                StockMovementRecords.Add(r);
        }

        private void SearchItems()
        {
            ItemRecords.Clear();
            Guid itemType = Guid.Empty;
            Guid item = Guid.Empty;
            bool onlyMissingStock = view.OnlyMissingStock.IsChecked.HasValue ? view.OnlyMissingStock.IsChecked.Value : false;

            if (view.ItemTypesFilter.SelectedValue != null)
                itemType = ((KeyValuePair<Guid, string>)view.ItemTypesFilter.SelectedValue).Key;
            if (view.ItemsFilter.SelectedValue != null)
                item = ((KeyValuePair<Guid, string>)view.ItemsFilter.SelectedValue).Key;

            IList<ItemRecord> records = ItemService.SearchItemRecords(itemType, item, onlyMissingStock);

            foreach (var r in records)
                ItemRecords.Add(r);
        }

        private void FillFilters()
        {
            // ItemTypes Filter
            this.ItemTypesFilter = new ObservableCollection<KeyValuePair<Guid, String>>();
            ItemTypesFilter.Add(new KeyValuePair<Guid, string>(Guid.Empty, String.Empty));
            foreach (var i in ItemTypeService.GetAll(i => i.Name))
                ItemTypesFilter.Add(new KeyValuePair<Guid, string>(i.ID, i.Name));

            // Items Filter
            this.ItemsFilter = new ObservableCollection<KeyValuePair<Guid, String>>();
            ItemsFilter.Add(new KeyValuePair<Guid, string>(Guid.Empty, String.Empty));
            foreach (var i in ItemService.GetAll(i => i.Name))
                ItemsFilter.Add(new KeyValuePair<Guid, string>(i.ID, i.Name));
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
        public string Comment { get; set; }
        public string User { get; set; }
        public string Item { get; set; }
        public string Measurement { get; set; }
        public double Amount { get; set; }
        public string ItemType { get; set; }
    }
}
