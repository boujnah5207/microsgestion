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

        public static IEnumerable<StockMovementDetail> SearchMovements(DateTime fromDate, DateTime toDate)
        {
            return DB.StockMovements
                .Where(s => s.Date >= fromDate && s.Date <= toDate)
                .SelectMany(s => s.Details)
                .ToList();
        }
    }
}
