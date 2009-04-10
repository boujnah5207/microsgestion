using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using SysQ.Microgestion.Backend.Services;
using SysQ.Microgestion.Frontend.Extensions;
using SysQ.Microgestion.Frontend.Forms;
using SysQ.Microgestion.Frontend.Properties;
using System.Drawing;

namespace SysQ.Microgestion.Frontend.Controllers
{
    internal class ControllerBase<T> : INotifyPropertyChanged
        where T: Form, IRestorableForm
    {
        protected ControllerBase() { }

        protected ControllerBase(T form)
        {
            Form = form;

            RestoreSettings();

            Form.LocationChanged += (s, e) => OnFormLocationChanged();
            Form.SizeChanged += (s, e) => OnFormSizeChanged();
            
        }

        private void RestoreSettings()
        {
            try
            {
                var settings = Settings.Default;

                var windowState = settings.GetType().GetProperty(Form.WindowStateSetting);
                var windowLocation = settings.GetType().GetProperty(Form.LocationSetting);
                var windowSize = settings.GetType().GetProperty(Form.SizeSetting);

                this.Form.WindowState = (FormWindowState)windowState.GetValue(settings, null);
                this.Form.Size = (Size)windowSize.GetValue(settings, null);
                this.Form.Location = (Point)windowLocation.GetValue(settings, null);
            }
            catch { }
        }

        protected virtual void OnFormLocationChanged()
        {
            try
            {
                var settings = Settings.Default;
                var windowLocation = settings.GetType().GetProperty(Form.LocationSetting);
                windowLocation.SetValue(settings, Form.Location, null);
            }
            catch { }
        }

        protected virtual void OnFormSizeChanged()
        {
            try
            {
                var settings = Settings.Default;
                var windowState = settings.GetType().GetProperty(Form.WindowStateSetting);
                var windowSize = settings.GetType().GetProperty(Form.SizeSetting);

                windowSize.SetValue(settings, Form.Size, null);
                windowState.SetValue(settings, Form.WindowState, null);
            }
            catch { }
        }

        protected virtual void OnFormStateChanged()
        {
            try
            {
                var settings = Settings.Default;
                var setting = settings.GetType().GetProperty(Form.WindowStateSetting);
                setting.SetValue(settings, Form.WindowState, null);
            }
            catch { }
        }

        protected T Form { get; set; }

        internal virtual void InitializeForm(){}

        internal virtual void SaveChanges()
        {
            try
            {
                ServiceBase.SubmitChanges();
            }
            catch (Exception ex)
            {
                ex.ShowMessageBox();
            }
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
