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

            this.btnAdd.Click += (s, e) => Controller.AddNew();
            this.btnDelete.Click += (s, e) => Controller.Delete();
            this.btnEdit.Click += (s, e) => Controller.Edit();
        }

        private void InitializeBindings()
        {
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Apellido" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Usuario" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Password", Visible = false });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Timestamp", Visible = false });

            this.Grid.DataSource = Controller.Users;

            this.btnAdd.DataBindings.Add(new Binding("Visible", Controller, "AllowAdd"));
            this.btnDelete.DataBindings.Add(new Binding("Visible", Controller, "AllowDelete"));
            this.btnEdit.DataBindings.Add(new Binding("Visible", Controller, "AllowEdit"));
        }
    }
}
