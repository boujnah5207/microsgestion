using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class Measurement : IPersistible
    {
        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Name, this.Abbreviation);
        }

        public bool IsValid()
        {
            return
                !String.IsNullOrEmpty(this.Name) &&
                !String.IsNullOrEmpty(this.Abbreviation);
        }
    }
}
