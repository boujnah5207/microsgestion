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
using SysQ.Microgestion.Backend.Services;

namespace SysQ.Microgestion.Frontend.Sales.Wpf.Views
{
    /// <summary>
    /// Interaction logic for FindItemView.xaml
    /// </summary>
    public partial class FindItemView : Window
    {
        public FindItemView()
        {
            InitializeComponent();

            this.FindItemText.TextChanged += (s, e) =>
            {
                string text = ((TextBox)s).Text;
                if (!String.IsNullOrEmpty(text))
                {
                    var items = ItemService.SearchItemRecords(text);
                    this.FindItemGrid.ItemsSource = items;
                    return;
                }
                this.FindItemGrid.ItemsSource = null;
            };

            this.FindItemText.KeyUp += (s, e) =>
            {
                if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Down))
                {
                    this.FindItemGrid.Focus();
                    if (this.FindItemGrid.Items.Count > 0)
                    {
                        this.FindItemGrid.SelectedIndex = 0;
                    }
                }
            };

            this.FindItemGrid.KeyUp += (s, e) =>
            {
                if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Enter))
                {
                    if (this.FindItemGrid.SelectedItem != null)
                    {
                        this.SelectedItemId = ((ItemRecord)this.FindItemGrid.SelectedItem).ItemId;
                        this.DialogResult = true;
                    }
                    else
                    {
                        this.DialogResult = false;
                        this.Close();
                    }
                }
                else if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Escape))
                {
                    this.DialogResult = false;
                    this.Close();
                }
            };

            this.FindItemText.Focus();
        }

        public Guid SelectedItemId { get; set; }
    }
}
