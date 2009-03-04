using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Entities
{
    partial class StockMovementDetail : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.ItemID != Guid.Empty &&
                this._StockMovementId != Guid.Empty;
        }

        #endregion
    }
}
