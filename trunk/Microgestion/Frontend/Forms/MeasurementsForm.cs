using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Controllers;

namespace Blackspot.Microgestion.Frontend.Forms
{
    public partial class MeasurementsForm : Form
    {
        MeasurementsFormController Controller;

        public MeasurementsForm()
        {
            InitializeComponent();

            Controller = new MeasurementsFormController(this);
            Controller.InitializeForm();

            InitializeControlsHandlers();

            InitializeBindings();

        }

        private void InitializeBindings()
        {
            
        }

        private void InitializeControlsHandlers()
        {
            this.FormClosing += (s, e) =>
            {
                ((Form)s).Hide();
                ((FormClosingEventArgs)e).Cancel = true;
            };

        }

    }
}
