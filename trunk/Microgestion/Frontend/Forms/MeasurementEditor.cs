using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Frontend.Extensions;

namespace SysQ.Microgestion.Frontend.Forms
{
    public partial class MeasurementEditor : Form
    {

        private MeasurementEditor() { }

        public MeasurementEditor(Measurement measurement)
        {
            try
            {
                InitializeComponent();

                this.Measurement = measurement;

                this.txtName.DataBindings.Add(new Binding("Text", Measurement, "Name"));
                this.txtAbbreviation.DataBindings.Add(new Binding("Text", Measurement, "Abbreviation"));
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
        }

        public Measurement Measurement { get; set; }
    }
}
