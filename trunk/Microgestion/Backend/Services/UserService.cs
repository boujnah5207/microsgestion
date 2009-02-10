using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;

namespace Blackspot.Microgestion.Backend.Services
{
    public class UserService : ServiceBase
    {
        private const string AdministratorID = "{8A886DB5-D154-4a15-A8C9-F3AF69CBD703}";
        private const string AdministratorName = "admin";
        private const string AdministratorPass = "admin";

        private UserService() { }

        static UserService()
        {
            LoggedInUser = CreateNullUser();
        }

        public static User LoggedInUser {get; set;}

        internal static User CreateAdminUser()
        {
            return new User
            {
                ID = new Guid(AdministratorID),
                Username = AdministratorName,
                Password = AdministratorPass,
                Name = AdministratorName,
                LastName = AdministratorName
            };
        }

        internal static User CreateNullUser()
        {
            return new User
            {
                ID = Guid.Empty,
                Username = null,
                Password = null,
                Name = null,
                LastName = null
            };
        }

        public static User GetAdminUser()
        {
            return GetByID<User>(new Guid(AdministratorID));
        }

        public static User GetUserByUsername(string username)
        {
            using (MicrogestionDataContext dc = DataContext)
            {
                return dc.Users
                         .Where(u => u.Username.ToLower().Trim() == username.ToLower().Trim())
                         .SingleOrDefault();
            }
        }
        
        public static bool ValidateUser(string username, string password)
        {
            User user = GetUserByUsername(username);
            if (user == null)
                return false;
            else if (!user.Password.Equals(password))
                return false;
            else
                LoggedInUser = user;

            return true;
        }
    }
}
