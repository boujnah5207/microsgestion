using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Frontend.Extensions;

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

        internal override void InitializeForm()
        {
            LogUser();
            //UserService.LoggedInUser = UserService.GetAdminUser();

            ShowUserInfo();

            BuildMenu();

            base.InitializeForm();
        }

        private void BuildMenu()
        {
            IEnumerable<MenuOption> roots = MenuService.GetRoots();
            User user = UserService.LoggedInUser;

            var items = roots.CreateMenuItems();
            items.RemoveEmptyItems();

            this.Form.MainMenuStrip.Items.AddRange(items.ToArray());
        }

        private void ShowUserInfo()
        {
            string info = UserService.LoggedInUser.GetUserInfo();
            Form.UserInfo = info;
        }
    }
}
