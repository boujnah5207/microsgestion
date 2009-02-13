using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Entities;
using Blackspot.Microgestion.Backend.Enumerations;
using Blackspot.Microgestion.Backend.Exceptions;

namespace Blackspot.Microgestion.Backend.Services
{
    public class UserService : ServiceBase
    {
        private const string AdministratorID = "{8A886DB5-D154-4a15-A8C9-F3AF69CBD703}";
        private const string AdministratorName = "Administrador";
        private const string AdministratorLastName = "";
        private const string AdministratorUsername = "admin";
        private const string AdministratorPassword = "a";
        private static Guid AdministratorGuid = new Guid(AdministratorID);

        private UserService() { }

        static UserService()
        {
            LoggedInUser = CreateNullUser();
        }

        public static User LoggedInUser { get; set; }

        internal static void CreateAdminUser()
        {
            User admin = new User
                {
                    ID = new Guid(AdministratorID),
                    Username = AdministratorUsername,
                    Password = AdministratorPassword,
                    Name = AdministratorName,
                    LastName = AdministratorLastName
                };

            Save(admin);
        }

        internal static User CreateNullUser()
        {
            return new User
            {
                ID = Guid.Empty,
                Username = string.Empty,
                Password = string.Empty,
                Name = string.Empty,
                LastName = string.Empty
            };
        }

        public static User GetAdminUser()
        {
            return GetByID<User>(new Guid(AdministratorID));
        }

        public static User GetUserByUsername(string username)
        {
            return DB.Users
                     .Where(u => u.Username.ToLower().Trim() == username.ToLower().Trim())
                     .SingleOrDefault();
        }

        public static bool ValidateUser(string username, string password)
        {
            User user = GetUserByUsername(username);
            if (user == null)
                return false;
            else if (!user.Password.Equals(password))
                throw new InvalidPasswordException();
            else
                LoggedInUser = user;

            return true;
        }

        public static bool CanPerform(User user, SystemAction action)
        {
            if (action == SystemAction.Null)
                return true;
            if (user.ID == AdministratorGuid)
                return true;

            return user.UserRoles.Any
                (
                    ur => ur.Role.Actions.Any
                        (
                            a => a.Action == action
                        )
                );
        }
    }
}
