using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackspot.Microgestion.Backend.Enumerations;

namespace Blackspot.Microgestion.Backend.Extensions
{
    public static class EnumerationExtensions
    {
        public static bool RequireSecurity(this SystemAction action)
        {
            return (action != SystemAction.Null) &&
                   (action != SystemAction.Exit);
        }

        public static string GetDescription(this SystemAction action)
        {
            switch (action)
            {
                case SystemAction.ResetDB:
                    return "Reset DB";
                case SystemAction.RolesAdmin:
                    return "Administrar perfiles";
                case SystemAction.RoleAdd:
                    return "Agregar nuevo perfil";
                case SystemAction.RoleDelete:
                    return "Eliminar perfil";
                case SystemAction.RoleEdit:
                    return "Modificar perfil";
                case SystemAction.UsersAdmin:
                    return "Administrar usuarios";
                case SystemAction.UserAdd:
                    return "Agregar nuevo usuario";
                case SystemAction.UserDelete:
                    return "Eliminar usuario";
                case SystemAction.UserEdit:
                    return "Modificar usuario";
                default:
                    return "Sin nombre";
            }
        }

        public static SystemAction[] GetSystemActions()
        {
            return (from a in Enum.GetValues(typeof(SystemAction)).Cast<SystemAction>()
                    where a.RequireSecurity()
                    select a).ToArray();
        }
    }
}
