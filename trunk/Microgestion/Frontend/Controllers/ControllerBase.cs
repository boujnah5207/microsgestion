using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Services;
using System.ComponentModel;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class ControllerBase<T> : INotifyPropertyChanged
        where T: Form
    {
        protected ControllerBase() { }

        protected ControllerBase(T form)
        {
            Form = form;
        }

        protected T Form { get; set; }

        internal virtual void InitializeForm(){}

        internal virtual void SaveChanges()
        {
            ServiceBase.SubmitChanges();
        }

        internal virtual bool UserAccepts(string message, string title)
        {
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);

            return result == DialogResult.Yes;
        }

        #region INotifyPropertyChanged Members

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
