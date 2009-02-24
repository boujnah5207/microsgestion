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

            base.InitializeForm();
        }

        internal bool ValidateLogIn()
        {
            string user = Form.Username;
            string pass = Form.Password;

            if (String.IsNullOrEmpty(user))
            {
                Form.SetStatusMessage("Ingrese su nombre de usuario.", true);

                Form.FocusUsername();
                return false;
            }
            else if (String.IsNullOrEmpty(pass))
            {
                Form.SetStatusMessage("Ingrese su contraseña.", true);
                Form.FocusPassword(); 
                return false;
            }

            try
            {
                return UserService.ValidateUser(user, pass);
            }
            catch (InvalidPasswordException ex)
            {
                Form.SetStatusMessage(ex.Message, true);
                Form.FocusPassword();
                return false;
            }
            catch (UserNotFoundException ex)
            {
                Form.SetStatusMessage(ex.Message, true);
                Form.FocusUsername();
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

                Form.SetStatusMessage("Contraseña invalida. Ingresar su nueva contraseña.", true);
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
            Form.SetStatusMessage("Ingrese su contraseña");
            return true;
        }
    }
}
