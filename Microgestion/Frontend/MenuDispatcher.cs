﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Enumerations;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Frontend.Forms;

namespace SysQ.Microgestion.Frontend
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
                case SystemAction.LogInOut:
                    {
                        MainForm.Current.LogInOut();
                    } break;
                case SystemAction.ResetDB:
                    {
                        if (DialogResult.Yes == MessageBox.Show(
                            "Usted está a punto de resetear la Base de Datos.\nSi elige continuar PERDERÁ TODOS LOS DATOS DE LA BASE.\n¿Está seguro que desea continuar?", 
                            "Resetear Base de Datos", 
                            MessageBoxButtons.YesNo, 
                            MessageBoxIcon.Warning, 
                            MessageBoxDefaultButton.Button2))
                        {
                            DatabaseService.SetupDatabase();
                            MessageBox.Show("La Base de Datos fue reseteada.");
                        }
                    } break;
                case SystemAction.UsersAdmin:
                    {
                        MainForm.Current.ShowUsers();
                    } break;
                case SystemAction.RolesAdmin:
                    {
                        MainForm.Current.ShowRoles();
                    } break;
                case SystemAction.MeasurementsAdmin:
                    {
                        MainForm.Current.ShowMeasurements();
                    } break;
                case SystemAction.ItemsAdmin:
                    {
                        MainForm.Current.ShowItems();
                    } break;
                case SystemAction.ItemTypesAdmin:
                    {
                        MainForm.Current.ShowItemTypes();
                    } break;
                default:
                    return;
            }
        }
    }
}
