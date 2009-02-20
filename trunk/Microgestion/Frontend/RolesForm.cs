using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;

namespace Blackspot.Microgestion.Frontend
{
    public partial class RolesForm : Form
    {

        RolesFormController Controller { get; set; }

        public RolesForm()
        {
            InitializeComponent();

            Controller = new RolesFormController(this);
            Controller.InitializeForm();

            InitializeControlsHandlers();

            InitializeBindings();

        }

        private void InitializeBindings()
        {
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Timestamp", Visible = false });

            Grid.DataSource = Controller.Roles;

            this.btnAdd.DataBindings.Add(new Binding("Enabled", Controller, "AllowAdd"));
            this.btnDelete.DataBindings.Add(new Binding("Enabled", Controller, "AllowDelete"));
            this.Grid.DataBindings.Add(new Binding("ReadOnly", Controller, "AllowModify"));

        }

        private void InitializeControlsHandlers()
        {

            this.FormClosing += (s, e) =>
            {
                ((Form)s).Hide(); ((FormClosingEventArgs)e).Cancel = true;
                Controller.SaveChanges();
            };
            this.btnClose.Click += (s, e) => this.Close();

            this.btnAdd.Click += (s, e) => Controller.AddNew();
            this.btnDelete.Click += (s, e) => Controller.Delete();

            this.Grid.CellEndEdit += (s, e) => Controller.SaveChanges();
        }
    }
}
