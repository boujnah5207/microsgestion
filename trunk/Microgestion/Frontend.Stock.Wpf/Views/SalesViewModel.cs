using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Frontend.Sales.Wpf.Extensions;
using Blackspot.Microgestion.Backend.Enumerations;
using System.Collections.ObjectModel;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Frontend.Sales.Wpf.Views
{
    public class SalesViewModel
    {
        private SalesView view;
        private const string CerrarSesion = "Cerrar Sesión";
        private const string IniciarSesion = "Iniciar Sesión";

        public static RoutedCommand LoginCommand = new RoutedCommand();
        public static RoutedCommand InsertItemCommand = new RoutedCommand();
        public static RoutedCommand SaveCommand = new RoutedCommand();

        public SalesViewModel(SalesView view)
        {
            this.view = view;

            this.Username = UserService.LoggedInUser.GetUserInfo();
            this.LoginText = IniciarSesion;

            this.Items = new ObservableCollection<SaleItem>();

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

        public int NextNumber { get; set; }
        public DateTime Date { get; set; }

        private string loginText = string.Empty;
        public string LoginText
        {
            get
            {
                return loginText;
            }
            set
            {
                loginText = value;
                view.txtLoginText.Text = value;
            }
        }
        private string username = string.Empty;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                view.txtUsername.Text = value;
            }
        }

        public ObservableCollection<SaleItem> Items { get; set; }
        public string SearchItem { get; set; }
        public Guid ItemID { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }

        internal IList<Item> SearchItems(string text, int maxResults)
        {
            return ItemService.SearchItems(text, maxResults);
        }

        internal void InsertItem()
        {
            try
            {
                if (!UserService.CanPerform(SystemAction.StockMovement))
                    return;

                if (ItemID != Guid.Empty && Amount != 0)
                {
                    //SaleItem alreadyInsertedItem =
                    //    Items.Where(i => i.ItemID.Equals(ItemID))
                    //         .SingleOrDefault();

                    //if (alreadyInsertedItem == null)
                    //{
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
                    //}
                    //else
                    //{
                    //    alreadyInsertedItem.Amount += this.Amount;
                    //    Items.Remove(alreadyInsertedItem);
                    //    Items.Add(alreadyInsertedItem);
                    //}

                    Total = CalculateTotal();
                    ItemID = Guid.Empty;
                    Amount = 0;
                    view.txtAmount.Text = string.Empty;
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

        private double CalculateTotal()
        {
            return Items.Sum(i => i.Subtotal);
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
                this.Date = DateTime.Now;
                this.NextNumber = GetNextNumber();
                this.Amount = 0;
                view.txtAmount.Text = string.Empty;
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
            return SaleService.GetNextNumber();
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

                    Sale sale = new Sale
                    {
                        Total = this.Total,
                        Date = this.Date,
                        UserID = UserService.LoggedInUser.ID
                    };

                    var details = from i in Items
                                  select new SaleDetail
                                  {
                                      ItemID = i.ItemID,
                                      Amount = i.Amount,
                                      Subtotal = i.Subtotal,
                                      PriceID = i.PriceID
                                  };

                    sale.Details.AddRange(details);

                    SaleService.Save(sale);

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
                        this.Username = UserService.LoggedInUser.GetUserInfo();
                        this.LoginText = CerrarSesion;
                    }
                }
                else
                {
                    UserService.LoggedInUser = UserService.GetNullUser();
                    this.Username = UserService.LoggedInUser.GetUserInfo();
                    this.LoginText = IniciarSesion;
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

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
