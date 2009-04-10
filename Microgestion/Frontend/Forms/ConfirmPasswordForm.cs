using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Extensions;

namespace SysQ.Microgestion.Frontend.Forms
{
    public partial class ConfirmPasswordForm : Form
    {
        public ConfirmPasswordForm()
        {
            InitializeComponent();
        }

        public string Password
        {
            get
            {
                return this.txtPassword.Text.GetMD5Hash();
            }
        }
    }
}
