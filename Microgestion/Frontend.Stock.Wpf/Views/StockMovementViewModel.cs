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

namespace SysQ.Microgestion.Frontend.Stock.Wpf.Views
{
    public class StockMovementViewModel : INotifyPropertyChanged
    {
        private Timer internalTimer;
        private StockMovementView view;
        private const string CerrarSesion = "Cerrar Sesión";
        private const string IniciarSesion = "Iniciar Sesión";

        public static RoutedCommand LoginCommand = new RoutedCommand();
        public static RoutedCommand InsertItemCommand = new RoutedCommand();
        public static RoutedCommand SaveCommand = new RoutedCommand();

        public StockMovementViewModel(StockMovementView view)
        {
            try
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

                this.Items = new ObservableCollection<StockMovementItem>();
                this.Username = UserService.LoggedInUser.ToString();
                this.LoginText = IniciarSesion;

                CommandBinding cmdLogin = new CommandBinding(
                    LoginCommand,
                    (s, e) => Login());

                CommandBinding cmdInsert = new CommandBinding(
                    InsertItemCommand,
                    (s, e) => InsertItem(),
                    (s, e) =>
                    {
                        e.CanExecute =
                            UserService.CanPerform(SystemAction.StockMovement) &&
                            this.ItemID != Guid.Empty &&
                            this.Amount != 0;
                    });
                CommandBinding cmdSave = new CommandBinding(
                    SaveCommand,
                    (s, e) => Save(),
                    (s, e) =>
                    {
                        e.CanExecute =
                            UserService.CanPerform(SystemAction.StockMovement) &&
                            this.Items.Count > 0;
                    });

                Application.Current.MainWindow.CommandBindings.Add(cmdLogin);
                Application.Current.MainWindow.CommandBindings.Add(cmdInsert);
                Application.Current.MainWindow.CommandBindings.Add(cmdSave);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private string loginText = string.Empty;
        private string username = string.Empty;
        private DateTime date;
        private double amount = 0D;

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
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Comments { get; set; }
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

        public ObservableCollection<StockMovementItem> Items { get; set; }
        public string SearchItem { get; set; }
        public Guid ItemID { get; set; }
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
                    StockMovementItem alreadyInsertedItem =
                        Items.Where(i => i.ItemID.Equals(ItemID))
                             .SingleOrDefault();

                    if (alreadyInsertedItem == null)
                    {
                        Item item = ItemService.GetByID(ItemID);

                        Items.Add(new StockMovementItem
                        {
                            ItemID = item.ID,
                            Description = item.Name,
                            Amount = this.Amount
                        });
                    }
                    else
                    {
                        alreadyInsertedItem.Amount += this.Amount;
                        Items.Remove(alreadyInsertedItem);
                        Items.Add(alreadyInsertedItem);
                    }

                    ItemID = Guid.Empty;
                    Amount = 0;
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
                this.Comments = string.Empty;
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

                    StockMovement mov = new StockMovement
                    {
                        Comment = this.Comments,
                        Date = this.Date,
                        UserID = UserService.LoggedInUser.ID
                    };

                    var details = from i in Items
                                  select new StockMovementDetail
                                      {
                                          ItemID = i.ItemID,
                                          Amount = i.Amount
                                      };
                    mov.Details.AddRange(details);

                    StockMovementService.Save(mov);

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

    public class StockMovementItem
    {
        public Guid ItemID { get; set; }
        public String Description { get; set; }
        public Double Amount { get; set; }
    }
}
