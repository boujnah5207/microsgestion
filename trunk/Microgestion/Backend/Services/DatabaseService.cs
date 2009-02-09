using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Backend.Services
{
    public static class DatabaseService
    {

        public static void SetupDatabase()
        {
            try
            {
                using (MicrogestionDataContext dc = ServiceBase.DataContext)
                {
                    if (dc.DatabaseExists())
                        dc.DeleteDatabase();

                    dc.CreateDatabase();

                    User admin = UserService.CreateAdminUser();

                    UserService.Save(admin);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during database setup", ex);
            }
        }

    }
}
