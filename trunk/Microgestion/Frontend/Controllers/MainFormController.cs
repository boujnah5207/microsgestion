using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Services;
using Blackspot.Microgestion.Frontend.Extensions;
using Blackspot.Microgestion.Frontend.Forms;

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
            try
            {
                LogUser();
                //UserService.LoggedInUser = UserService.GetAdminUser();

                ShowUserInfo();

                BuildMenu();

                base.InitializeForm();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void BuildMenu()
        {
            try
            {
                IEnumerable<MenuOption> roots = MenuService.GetMenuOptions();
                User user = UserService.LoggedInUser;

                var items = roots.CreateMenuItems();
                items.RemoveEmptyItems();

                this.Form.MainMenuStrip.Items.AddRange(items.ToArray());
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void ShowUserInfo()
        {
            string info = UserService.LoggedInUser.GetUserInfo();
            Form.UserInfo = info;
        }
    }
}
