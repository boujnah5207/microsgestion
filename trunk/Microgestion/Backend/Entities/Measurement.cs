using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Entities
{
    partial class Measurement : IIdentificableEntity
    {
        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Name, this.Abbreviation);
        }
    }
}
