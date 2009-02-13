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
        public static MainForm Current { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            Dispatcher = new MenuDispatcher(this);
            Controller = new MainFormController(this);

            Current = this;
        }

        private MenuDispatcher Dispatcher { get; set; }
        private MainFormController Controller { get; set; }

        internal string UserInfo
        {
            get
            {
                return this.lblLoggedInUser.Text;
            }
            set
            {
                this.lblLoggedInUser.Text = value;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Controller.InitializeForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Esta seguro que desea salir?", 
                "Saliendo...", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            e.Cancel = (result == DialogResult.No);
        }
    }
}