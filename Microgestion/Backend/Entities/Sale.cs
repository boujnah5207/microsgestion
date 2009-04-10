using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Services;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class Sale : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.Date != DateTime.MinValue &&
                this.UserID != Guid.Empty &&
                this.InternalID != 0;
        }

        #endregion
    }
}
