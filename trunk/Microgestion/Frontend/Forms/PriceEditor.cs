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
    public partial class PriceEditor : Form
    {
        private PriceEditor() { }

        public PriceEditor(Double currentValue)
        {
            InitializeComponent();

            this.CurrentValue = currentValue;

            this.txtCurrent.DataBindings.Add(new Binding("Text", this, "CurrentValue"));
            this.txtNew.DataBindings.Add(new Binding("Text", this, "NewValue"));
        }

        public Double CurrentValue { get; set; }
        public Double NewValue { get; set; }
    }
}
