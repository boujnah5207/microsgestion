using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Frontend.Forms;
using Blackspot.Microgestion.Backend.Entities;
using System.ComponentModel;

namespace Blackspot.Microgestion.Frontend.Controllers
{
    internal class MeasurementsFormController : ControllerBase<MeasurementsForm>
    {

        public MeasurementsFormController(MeasurementsForm form)
            : base(form) { }

        internal BindingList<Measurement> Measurements { get; set; }


    }
}
