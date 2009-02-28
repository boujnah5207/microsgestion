﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Entities
{
    partial class Sale : IPersistible
    {
        #region IPersistible Members


        public bool IsValid()
        {
            return
                this.Date != DateTime.MinValue &&
                this.User != null;
        }

        #endregion
    }
}
