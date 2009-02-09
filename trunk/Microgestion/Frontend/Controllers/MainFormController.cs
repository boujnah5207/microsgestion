using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class MainFormController: ControllerBase<MainForm>
    {

        public MainFormController(MainForm form)
            : base(form) { }

        internal void LogUser()
        {
            try
            {
                LoginForm login = new LoginForm();

                DialogResult dr = login.ShowDialog();
                if (dr == DialogResult.OK)
                {
                }
                else
                {
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
