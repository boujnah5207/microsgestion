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

namespace Blackspot.Microgestion.Frontend.Stock.Wpf.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginViewModel vm;

        public LoginView()
        {
            InitializeComponent();

            vm = new LoginViewModel(this);
            this.DataContext = vm;

            this.txtPassword.PasswordChanged += (s, e) =>
            {
                vm.Password = this.txtPassword.Password;
            };
            this.txtConfirmPassword.PasswordChanged += (s, e) =>
            {
                vm.ConfirmedPassword = this.txtConfirmPassword.Password;
            };

            FocusUsername();
        }


        internal void FocusUsername()
        {
            this.txtUsername.SelectAll();
            this.txtUsername.Focus();
        }

        internal void FocusPassword()
        {
            this.txtPassword.SelectAll();
            this.txtPassword.Focus();
        }

        internal void FocusConfirmPassword()
        {
            this.txtConfirmPassword.SelectAll();
            this.txtConfirmPassword.Focus();
        }
    }
}
