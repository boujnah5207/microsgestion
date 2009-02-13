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
        ModifyUser = 5,
        ResetDB = 999
    }
}
