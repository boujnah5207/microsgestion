using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Backend.Services
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

                dataContext = null; // force to create a new instance

                DB.CreateDatabase();
            }
            catch (Exception ex)
            {
                throw new Exception("Error during database setup", ex);
            }
        }

    }
}
