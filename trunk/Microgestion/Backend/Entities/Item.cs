using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Entities
{
    partial class Item : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.BaseMeasurement != null &&
                this.Name != null;
        }

        #endregion
    }
}
