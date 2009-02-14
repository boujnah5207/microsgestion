using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Frontend
{
    public partial class UsersForm : Form
    {
        private UsersFormController Controller;
       
        public UsersForm()
        {
            InitializeComponent();

            Controller = new UsersFormController(this);
            Controller.InitializeForm();

            InitializeControlsHandlers();

            InitializeBindings();

        }

        private void InitializeControlsHandlers()
        {
            this.FormClosing += (s, e) =>
            {
                ((Form)s).Hide(); ((FormClosingEventArgs)e).Cancel = true;
                Controller.SaveChanges();
            };
            this.btnClose.Click += (s, e) => this.Close();

            this.TxtName.TextChanged += (s, e) => Controller.SaveChanges();
            this.TxtLastName.TextChanged += (s, e) => Controller.SaveChanges();
            this.TxtUsername.TextChanged += (s, e) => Controller.SaveChanges();

            this.btnAdd.Click += (s, e) => Controller.AddNew();
            this.btnDelete.Click += (s, e) => Controller.Delete();
        }

        private void InitializeBindings()
        {
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Apellido" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Usuario" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Password", Visible = false });

            this.Grid.DataSource = Controller.Users;

            this.btnAdd.DataBindings.Add(new Binding("Enabled", Controller, "AllowAdd"));
            this.btnDelete.DataBindings.Add(new Binding("Enabled", Controller, "AllowDelete"));

            this.pnlEdit.DataBindings.Add(new Binding("Enabled", Controller, "AllowModify"));

            this.TxtName.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "Name"));
            this.TxtLastName.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "LastName"));
            this.TxtUsername.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "Username"));
        }
    }
}
