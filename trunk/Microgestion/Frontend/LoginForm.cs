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

        public LoginForm()
        {
            InitializeComponent();

            Controller = new LoginFormController(this);
        }

        Boolean validateLogin = false;
        LoginFormController Controller { get; set; }

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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Controller.InitializeForm();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (validateLogin)
                {
                    e.Cancel = !Controller.ValidateLogIn();
                }
            }
            catch (InvalidPasswordException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            validateLogin = true;
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