using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Frontend.Controllers;
using SysQ.Microgestion.Frontend.Extensions;

namespace SysQ.Microgestion.Frontend.Forms
{
    public partial class MainForm : Form, IRestorableForm
    {
        public static MainForm Current { get; private set; }

        #region MDI Childs

        private UsersForm usersForm;
        private RolesForm rolesForm;
        private MeasurementsForm measurementsForm;
        private ItemsForm itemsForm;
        private ItemTypesForm itemTypesForm;

        private UsersForm UsersForm
        {
            get
            {
                if (usersForm == null || usersForm.IsDisposed)
                    usersForm = new UsersForm() { MdiParent = this };

                return usersForm;
            }
        }
        private RolesForm RolesForm
        {
            get
            {
                if (rolesForm == null || rolesForm.IsDisposed)
                    rolesForm = new RolesForm() { MdiParent = this };

                return rolesForm;
            }
        }
        private MeasurementsForm MeasurementsForm
        {
            get
            {
                if (measurementsForm == null || measurementsForm.IsDisposed)
                    measurementsForm = new MeasurementsForm() { MdiParent = this };

                return measurementsForm;
            }
        }
        public ItemsForm ItemsForm
        {
            get
            {
                if (itemsForm == null || itemsForm.IsDisposed)
                    itemsForm = new ItemsForm() { MdiParent = this };

                return itemsForm;
            }
        }
        public ItemTypesForm ItemTypesForm
        {
            get
            {
                if (itemTypesForm == null || itemTypesForm.IsDisposed)
                    itemTypesForm = new ItemTypesForm() { MdiParent = this };

                return itemTypesForm;
            }
        }
        #endregion

        public MainForm()
        {
            try
            {
                InitializeComponent();

                Dispatcher = new MenuDispatcher(this);
                Controller = new MainFormController(this);

                this.Load += (s, e) => Controller.InitializeForm();

                Current = this;
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
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
            try
            {
                DialogResult result = MessageBox.Show(
                    "Esta seguro que desea salir?",
                    "Saliendo...",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                e.Cancel = (result == DialogResult.No);

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
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

        internal void ShowItems()
        {
            this.ItemsForm.Show();
        }

        internal void ShowItemTypes()
        {
            this.ItemTypesForm.Show();
        }

        #region Miembros de IRestorableForm

        public string LocationSetting
        {
            get { return "MainFormLocation"; }
        }

        public string SizeSetting
        {
            get { return "MainFormSize"; }
        }

        public string WindowStateSetting
        {
            get { return "MainFormWindowState"; }
        }

        #endregion

    }
}