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
    public partial class MeasurementsForm : Form, IRestorableForm
    {
        MeasurementsFormController Controller;

        public MeasurementsForm()
        {
            try
            {
                InitializeComponent();

                Controller = new MeasurementsFormController(this);
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
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Abbreviation", HeaderText = "Abreviatura" });

                Grid.DataSource = Controller.Measurements;

                this.btnAdd.DataBindings.Add(new Binding("Visible", Controller, "AllowAdd"));
                this.btnDelete.DataBindings.Add(new Binding("Visible", Controller, "AllowDelete"));
                this.btnEdit.DataBindings.Add(new Binding("Visible", Controller, "AllowEdit"));

                this.DataBindings.Add(new Binding("Location", Properties.Settings.Default, "MeasurementsFormLocation"));
                this.DataBindings.Add(new Binding("Size", Properties.Settings.Default, "MeasurementsFormSize"));
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
                //this.FormClosing += (s, e) =>
                //{
                //    ((Form)s).Hide();
                //    ((FormClosingEventArgs)e).Cancel = true;
                //};
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


        #region Miembros de IRestorableForm

        public string LocationSetting
        {
            get { return "MeasurementsFormLocation"; }
        }

        public string SizeSetting
        {
            get { return "MeasurementsFormSize"; }
        }

        public string WindowStateSetting
        {
            get { return "MeasurementsFormWindowState"; }
        }

        #endregion
    }
}
