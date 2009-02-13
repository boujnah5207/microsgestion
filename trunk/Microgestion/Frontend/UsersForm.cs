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
            this.FormClosing += (s, e) => { ((Form)s).Hide(); ((FormClosingEventArgs)e).Cancel = true; };
            
            this.btnClose.Click += (s, e) => this.Close();

            this.btnModify.Click += (s, e) => { Controller.IsEditing = true; this.Update(); };
            this.btnCancel.Click += (s, e) => { Controller.IsEditing = false; this.Update(); };
        }

        private void InitializeBindings()
        {
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", Visible = false });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Nombre" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Apellido" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Usuario" });
            this.Grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Password", Visible = false });

            this.Grid.DataSource = new BindingList<User>(Controller.Users);

            this.btnAdd.DataBindings.Add(new Binding("Enabled", Controller, "EnableAddButton"));
            this.btnDelete.DataBindings.Add(new Binding("Enabled", Controller, "EnableDeleteButton"));
            this.btnModify.DataBindings.Add(new Binding("Enabled", Controller, "EnableModifyButton"));

            this.pnlEdit.DataBindings.Add(new Binding("Enabled", Controller, "IsEditing"));

            this.txtName.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "Name"));
            this.txtLastName.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "LastName"));
            this.txtUsername.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "Username"));
            this.txtPassword.DataBindings.Add(new Binding("Text", this.Grid.DataSource, "Password"));
        }

    }
}
