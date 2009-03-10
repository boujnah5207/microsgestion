using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Entities;
using System.Windows;
using Blackspot.Microgestion.Backend.Enumerations;

namespace Blackspot.Microgestion.Frontend.Stock.Wpf.Views
{
    public class StockMovementViewModel
    {
        private StockMovementView view;

        public StockMovementViewModel(StockMovementView view)
        {
            this.view = view;
            this.Date = DateTime.Now;
            this.Items = new ObservableCollection<StockMovementItem>();

            //UserService.LoggedInUser = UserService.GetAdminUser();

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
                InsertItemCommand,
                (s, e) => Save(),
                (s, e) =>
                {
                    e.CanExecute =
                        UserService.CanPerform(SystemAction.StockMovement) &&
                        this.Items.Count > 0;
                });

            Application.Current.MainWindow.CommandBindings.Add(cmdInsert); 
            Application.Current.MainWindow.CommandBindings.Add(cmdSave);

        }

        public DateTime Date { get; set; }
        public String Comments { get; set; }
        public ObservableCollection<StockMovementItem> Items { get; set; }
        public String SearchItem { get; set; }
        public Guid ItemID { get; set; }
        public Double Amount { get; set; }

        public static RoutedCommand InsertItemCommand = new RoutedCommand();
        public static RoutedCommand SaveCommand = new RoutedCommand();

        internal IList<Item> SearchItems(string text, int maxResults)
        {
            return ItemService.SearchItems(text, maxResults);
        }

        internal void InsertItem()
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

        internal void Cancel()
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

        private void ClearAll()
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

        internal void Save()
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
    }

    public class StockMovementItem
    {
        public Guid ItemID { get; set; }
        public String Description { get; set; }
        public Double Amount { get; set; }
    }
}
