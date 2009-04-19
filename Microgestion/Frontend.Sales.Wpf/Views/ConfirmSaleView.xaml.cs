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

namespace SysQ.Microgestion.Frontend.Sales.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ConfirmSaleView.xaml
    /// </summary>
    public partial class ConfirmSaleView : Window
    {
        public ConfirmSaleView()
        {
            InitializeComponent();

            this.BtnCancel.Click += (s, e) =>
            {
                this.DialogResult = false;
                this.Close();
            };
            this.BtnConfirm.Click += (s, e) =>
            {
                this.DialogResult = true;
                this.Close();
            };

            this.DataContext = this;

            this.Loaded += (s, e) =>
            {
                this.TxtTotal.Text = string.Format("{0:c}", Total);
                this.TxtChange.Text = string.Format("{0:c}", Change);

                this.TxtPayment.Focus();
                this.TxtPayment.SelectAll();
            };

            this.TxtPayment.TextChanged += (s, e) =>
            {
                double payment;
                if (Double.TryParse(TxtPayment.Text, out payment))
                {
                    this.Payment = payment;
                    this.TxtChange.Text = string.Format("{0:c}", Change);
                }
            };
        }

        public double Total { get; set; }
        private double Change
        {
            get
            {
                return (Payment - Total);
            }
        }

        public double Payment
        {
            get { return (double)GetValue(PaymentProperty); }
            set { SetValue(PaymentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Payment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentProperty =
            DependencyProperty.Register("Payment", typeof(double), typeof(ConfirmSaleView));


    }
}
