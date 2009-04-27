using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;

namespace SysQ.Microgestion.Backend.Services
{
    public class MeasurementService : ServiceBase<Measurement>
    {
        private MeasurementService() { }

        public static Measurement GetByName(string name)
        {
            var measurement = from m in DB.Measurements
                              where m.Name == name
                              select m;

            return measurement.SingleOrDefault();
        }
    }
}
