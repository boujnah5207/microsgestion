﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class RolesForm : Form
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
                this.FormClosing += (s, e) =>
                {
                    ((Form)s).Hide();
                    ((FormClosingEventArgs)e).Cancel = true;
                };
                this.btnClose.Click += (s, e) => this.Close();

                this.btnAdd.Click += (s, e) => Controller.AddNew();
                this.btnDelete.Click += (s, e) => Controller.Delete();
                this.btnEdit.Click += (s, e) => Controller.Edit();

            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }
    }
}
