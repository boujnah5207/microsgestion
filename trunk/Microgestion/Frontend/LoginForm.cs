using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Blackspot.Microgestion.Frontend.Controllers;
using Blackspot.Microgestion.Backend.Exceptions;

namespace Blackspot.Microgestion.Frontend
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        Boolean validateLogin = false;
        LoginFormController Controller { get; set; }

        public LoginForm()
        {
            InitializeComponent();

            Controller = new LoginFormController(this);

            this.Load += (s, e) => Controller.InitializeForm();
            this.FormClosing += (s, e) => { if (validateLogin) e.Cancel = !Controller.ValidateLogIn(); };
            this.btnAccept.Click += (s, e) => validateLogin = true;
            this.btnCancel.Click += (s, e) => validateLogin = false;
            this.txtUsername.TextChanged += (s, e) => Controller.CheckUser();

            this.txtPassword.DataBindings.Add(new Binding("Enabled", Controller, "UserExists"));
        }


        public string Username
        {
            get
            {
                return this.txtUsername.Text;
            }
            set
            {
                this.txtUsername.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return this.txtPassword.Text;
            }
            set
            {
                this.txtPassword.Text = value;
            }
        }
        

        internal void FocusUsername()
        {
            this.txtUsername.Focus();
        }

        internal void FocusPassword()
        {
            this.txtPassword.Focus();
        }

    }
}