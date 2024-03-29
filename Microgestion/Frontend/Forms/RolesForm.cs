﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Frontend.Controllers;
using SysQ.Microgestion.Frontend.Extensions;

namespace SysQ.Microgestion.Frontend.Forms
{
    public partial class RolesForm : Form, IRestorableForm
    {

        RolesFormController Controller { get; set; }

        public RolesForm()
        {
            try
            {
                InitializeComponent();

                Controller = new RolesFormController(this);
                Controller.InitializeForm();

                InitializeControlsHandlers();

                InitializeBindings();

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void InitializeBindings()
        {
            try
            {
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Timestamp", Visible = false });

                Grid.DataSource = Controller.Roles;

                this.btnAdd.DataBindings.Add(new Binding("Visible", Controller, "AllowAdd"));
                this.btnDelete.DataBindings.Add(new Binding("Visible", Controller, "AllowDelete"));
                this.btnEdit.DataBindings.Add(new Binding("Visible", Controller, "AllowEdit"));
                this.btnActions.DataBindings.Add(new Binding("Visible", Controller, "AllowEdit"));

                this.DataBindings.Add(new Binding("Location", Properties.Settings.Default, "RolesFormLocation"));
                this.DataBindings.Add(new Binding("Size", Properties.Settings.Default, "RolesFormSize"));
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        private void InitializeControlsHandlers()
        {
            try
            {
                this.btnClose.Click += (s, e) => this.Close();

                this.btnAdd.Click += (s, e) => Controller.AddNew();
                this.btnDelete.Click += (s, e) => Controller.Delete();
                this.btnEdit.Click += (s, e) => Controller.Edit();
                this.btnCheckAll.Click += (s, e) => Controller.SelectAllActions(true);
                this.btnUncheckAll.Click += (s, e) => Controller.SelectAllActions(false);
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        #region Miembros de IRestorableForm

        public string LocationSetting
        {
            get { throw new NotImplementedException(); }
        }

        public string SizeSetting
        {
            get { throw new NotImplementedException(); }
        }

        public string WindowStateSetting
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

    }
}
