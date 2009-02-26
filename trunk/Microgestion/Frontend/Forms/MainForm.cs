using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class MainForm : Form
    {
        public static MainForm Current { get; private set; }

        #region MDI Childs

        private UsersForm usersForm;
        private UsersForm UsersForm
        {
            get
            {
                if (usersForm == null)
                    usersForm = new UsersForm() { MdiParent = this };

                return usersForm;
            }
        }
        private RolesForm rolesForm;
        private RolesForm RolesForm
        {
            get
            {
                if (rolesForm == null)
                    rolesForm = new RolesForm() { MdiParent = this };

                return rolesForm;
            }
        }
        private MeasurementsForm measurementsForm;
        private MeasurementsForm MeasurementsForm
        {
            get
            {
                if (measurementsForm == null)
                    measurementsForm = new MeasurementsForm() { MdiParent = this };

                return measurementsForm;
            }
        }
        
        #endregion

        public MainForm()
        {
            InitializeComponent();

            Dispatcher = new MenuDispatcher(this);
            Controller = new MainFormController(this);

            this.Load += (s, e) => Controller.InitializeForm();

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

        internal void ShowUsers()
        {
            this.UsersForm.Show();
        }

        internal void ShowRoles()
        {
            this.RolesForm.Show();
        }

        internal void ShowMeasurements()
        {
            this.MeasurementsForm.Show();
        }
    }
}