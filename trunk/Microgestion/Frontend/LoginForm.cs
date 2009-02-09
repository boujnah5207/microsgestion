using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Blackspot.Microgestion.Frontend.Controllers;

namespace Blackspot.Microgestion.Frontend
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {

        public LoginForm()
        {
            InitializeComponent();

            Controller = new LoginFormController(this);
        }

        LoginFormController Controller { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Controller.InitializeForm();
        }

    }
}