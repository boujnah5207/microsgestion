using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;

namespace SysQ.Microgestion.Backend.Services
{
    public class StockMovementService : ServiceBase<StockMovement>
    {
        private StockMovementService() { }

        public static IEnumerable<StockMovementDetail> SearchMovements(DateTime filterDateStart, DateTime filterDateFinish)
        {
            var dateFinish = new DateTime(filterDateFinish.Year, filterDateFinish.Month, filterDateFinish.Day, 23, 59, 59);

            return DB.StockMovements
                .Where(s => s.Date >= filterDateStart && s.Date <= dateFinish)
                .SelectMany(s => s.Details)
                .OrderBy(s => s.StockMovement.Date)
                .ToList();
        }
    }
}
