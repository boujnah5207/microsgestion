using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackspot.Microgestion.Backend.Enumerations
{
    public enum SystemAction
    {
        Null = 0,
        Exit = 1,
        AdminUsers = 2,
        AddUser = 3,
        DeleteUser = 4,
        EditUser = 5,
        AdminRoles = 6,
        AddRole = 7,
        DeleteRole = 8,
        EditRole = 9,
        ResetDB = 999
    }
}
