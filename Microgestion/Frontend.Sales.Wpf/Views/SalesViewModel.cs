using System;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Backend.Enumerations;
using SysQ.Microgestion.Frontend.Common.Controls;
using SysQ.Microgestion.Frontend.Common.Extensions;
using System.Timers;

namespace SysQ.Microgestion.Frontend.Sales.Wpf.Views
{
    public class SalesViewModel : INotifyPropertyChanged
    {
        public SalesViewModel(SalesView view)
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

            this.internalTimer = new Timer(1000);
            this.internalTimer.Elapsed += (s, e) => { this.Date = DateTime.Now; };
            this.internalTimer.Start();

            this.Username = UserService.LoggedInUser.ToString();
            this.LoginText = IniciarSesion;

            this.Items = new ObservableCollection<SaleItem>();
            this.Items.CollectionChanged += (s, e) =>
            {
                UpdateTotal();
            };

            ClearAll();

            CommandBinding cmdLogin = new CommandBinding(
                LoginCommand,
                (s, e) => Login());

            CommandBinding cmdInsert = new CommandBinding(
                InsertItemCommand,
                (s, e) => InsertItem(),
                (s, e) =>
                {
                    e.CanExecute =
                        UserService.CanPerform(SystemAction.Sales) &&
                        this.ItemID != Guid.Empty &&
                        this.Amount != 0;
                });
            CommandBinding cmdSave = new CommandBinding(
                SaveCommand,
                (s, e) => Save(),
                (s, e) =>
                {
                    e.CanExecute =
                        UserService.CanPerform(SystemAction.Sales) &&
                        this.Items.Count > 0;
                });

            Application.Current.MainWindow.CommandBindings.Add(cmdLogin);
            Application.Current.MainWindow.CommandBindings.Add(cmdInsert);
            Application.Current.MainWindow.CommandBindings.Add(cmdSave);

        }

        private Timer internalTimer;
        private SalesView view;
        private const string CerrarSesion = "Cerrar Sesión";
        private const string IniciarSesion = "Iniciar Sesión";
        private DateTime date;
        private int nextNumber = 0;
        private string loginText = string.Empty;
        private string username = string.Empty;
        private double total = 0D;
        private double amount = 0D;

        public static RoutedCommand LoginCommand = new RoutedCommand();
        public static RoutedCommand InsertItemCommand = new RoutedCommand();
        public static RoutedCommand SaveCommand = new RoutedCommand();

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public int NextNumber
        {
            get { return nextNumber; }
            set
            {
                nextNumber = value;
                OnPropertyChanged("NextNumber");
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
        public double Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
                OnPropertyChanged("Total");
            }
        }
        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public ObservableCollection<SaleItem> Items { get; set; }
        public string SearchItem { get; set; }
        public Guid ItemID { get; set; }

        internal IList<Item> SearchItems(string text, int maxResults)
        {
            try
            {
                return ItemService.SearchItems(text, maxResults);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
                return new List<Item>();
            }
        }

        internal void InsertItem()
        {
            try
            {
                if (ItemID != Guid.Empty && Amount != 0)
                {
                    Item item = ItemService.GetByID(ItemID);

                    Items.Add(new SaleItem
                    {
                        ItemID = item.ID,
                        Description = item.Name,
                        Amount = this.Amount,
                        Measurement = item.BaseMeasurement.Abbreviation,
                        UnitPrice = item.CurrentPrice.Value,
                        PriceID = item.CurrentPrice.ID,
                        Subtotal = (item.CurrentPrice.Value * this.Amount)
                    });

                    ItemID = Guid.Empty;
                    Amount = 1;
                    view.txtSearchItem.Text = string.Empty;
                    view.txtSearchItem.Focus();
                }
                else
                {
                    view.txtSearchItem.SelectAll();
                    view.txtSearchItem.Focus();
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void UpdateTotal()
        {
            try
            {
                this.Total = Items.Sum(i => i.Subtotal);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        internal void Cancel()
        {
            try
            {
                if (this.Items.Count > 0)
                {
                    var dr = MessageBox.Show(
                        "¿Está seguro que desea cancelar el movimiento?",
                        "Cancelar Movimiento",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question,
                        MessageBoxResult.No);
                    if (dr == MessageBoxResult.No)
                        return;
                }

                ClearAll();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void ClearAll()
        {
            try
            {
                this.Items.Clear();
                this.ItemID = Guid.Empty;
                this.NextNumber = GetNextNumber();
                this.Amount = 1;
                view.txtSearchItem.Text = string.Empty;
                view.txtSearchItem.Focus();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private int GetNextNumber()
        {
            try
            {
                return SaleService.GetNextNumber();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
                return 0;
            }
        }

        internal void Save()
        {
            try
            {
                if (this.Items.Count > 0)
                {
                    var dr = MessageBox.Show(
                        "¿Confirma que desea guardar el movimiento?",
                        "Confirmar Movimiento",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question,
                        MessageBoxResult.No);
                    if (dr == MessageBoxResult.No)
                        return;

                    List<SaleDetail> saleDetail = new List<SaleDetail>();
                    List<StockMovementDetail> stockDetail = new List<StockMovementDetail>();

                    Sale sale = new Sale
                    {
                        Total = this.Total,
                        Date = DateTime.Now,
                        UserID = UserService.LoggedInUser.ID,
                        InternalID = this.NextNumber
                    };

                    foreach (var i in Items)
                    {
                        SaleDetail detail = new SaleDetail
                          {
                              ID = Guid.NewGuid(),
                              ItemID = i.ItemID,
                              Amount = i.Amount,
                              Subtotal = i.Subtotal,
                              PriceID = i.PriceID
                          };
                        saleDetail.Add(detail);
                    }

                    sale.Details.AddRange(saleDetail);

                    SaleService.Save(sale);

                    foreach (var i in sale.Details)
                    {
                        if (i.Item.MovesStock)
                        {
                            stockDetail.Add(new StockMovementDetail
                            {
                                ItemID = i.ItemID,
                                Amount = i.Amount * -1,
                                SaleDetailID = i.ID
                            });
                        }
                    }

                    if (stockDetail.Count > 0)
                    {
                        StockMovement stockMovement = new StockMovement
                        {
                            Date = DateTime.Now,
                            Comment = String.Format("Generated from Sale #{0}", sale.InternalID),
                            UserID = UserService.LoggedInUser.ID
                        };

                        stockMovement.Details.AddRange(stockDetail);

                        StockMovementService.Save(stockMovement);
                    }

                }

                ClearAll();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
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

        internal void RemoveLastItem()
        {
            SaleItem item = this.Items.LastOrDefault();
            
            if (item == null)
                return;

            var result = MessageBox.Show(
                String.Format("¿Eliminar {0} x {1}?", item.Description, item.Amount),
                "Eliminar Artículo",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            if (result == MessageBoxResult.No)
                return;

            Items.Remove(item);
        }

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

    }

    public class SaleItem
    {
        public Guid ItemID { get; set; }
        public String Description { get; set; }
        public Double Amount { get; set; }
        public String Measurement { get; set; }
        public Double UnitPrice { get; set; }
        public Guid PriceID { get; set; }
        public Double Subtotal { get; set; }
    }
}
