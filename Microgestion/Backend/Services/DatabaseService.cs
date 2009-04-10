using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;

namespace SysQ.Microgestion.Backend.Services
{
    public class DatabaseService : ServiceBase
    {
        private DatabaseService() { }

        public static void SetupDatabase()
        {
            try
            {
                if (DB.DatabaseExists())
                    DB.DeleteDatabase();

                DB.CreateDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception("Error during database setup", ex);
            }
        }

    }
}
