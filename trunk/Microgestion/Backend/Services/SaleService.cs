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

            var max = (from s in DB.Sales
                       orderby s.InternalID descending
                       select s).FirstOrDefault();

            if (max == null)
                return 1;

            return max.InternalID + 1;
        }

        public static IEnumerable<SaleDetail> SearchSales(DateTime filterDateStart, DateTime filterDateFinish)
        {
            return DB.Sales
                .Where(s => s.Date >= filterDateStart && s.Date <= filterDateFinish)
                .SelectMany(s => s.Details)
                .ToList();
        }
    }
}
