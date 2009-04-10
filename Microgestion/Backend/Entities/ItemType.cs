using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class ItemType : IPersistible
    {
        public override string ToString()
        {
            return this.Name;
        }

        public bool IsValid()
        {
            return
                !String.IsNullOrEmpty(this.Name);
        }
    }
}
