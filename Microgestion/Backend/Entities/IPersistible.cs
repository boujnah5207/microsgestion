using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysQ.Microgestion.Backend.Entities
{
    public interface IPersistible
    {
        Guid ID { get; set; }

        Boolean IsValid();
    }
}
