using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;

namespace SysQ.Microgestion.Backend.Services
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
            var dateFinish = new DateTime(filterDateFinish.Year, filterDateFinish.Month, filterDateFinish.Day, 23, 59, 59);

            return DB.Sales
                .Where(s => 
                    s.Date >= filterDateStart && s.Date <= dateFinish)
                .SelectMany(s => s.Details)
                .OrderBy( s => s.Sale.InternalID )
                .ToList();
        }
    }
}
