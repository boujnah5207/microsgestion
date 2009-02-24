using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Extensions;

namespace Blackspot.Microgestion.Frontend
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
