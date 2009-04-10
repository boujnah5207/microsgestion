using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class SaleDetail : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.Amount != 0 &&
                this.Item != null &&
                this.Price != null &&
                this.Sale != null;
        }

        #endregion
    }
}
