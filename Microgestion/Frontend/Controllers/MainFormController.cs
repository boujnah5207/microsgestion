using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Frontend.Extensions;
using SysQ.Microgestion.Frontend.Forms;

namespace SysQ.Microgestion.Frontend.Controllers
{
    internal class MainFormController: ControllerBase<MainForm>
    {

        public MainFormController(MainForm form)
            : base(form) { }

        private void LogUser()
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        internal override void InitializeForm()
        {
            try
            {
                LogInOut();

                base.InitializeForm();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public void LogInOut()
        {
            if (UserService.LoggedInUser.ID == UserService.GetNullUser().ID)
                LogUser();
            else
            {
                UserService.LoggedInUser = UserService.GetNullUser();
                Form.CloseAllChilds();
            }

            ShowUserInfo();

            BuildMenu();
        }

        private void BuildMenu()
        {
            try
            {
                this.Form.MainMenuStrip.Items.Clear();

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
            string info = UserService.LoggedInUser.ToString();
            Form.UserInfo = info;
        }
    }
}
