using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Entities;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Exceptions;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class LoginFormController : ControllerBase<LoginForm>
    {
        public LoginFormController(LoginForm form)
            :base(form){}

        private bool userExists;

        public Boolean UserExists
        {
            get
            {
                return userExists;
            }
            set
            {
                this.userExists = value;
                OnPropertyChanged("UserExists");
            }
        }

        internal override void InitializeForm()
        {
            Form.Username = UserService.LoggedInUser.Name;
            Form.Password = UserService.LoggedInUser.Password;

            base.InitializeForm();
        }

        internal bool ValidateLogIn()
        {
            string user = Form.Username;
            string pass = Form.Password;

            if (String.IsNullOrEmpty(user))
            {
                Form.lblMessage.Text = "Ingrese su nombre de usuario.";

                Form.FocusUsername();
                return false;
            }
            else if (String.IsNullOrEmpty(pass))
            {
                Form.lblMessage.Text = "Ingrese su contraseña.";
                Form.FocusPassword(); 
                return false;
            }

            try
            {
                return UserService.ValidateUser(user, pass);
            }
            catch (InvalidPasswordException ex)
            {
                Form.lblMessage.Text = ex.Message;
                Form.FocusPassword();
                return false;
            }
            catch (MustConfirmPasswordException)
            {
                var confirm = new ConfirmPasswordForm();
                var dr = confirm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (pass.Equals(confirm.Password))
                    {
                        User u = UserService.GetUserByUsername(user);
                        u.Password = pass;
                        UserService.Update(u);

                        return UserService.ValidateUser(user, pass);
                    }
                }

                Form.lblMessage.Text = "Contraseña invalida. Ingresar su nueva contraseña.";
                Form.FocusPassword();

                return false;
            }
        }

        internal object CheckUser()
        {
            if (!UserService.CheckIfUserExists(Form.Username))
            {
                UserExists = false;
                return false;
            }
            UserExists = true;
            Form.lblMessage.Text = "Ingrese su contraseña";
            return true;
        }
    }
}
