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
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            Controller = new MainFormController(this);
        }

        private MainFormController Controller { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Controller.LogUser();
        }
    }
}