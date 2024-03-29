﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Entities;
using SysQ.Microgestion.Backend.Enumerations;
using SysQ.Microgestion.Backend.Exceptions;
using SysQ.Microgestion.Backend.Extensions;
using System.Data.Linq;

namespace SysQ.Microgestion.Backend.Services
{
    public class UserService : ServiceBase<User>
    {
        private const string AdministratorID = "{00000000-0000-0000-0000-000000000001}";
        private const string AdministratorName = "Administrador";
        private const string AdministratorLastName = "";
        private const string AdministratorUsername = "admin";
        private const string AdministratorPassword = "009b927906b97d1507451f45d795d55e";
        private static Guid AdministratorGuid = new Guid(AdministratorID);

        private UserService() { }

        static UserService()
        {
            LoggedInUser = NullUser;
        }

        public static User LoggedInUser { get; set; }

        internal static User AdminUser
        {
            get
            {
                return new User
                    {
                        ID = new Guid(AdministratorID),
                        Username = AdministratorUsername,
                        Password = AdministratorPassword,
                        Name = AdministratorName,
                        LastName = AdministratorLastName
                    };
            }
        }

        internal static User NullUser
        {
            get
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
        }

        public static User GetUserByUsername(string username)
        {
            return DB.Users
                     .Where(u => u.Username.ToLower().Trim() == username.ToLower().Trim())
                     .SingleOrDefault();
        }

        public static bool ValidateUser(string username, string password)
        {
            //Check if it is the admin user
            if (AdministratorUsername == username)
            {
                if (AdministratorPassword != password)
                    throw new InvalidPasswordException();

                LoggedInUser = AdminUser;
                return true;
            }

            User user = GetUserByUsername(username);
            if (user == null)
                throw new UserNotFoundException();
            else if (String.IsNullOrEmpty(user.Password))
                throw new MustConfirmPasswordException();
            else if (!user.Password.Equals(password))
                throw new InvalidPasswordException();
            else
                LoggedInUser = user;

            return true;
        }

        public static bool CanPerform(SystemAction action)
        {
            return CanPerform(LoggedInUser, action);
        }

        public static bool CanPerform(User user, SystemAction action)
        {
            if (!action.RequireSecurity())
                return true;
            if (user.Equals(AdminUser))
                return true;

            //return user.UserRoles.Any
            //    (
            //        ur => ur.Role.Actions.Any
            //            (
            //                a => a.Action == action
            //            )
            //    );
            foreach (var ur in user.UserRoles)
                foreach (var a in ur.Role.Actions)
                    if (a.Action.Equals(action))
                        return true;

            return false;
        }

        public static bool CheckIfUserExists(string username)
        {
            if (username == AdministratorUsername)
                return true;

            return DB.Users.Any(u => u.Username.Equals(username));
        }

        public static User GetAdminUser()
        {
            return AdminUser;
        }

        public static User GetNullUser()
        {
            return NullUser;
        }

        public static IList<Role> GetRoles(User user)
        {
            return user.UserRoles
                       .Select(u => u.Role)
                       .ToList();
        }

        public static void Save(User user, IEnumerable<Role> roles)
        {
            if (user.ID != Guid.Empty)
                Update(user, roles);

            Save(user);

            List<UserRoles> rolesToAdd =
                roles
                    .Where(r => !user.UserRoles.Any(ur => ur.Role.Equals(r)))
                    .Select(r => new UserRoles()
                    {
                        UserID = user.ID,
                        RoleID = r.ID
                    })
                    .ToList();


            UserRoleService.SaveAll(rolesToAdd);
            user.UserRoles.AddRange(rolesToAdd);

            Update(user);
        }

        public static void Update(User user, IEnumerable<Role> roles)
        {
            if (user.ID == Guid.Empty)
                Save(user, roles);

            List<UserRoles> rolesToDelete = 
                user.UserRoles
                    .Where(ur => !roles.Contains(ur.Role))
                    .ToList();

            List<UserRoles> rolesToAdd = 
                roles
                    .Where(r => !user.UserRoles.Any(ur => ur.Role.Equals(r)))
                    .Select(r => new UserRoles()
                        { 
                            UserID = user.ID, RoleID = r.ID 
                        })
                    .ToList();


            UserRoleService.DeleteAll(rolesToDelete);
            UserRoleService.SaveAll(rolesToAdd);

            user.UserRoles.AddRange(rolesToAdd);
            foreach (var r in rolesToDelete)
                user.UserRoles.Remove(r);
            Update(user);
            return;
        }
    }
}
