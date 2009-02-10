using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class MainFormController: ControllerBase<MainForm>
    {

        public MainFormController(MainForm form)
            : base(form) { }

        internal void LogUser()
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        internal void InitializeForm()
        {
            LogUser();
            ShowUserInfo();
        }

        private void ShowUserInfo()
        {
            string info = UserService.LoggedInUser.GetUserInfo();
            Form.UserInfo = info;
        }
    }
}
