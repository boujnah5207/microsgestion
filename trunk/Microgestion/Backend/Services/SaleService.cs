using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Backend.Services
{
    public class SaleService : ServiceBase<Sale>
    {
        public SaleService() { }

        public static int GetNextNumber()
        {
            return DB.Sales.Max(s => s.InternalID) + 1;
        }
    }
}
