using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Enumerations;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Frontend
{
    internal class MenuDispatcher
    {
        private Form mainForm;

        private MenuDispatcher() { }

        internal MenuDispatcher(Form mainForm)
        {
            this.mainForm = mainForm;
        }

        internal static void Dispatch(ToolStripMenuItem menuItem)
        {
            SystemAction action = (SystemAction)menuItem.Tag;

            switch (action)
            {
                case SystemAction.Exit:
                    {
                        MainForm.Current.Close();
                    } break;
                case SystemAction.ResetDB:
                    {
                        DatabaseService.SetupDatabase();
                        MessageBox.Show("OK");
                    } break;
                case SystemAction.AdminUsers:
                    {
                        MainForm.Current.ShowUsers();
                    } break;
                case SystemAction.AdminRoles:
                    {
                        MainForm.Current.ShowRoles();
                    } break;
                default:
                    return;
            }
        }
    }
}
