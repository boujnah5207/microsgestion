using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysQ.Microgestion.Backend.Services;

namespace SysQ.Microgestion.Backend.Enumerations
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
        Sales = 19,
        ItemTypesAdmin = 20,
        ItemTypeAdd = 21,
        ItemTypeDelete = 22,
        ItemTypeEdit = 23,
        Reports = 24,
        LogInOut = 25,
        ResetDB = 100001
    }

    public static class EnumerationExtensions
    {
        public static bool RequireSecurity(this SystemAction action)
        {
            return (action != SystemAction.Null) &&
                   (action != SystemAction.Exit) &&
                   (action != SystemAction.LogInOut) &&
                   (action != SystemAction.ResetDB);
        }

        public static string GetDescription(this SystemAction action)
        {
            switch (action)
            {
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
                case SystemAction.Sales:
                    return "Ventas";
                case SystemAction.ItemTypesAdmin:
                    return "Administrar Rubros";
                case SystemAction.ItemTypeAdd:
                    return "Agregar Rubro";
                case SystemAction.ItemTypeDelete:
                    return "Eliminar Rubro";
                case SystemAction.ItemTypeEdit:
                    return "Modificar Rubro";
                case SystemAction.Reports:
                    return "Reportes";
                case SystemAction.LogInOut:
                    {
                        if (UserService.LoggedInUser.ID != UserService.NullUser.ID)
                            return "&Cerrar Sesión";
                        else
                            return "Iniciar Sesión";
                    };
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
