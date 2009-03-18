using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Blackspot.Microgestion.Backend.Services;
using System.Windows;
using Blackspot.Microgestion.Backend.Exceptions;
using Blackspot.Microgestion.Backend.Extensions;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Frontend.Sales.Wpf.Extensions;

namespace Blackspot.Microgestion.Frontend.Stock.Wpf.Views
{
    public class LoginViewModel
    {
        private LoginView view;

        public static RoutedCommand AcceptCommand = new RoutedCommand();
        public static RoutedCommand CancelCommand = new RoutedCommand();

        public LoginViewModel(LoginView view)
        {
            try
            {
                this.view = view;
                this.ConfirmPasswordVisible = Visibility.Collapsed;

                CommandBinding cmdAccept = new CommandBinding(
                    AcceptCommand,
                    (s, e) => Accept(),
                    (s, e) =>
                    {
                        e.CanExecute =
                            !String.IsNullOrEmpty(Username) &&
                            !String.IsNullOrEmpty(Password);
                    });
                CommandBinding cmdCancel = new CommandBinding(
                    CancelCommand,
                    (s, e) => Cancel(),
                    (s, e) =>
                    {
                        e.CanExecute = true;
                    });

                view.CommandBindings.Add(cmdAccept);
                view.CommandBindings.Add(cmdCancel);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void Cancel()
        {
            view.DialogResult = false;
            view.Close();
        }

        private void Accept()
        {
            try
            {
                if (ConfirmPasswordVisible == Visibility.Collapsed)
                {
                    if (UserService.ValidateUser(Username, Password))
                    {
                        view.DialogResult = true;
                        view.Close();
                    }
                }
                else
                {
                    if (Password.Equals(ConfirmedPassword))
                    {
                        User u = UserService.GetUserByUsername(Username);
                        u.Password = Password;
                        UserService.Update(u);

                        UserService.ValidateUser(Username, Password);
                        view.DialogResult = true;
                        view.Close();
                    }
                    Message = "Contraseña invalida. Ingresar su nueva contraseña.";
                    view.FocusPassword();
                }
            }
            catch (InvalidPasswordException ex)
            {
                this.ConfirmPasswordVisible = Visibility.Collapsed;
                view.FocusPassword();
                Message = ex.Message;
                return;
            }
            catch (UserNotFoundException ex)
            {
                this.ConfirmPasswordVisible = Visibility.Collapsed;
                view.FocusUsername();
                Message = ex.Message;
                return;
            }
            catch (MustConfirmPasswordException)
            {
                this.ConfirmPasswordVisible = Visibility.Visible;
                view.FocusConfirmPassword();
                return;
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private string message = string.Empty;
        private string password = string.Empty;
        private string confirmedPassword = string.Empty;
        private Visibility confirmPasswordVisible = Visibility.Collapsed;

        public string Username { get; set; }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value.GetMD5Hash();
            }
        }
        public string ConfirmedPassword
        {
            get
            {
                return confirmedPassword;
            }
            set
            {
                this.confirmedPassword = value.GetMD5Hash();
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                if (!String.IsNullOrEmpty(message))
                {
                    view.lblMessage.Text = message;
                    view.lblMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    view.lblMessage.Text = message;
                    view.lblMessage.Visibility = Visibility.Collapsed;
                }
            }
        }
        public Visibility ConfirmPasswordVisible
        {
            get { return confirmPasswordVisible; }
            set
            {
                confirmPasswordVisible = value;
                view.txtConfirmPassword.Visibility = value;
                view.lblConfirmPassword.Visibility = value;
            }
        }

    }
}
