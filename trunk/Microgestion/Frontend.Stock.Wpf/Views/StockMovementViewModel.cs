using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Entities;
using System.Windows;

namespace Blackspot.Microgestion.Frontend.Stock.Wpf.Views
{
    public class StockMovementViewModel
    {
        private StockMovementView view;

        public StockMovementViewModel(StockMovementView view)
        {
            this.view = view;
            this.Date = DateTime.Now;

            //CommandBinding cmd = new CommandBinding(
            //    InsertItemCommand,
            //    (s, e) => { },
            //    (s, e) =>
            //    {
            //        e.CanExecute = this.ItemID != Guid.Empty &&
            //                       this.Amount != 0;
            //    });

        }

        public DateTime Date { get; set; }
        public String Comments { get; set; }
        public ObservableCollection<StockMovementItem> Items { get; set; }
        public String SearchItem { get; set; }
        public Guid ItemID { get; set; }
        public Double Amount { get; set; }

        //public static RoutedCommand InsertItemCommand = new RoutedCommand();

        internal IList<Item> SearchItems(string text, int maxResults)
        {
            return ItemService.SearchItems(text, maxResults);
        }

        internal void InsertItem()
        {
            MessageBox.Show(
                String.Format("{0} x {1}", this.ItemID, this.Amount));
        }
    }

    public struct StockMovementItem
    {
        public Guid ItemID { get; set; }
        public String Description { get; set; }
        public Double Amount { get; set; }
    }
}
