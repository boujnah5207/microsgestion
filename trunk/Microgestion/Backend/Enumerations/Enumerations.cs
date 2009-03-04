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
        MeasurementAdd = 11,
        MeasurementDelete = 12,
        MeasurementEdit = 13,
        ItemsAdmin = 14,
        ItemAdd = 15,
        ItemDelete = 16,
        ItemEdit = 17,
        StockMovement = 18,
        ResetDB = 999
    }

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
                    return "Administrar Perfiles";
                case SystemAction.RoleAdd:
                    return "Agregar Perfil";
                case SystemAction.RoleDelete:
                    return "Eliminar Perfil";
                case SystemAction.RoleEdit:
                    return "Modificar Perfil";
                case SystemAction.UsersAdmin:
                    return "Administrar Usuarios";
                case SystemAction.UserAdd:
                    return "Agregar Usuario";
                case SystemAction.UserDelete:
                    return "Eliminar Usuario";
                case SystemAction.UserEdit:
                    return "Modificar Usuario";
                case SystemAction.MeasurementsAdmin:
                    return "Administrar Unidades de Medida";
                case SystemAction.MeasurementAdd:
                    return "Agregar Unidad de Medida";
                case SystemAction.MeasurementDelete:
                    return "Eliminar Unidad de Medida";
                case SystemAction.MeasurementEdit:
                    return "Modificar Unidad de Medida";
                case SystemAction.ItemsAdmin:
                    return "Administrar Artículos";
                case SystemAction.ItemAdd:
                    return "Agregar Artículo";
                case SystemAction.ItemDelete:
                    return "Eliminar Artículo";
                case SystemAction.ItemEdit:
                    return "Modificar Artículo";
                case SystemAction.StockMovement:
                    return "Movimiento de Stock";
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
