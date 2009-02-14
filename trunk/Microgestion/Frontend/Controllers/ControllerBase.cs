using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackspot.Microgestion.Backend.Services;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class ControllerBase<T>
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

    }
}
