using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Backend.Entities;
using System.Windows.Forms;

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
                MessageBox.Show(
                    "Ingrese su nombre de usuario.",
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                Form.FocusUsername();
                return false;
            }
            else if (String.IsNullOrEmpty(pass))
            {
                MessageBox.Show(
                    "Ingrese su contraseña.",
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                Form.FocusPassword(); 
                return false;
            }
                
            return UserService.ValidateUser(user, pass);
        }

        internal object CheckUser()
        {
            if (!UserService.CheckIfUserExists(Form.Username))
            {
                //Form.FocusUsername();
                UserExists = false;
                return false;
            }
            UserExists = true;
            //Form.FocusPassword();
            return true;
        }
    }
}
