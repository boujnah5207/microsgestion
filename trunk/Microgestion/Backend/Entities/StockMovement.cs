using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Entities
{
    partial class StockMovement : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.Date != DateTime.MinValue &&
                this.Item != null &&
                this.User != null;
        }

        #endregion
    }
}
