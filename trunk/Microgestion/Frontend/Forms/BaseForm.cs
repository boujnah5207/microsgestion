using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Frontend.Properties;

namespace Blackspot.Microgestion.Frontend.Forms
{
    internal class BaseForm<T> : Form
        where T : Form, IRestorableForm
    {

        IRestorableForm Form { get; set; }

        public BaseForm(IRestorableForm form)
        {
            this.Form = form;

            this.DataBindings.Add(new Binding("Location", Settings.Default, Form.LocationSetting));
            this.DataBindings.Add(new Binding("Size", Settings.Default, Form.SizeSetting));
            this.DataBindings.Add(new Binding("WindowState", Settings.Default, Form.WindowStateSetting));
        }

        protected override void OnLocationChanged(EventArgs e)
        {

            //var setting = Properties.Settings.Default.GetType().GetProperty(LocationSetting);
            //setting.SetValue(Properties.Settings.Default, this.Location, null);

            base.OnLocationChanged(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
