﻿using System;
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
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Frontend.Common.Controls;
using SysQ.Microgestion.Frontend.Common.Extensions;

namespace SysQ.Microgestion.Frontend.Stock.Wpf.Views
{
    /// <summary>
    /// Interaction logic for StockMovementView.xaml
    /// </summary>
    public partial class StockMovementView : Window
    {
        private string lastValueAmount = String.Empty;
        private StockMovementViewModel vm;

        public StockMovementView()
        {
            try
            {
                InitializeComponent();

                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Stock_48.ico")); 

                vm = new StockMovementViewModel(this);
                DataContext = vm;

                vm.Login();

                this.txtSearchItem.Focus();

                this.txtSearchAutoComplete.SearchMethod = delegate(string searchterm, int maxResults)
                {
                    IList<Item> ret = vm.SearchItems(searchterm, maxResults);
                    return ret;
                };

                this.txtSearchAutoComplete.SelectionChanged += (s, e) =>
                {
                    TextBoxAutoCompleteProvider ac = (TextBoxAutoCompleteProvider)s;
                    if (ac.SelectedValue == null)
                    {
                        vm.ItemID = Guid.Empty;
                        return;
                    }
                    else if (ac.SelectedValue is Guid)
                    {
                        vm.ItemID = (Guid)ac.SelectedValue;
                    }
                };

                this.btnCancel.Click += (s, e) => vm.Cancel();

                this.txtAmount.GotFocus += (s, e) =>
                {
                    this.txtAmount.SelectAll();
                };

                this.txtAmount.PreviewKeyDown += (s, e) =>
                {
                    int keyValue = (int)e.Key;

                    e.Handled = !((keyValue >= 34 && keyValue <= 69) // 0-9-A-Z
                                  ||
                                  (keyValue >= 74 && keyValue <= 83) // 0-9
                                  ||
                                  (keyValue == 86 || keyValue == 88) // . ,
                                  ||
                                  (e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.Delete)
                                  );

                };

                this.txtAmount.KeyUp += (s, e) =>
                {
                    double value = 0D;
                    if (!String.IsNullOrEmpty(this.txtAmount.Text))
                    {
                        Double.TryParse(this.txtAmount.Text, out value);

                        if (value != 0D)
                        {
                            this.lastValueAmount = this.txtAmount.Text;
                            this.vm.Amount = Double.Parse(lastValueAmount);
                            vm.Amount = value;
                        }
                        else
                        {
                            this.txtAmount.Text = lastValueAmount;
                            this.vm.Amount = String.IsNullOrEmpty(lastValueAmount) ? 0D : Double.Parse(lastValueAmount);
                            e.Handled = true;
                        }

                        if (e.Key == Key.Enter)
                            vm.InsertItem();
                    }
                };
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }
    }
}
