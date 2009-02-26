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
        UsersAdmin = 2,
        UserAdd = 3,
        UserDelete = 4,
        UserEdit = 5,
        RolesAdmin = 6,
        RoleAdd = 7,
        RoleDelete = 8,
        RoleEdit = 9,
        MeasurementsAdmin = 10,
        ResetDB = 999
    }
}
