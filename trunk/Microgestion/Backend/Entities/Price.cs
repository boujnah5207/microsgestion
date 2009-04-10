using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class Price : IPersistible
    {
        public bool IsValid()
        {
            return
                this.Date != DateTime.MinValue &&
                this.Item != null;
        }

        public override string ToString()
        {
            return String.Format("{0:c}", this.Value);
        }
    }
}
