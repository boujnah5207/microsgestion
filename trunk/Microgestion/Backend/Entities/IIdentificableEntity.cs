﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Entities
{
    public interface IIdentificableEntity
    {
        Guid ID { get; set; }
    }
}
