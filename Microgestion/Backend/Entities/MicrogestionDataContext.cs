using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    partial class MicrogestionDataContext
    {
        partial void OnCreated()
        {
            if (!DatabaseExists())
                CreateDatabase();
        }
    }
}
