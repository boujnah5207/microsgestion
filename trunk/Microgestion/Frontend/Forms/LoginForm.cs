using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;
using Blackspot.Microgestion.Backend.Exceptions;
using Blackspot.Microgestion.Backend.Extensions;
using Blackspot.Microgestion.Frontend.Extensions;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class LoginForm : Form, IRestorableForm
    {
        Boolean validateLogin = false;
        LoginFormController Controller { get; set; }

        public LoginForm()
        {
            try
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
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
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
                return this.txtPassword.Text.GetMD5Hash();
            }
        }

        public void SetStatusMessage(string message)
        {
            SetStatusMessage(message, false);
        }
        public void SetStatusMessage(string message, bool redMessage)
        {
            this.lblMessage.ForeColor = redMessage ? Color.Red : Color.Black;
            this.lblMessage.Text = message;
        }

        internal void FocusUsername()
        {
            this.txtUsername.Focus();
        }

        internal void FocusPassword()
        {
            this.txtPassword.SelectAll();
            this.txtPassword.Focus();
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
