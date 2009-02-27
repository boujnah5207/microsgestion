using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Frontend.Forms
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
            catch (Exception)
            {
                throw;
            }
        }

        public Measurement Measurement { get; set; }
    }
}
