using System;
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
    public partial class ItemsForm : Form, IRestorableForm
    {
        ItemsFormController Controller;

        public ItemsForm()
        {
            try
            {
                InitializeComponent();

                Controller = new ItemsFormController(this);
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
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, Name="Name" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InternalCode", HeaderText = "Código Interno" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ExternalCode", HeaderText = "Código Externo" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BaseMeasurement", HeaderText = "Unidad de Medida" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BaseMeasurementID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "MovesStock", HeaderText = "Stock" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ActualStock", HeaderText = "Stock Actual" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MinimumStock", HeaderText = "Stock Mínimo" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CurrentPrice", HeaderText = "Precio" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemTypeID", Visible = false });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ItemType", HeaderText = "Rubro" });
                this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SearchString", Visible = false });

                Grid.DataSource = Controller.Items;

                this.btnAdd.DataBindings.Add(new Binding("Visible", Controller, "AllowAdd"));
                this.btnDelete.DataBindings.Add(new Binding("Visible", Controller, "AllowDelete"));
                this.btnEdit.DataBindings.Add(new Binding("Visible", Controller, "AllowEdit"));

                this.DataBindings.Add(new Binding("Location", Properties.Settings.Default, "ItemsFormLocation"));
                this.DataBindings.Add(new Binding("Size", Properties.Settings.Default, "ItemsFormSize"));
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
